using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace DemoContracts
{
    public class CreateOrder : ICommand
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }
}
