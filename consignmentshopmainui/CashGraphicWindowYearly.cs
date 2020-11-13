using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ConsignmentShopMainUI
{
    public partial class CashGraphicWindowYearly : Form
    {
        public List<CashVolumeMonthly> TotalCashList { get; set; }

        public CashGraphicWindowYearly()
        {
            InitializeComponent();
        }


        private void CashGraphicWindowYearly_Shown(object sender, EventArgs e)
        {
            CreateChart();
        }

        private void CreateChart()
        {
            //TotalCashList in Reihen mit double-Werten für jedes Jahr aufteilen
            //immer zwölf Werte d.h. auch 0 eintragen


            // Group the pets using Age as the key value 
            // and selecting only the pet's Name for each value.
            Chart1.ChartAreas[0].AxisX.Interval = 1;

            Chart1.Series.Clear();

            Chart1.Titles.Add("Jährliche Umsätze");

            var series1 = new Series
            {
                Name = "SalesVolume",
                Color = Color.LightGreen,
                IsVisibleInLegend = true,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Column
            };

            series1.IsValueShownAsLabel = true;


            series1.Name = "Umsatz pro Jahr";
            Chart1.Series.Add(series1);

            //Diagramm AktYear
            SetGraphicPointsYearly(series1);

            Chart1.Invalidate();
            Chart1.GetToolTipText += new EventHandler<ToolTipEventArgs>(Chart1_GetToolTipText);

        }

        private void Chart1_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int i = e.HitTestResult.PointIndex;
                DataPoint dp = e.HitTestResult.Series.Points[i];
                e.Text =  dp.YValues[0].ToString();
            }
        }

        private void SetGraphicPointsYearly(Series chartSeries)
        {
            Dictionary<string, decimal> data = new Dictionary<string, decimal>();
            Dictionary<string, double> temp = new Dictionary<string, double>();
            List<object[]> newList = TotalCashList
                /* Group the list by the element at position 0 in each item */
                .GroupBy(o => o.Year.ToString())
                /* Project the created grouping into a new object[]: */
                .Select(i => new object[]
                {
                                i.Key,
                                i.Sum(x => x.SalesSum)
                })
                .ToList();

            foreach (var item in newList)
            {
                data.Add(item[0].ToString(), (decimal)item[1]);

            }

            foreach (var entry in data)
            {
                chartSeries.Points.Add(new DataPoint()
                {
                    AxisLabel = entry.Key,
                    YValues = new double[] { (double)entry.Value }
                });
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
