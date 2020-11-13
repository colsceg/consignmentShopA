using ConsignmentShopLibrary;
using System;
using System.Collections;
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
    public partial class CashGraphicWindowMonthly : Form
    {
        public List<CashVolumeMonthly> TotalCashList { get; set; }
        private ArrayList myMonatsListe = new ArrayList();

        private string[] myMonate = { "Jan", "Feb", "Mrz", "April", "Mai", "Juni", "Juli", "Aug", "Sep", "Okt", "Nov", "Dez" };

        public CashGraphicWindowMonthly()
        {
            InitializeComponent();
        }

        private void CashGraphicWindow_Shown(object sender, EventArgs e)
        {
            CreateChart();
            //CashChart.SaveImage("Umsatz.png", ChartImageFormat.Png);
        }

        private void CreateChart()
        {
            //TotalCashList in Reihen mit double-Werten für jedes Jahr aufteilen
            //immer zwölf Werte d.h. auch 0 eintragen


            // Group the pets using Age as the key value 
            // and selecting only the pet's Name for each value.
            var result = TotalCashList.GroupBy(year => year.Year);


            int index = result.Count();
            CashChart.ChartAreas[0].AxisX.Interval = 1;
      
            myMonatsListe.AddRange(myMonate);

            CashChart.Series.Clear();

            CashChart.Titles.Add("Monatliche Umsätze der vergangenen 3 Jahre");
            //CashChart.Titles.Add("Jahresumsätze");

            //Umsätze für das Laufende Jahr
            int myAktYearInt = DateTime.Today.Year;
            string myAktYear = Convert.ToString(myAktYearInt);
            string myLastYear = Convert.ToString(myAktYearInt - 1);
            string myBeforeLastYear = Convert.ToString(myAktYearInt - 2);

            var series1 = new Series
            {
                Name = myAktYear,
                Color = Color.Green,
                IsVisibleInLegend = true,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Column
            };

            var series2 = new Series
            {
                Name = myLastYear,
                Color = Color.Red,
                IsVisibleInLegend = true,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Column
            };

            var series3 = new Series
            {
                Name = myBeforeLastYear,
                Color = Color.RoyalBlue,
                IsVisibleInLegend = true,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Column
            };

            //var series4 = new Series
            //{
            //    Name = myBeforeLastYear,
            //    Color = Color.RoyalBlue,
            //    IsVisibleInLegend = true,
            //    IsXValueIndexed = true,
            //    ChartType = SeriesChartType.Column
            //};

            series1.Name = "Umsatz " + myAktYear;
            series2.Name = "Umsatz " + myLastYear;
            series3.Name = "Umsatz " + myBeforeLastYear;
            //series3.Name = "Umsatz pro Jahr ";

            CashChart.Series.Add(series1);
            CashChart.Series.Add(series2);
            CashChart.Series.Add(series3);

            //CashChart.Series.Add(series4);

            //series4.ChartArea = "ChartArea2";

            //Diagramm year before Lastyear
            setGraphicPointsMonthly(myBeforeLastYear, series3);
            //Diagramm Lastyear
            setGraphicPointsMonthly(myLastYear, series2);
            //Diagramm AktYear
            setGraphicPointsMonthly(myAktYear, series1);

            //Diagramm AktYear
            // SetGraphicPointsYearly(series4);

            CashChart.GetToolTipText += new EventHandler<ToolTipEventArgs>(CashChart_GetToolTipText);

        }

        private void CashChart_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int i = e.HitTestResult.PointIndex;
                DataPoint dp = e.HitTestResult.Series.Points[i];
                e.Text = dp.YValues[0].ToString();
            }
        }

        private void setGraphicPointsMonthly(string myYear, Series chartSeries)
        {
            Dictionary<string, decimal> data = new Dictionary<string, decimal>();
            Dictionary<string, decimal> temp = new Dictionary<string, decimal>();
            foreach (var item in TotalCashList)
            {
                if (myYear == item.Year)
                {
                    data.Add(item.Monthname, item.SalesSum);

                }
            }

            for (int myIndex = 0; myIndex < 12; myIndex++)
            {
                if (data.TryGetValue(myMonatsListe[myIndex].ToString(), out decimal value))
                    temp.Add(myMonatsListe[myIndex].ToString(), value);
                else
                    temp.Add(myMonatsListe[myIndex].ToString(), 0);
            }

            foreach (KeyValuePair<string, decimal> entry in temp)
            {
                chartSeries.Points.Add(new DataPoint()
                {
                    AxisLabel = entry.Key,
                    YValues = new double[] { (double)entry.Value }
                });
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MonthlySalesVolumeBtn_Click(object sender, EventArgs e)
        {
            CashChart.ChartAreas[0].Visible = true;
            CashChart.ChartAreas[1].Visible = false;
        }

        private void YearlySalesVolumeBtn_Click(object sender, EventArgs e)
        {
            //Fenster mit Diagramm öffnen
            CashGraphicWindowYearly CashGraphicWin = new CashGraphicWindowYearly();
            CashGraphicWin.TotalCashList = TotalCashList;
            CashGraphicWin.Show();
        }
    }
}
