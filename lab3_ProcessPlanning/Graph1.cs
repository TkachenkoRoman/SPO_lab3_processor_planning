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

namespace lab3_ProcessPlanning
{
    public partial class Graph1 : Form
    {
        private Series mySeries;
        private List<DataForGraph> dataList;
        private int graphType;

        public Graph1(int graphType)
        {
            InitializeComponent();
            initChart();
            this.graphType = graphType;
            if (this.graphType == 1)
                SetPoints1();
            else if (this.graphType == 2)
                SetPoints2();
        }

        private void SetPoints2()
        {
            dataList = new List<DataForGraph>();
            DataForGraph.Deserialize(ref dataList);

            string xPoint = "";
            dataList = dataList.OrderBy(x => x.arisingTimeMin).ToList();
            foreach (var elem in dataList)
            {
                xPoint = elem.arisingTimeMin.ToString() + "-" + elem.arisingTimeMax.ToString();
                mySeries.Points.AddXY(xPoint, elem.processorFreePercent);
            }
            chart1.Invalidate();
        }

        private void initChart()
        {
            chart1.Series.Clear();
            mySeries = new Series
            {
                Name = "mySeries",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Spline
            };

            chart1.Series.Add(mySeries);
            //chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
        }

        private void SetPoints1()
        {
            dataList = new List<DataForGraph>();
            DataForGraph.Deserialize(ref dataList);

            string xPoint = "";
            dataList = dataList.OrderBy(x => x.arisingTimeMin).ToList();
            foreach (var elem in dataList)
            {
                xPoint = elem.arisingTimeMin.ToString() + "-" + elem.arisingTimeMax.ToString();
                mySeries.Points.AddXY(xPoint, elem.averagePauseTime);
            }
            chart1.Invalidate();
        }

    }
}
