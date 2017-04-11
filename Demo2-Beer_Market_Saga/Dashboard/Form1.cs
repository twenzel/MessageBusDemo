using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class Form1 : Form
    {
        private BeerMarketConnector _connector;
        private LineSeries _series;
        private int _beerAmount = 0;
        private decimal _currentPrice;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _connector = new BeerMarketConnector();
            _connector.Init();

            _connector.BeerPriceChanged += _connector_BeerPriceChanged;
            _connector.BeerOrdered += _connector_BeerOrdered;

            createPlot();
        }

        private void _connector_BeerOrdered(object sender, int e)
        {
            _beerAmount += e;
            Action del = () => label1.Text = $"{_beerAmount} Beers";

            label1.Invoke(del);            
        }

        private void _connector_BeerPriceChanged(object sender, decimal e)
        {
            _currentPrice = e;            
        }

        private void createPlot()
        {
            var pm = new PlotModel
            {
                Title = "Beer market",
                Subtitle = "Price development",
                PlotType = PlotType.XY,
                Background = OxyColors.White
            };

            _series = new LineSeries() { Title = "Price"};
            pm.Series.Add(_series);
                     
            var minValue = DateTimeAxis.ToDouble(DateTime.Now);
            var maxValue = DateTimeAxis.ToDouble(DateTime.Now.AddMinutes(2));

            pm.Axes.Add(new LinearAxis() { Minimum = 0, Maximum = 100, Position = AxisPosition.Left});
            pm.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, Minimum = minValue, Maximum = maxValue, StringFormat = "HH:mm" });

            plot1.Model = pm;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _connector.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now), (double)_currentPrice));

            plot1.Invalidate();
        }
    }
}
