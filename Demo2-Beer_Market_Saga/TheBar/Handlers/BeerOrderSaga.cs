using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beer.Messages;
using Rebus.Bus;
using Rebus.Handlers;
using Rebus.Sagas;
using TheBar.Messages;

namespace TheBar.Handlers
{
    public class BeerOrderSaga: Saga<BeerOrderSagaData>, IAmInitiatedBy<GiveBeer>, IHandleMessages<SendMoney>, IHandleMessages<VerifyComplete>
    {
        public IBus Bus { get; private set; }
        public ICashier Cashier { get; private set; }
   
        public BeerOrderSaga(IBus bus, ICashier cashier)
        {
            Bus = bus;
            Cashier = cashier;
        }

        protected override void CorrelateMessages(ICorrelationConfig<BeerOrderSagaData> config)
        {
            // events of interest
            config.Correlate<GiveBeer>(m => m.CustomerName, d => d.CustomerName);
            config.Correlate<SendMoney>(m => m.CustomerName, d => d.CustomerName);    

            // internal verification message
            config.Correlate<VerifyComplete>(m => m.CustomerName, d => d.CustomerName);
            
        }

        public async Task Handle(GiveBeer message)
        {
            await Pre();

            Console.WriteLine($"{message.Amount} Beer was ordered from {message.CustomerName}");

            var totalPrice = message.Amount * Cashier.GetPricePerBottle();

            Data.BeerOrdered = true;            
            Data.TotalPrice = totalPrice;
            Data.Amount = message.Amount;

            await Bus.Reply(new GiveMoney
            {
                TotalPrice = totalPrice,                
                CustomerName = message.CustomerName
            });

            await Bus.Publish(new BeerOrderedEvent() { Amount = message.Amount });
            
            await Post();
        }

        public async Task Handle(SendMoney message)
        {
            await Pre();

            Console.WriteLine($"Got {message.Amount:c} from {message.CustomerName} in cash.");

            if (message.Amount >= Data.TotalPrice)
            {
                Data.MoneyRecieved = true;

                await Bus.Reply(new SendBeer
                {
                    Beer = Data.Amount.Times(() => new Beer.Messages.Beer()).ToArray(),                    
                    CustomerName = message.CustomerName
                });                
            }
            else
            {
                Console.WriteLine($"Too less. Cancel order.");

                await Bus.Publish(new OrderCanceled() { CustomerName = Data.CustomerName });

                MarkAsComplete();
            }

            await Post();
        }

        public async Task Handle(VerifyComplete message)
        {
            Console.WriteLine($"Warning: The saga for customer {Data.CustomerName} was not completed within 20s timeout");

            await Bus.Publish(new OrderCanceled() { CustomerName = Data.CustomerName});

            MarkAsComplete();
        }

        async Task Pre()
        {
            if (!IsNew)
                return;

            Console.WriteLine($"Ordering wake-up call in 20 s for case {Data.CustomerName}");

            await Bus.Defer(TimeSpan.FromSeconds(20), new VerifyComplete() { CustomerName = Data.CustomerName });
        }

        async Task Post()
        {
            if (!Data.IsDone)
                return;

            Console.WriteLine($"Order completed and marking saga for case {Data.CustomerName} as complete");

            await Bus.Publish(new OrderCompleted() { CustomerName = Data.CustomerName});

            MarkAsComplete();
        }
    }

    public class BeerOrderSagaData: SagaData
    {
        public string CustomerName { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }

        public bool BeerOrdered { get; set; }
        public bool MoneyRecieved { get; set; }

        public bool IsDone => BeerOrdered
                              && MoneyRecieved;
        
    }
}
