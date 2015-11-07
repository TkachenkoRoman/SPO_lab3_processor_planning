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
        private List<DataForGraph1> dataList;
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
            else if (this.graphType == 3)
                SetPoints3();
        }

        private void SetGraphAxisTitles(string titleX, string titleY)
        {
            chart1.ChartAreas["ChartArea1"].AxisY.Title = titleY;
            chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Sans Serif", 10, FontStyle.Bold);
            chart1.ChartAreas["ChartArea1"].AxisX.Title = titleX;
            chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Sans Serif", 10, FontStyle.Bold);
            chart1.Invalidate();
        }

        private void SetPoints3()
        {
            var dataList = new List<DataForGraph3>();
            if (DataForGraph3.Deserialize(ref dataList))
            {
                dataList = dataList.OrderBy(x => x.priority).ToList();
                foreach (var elem in dataList)
                {
                    mySeries.Points.AddXY(elem.priority, elem.averagePauseTime);
                }
                chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1; // force to show each x axis label
                SetGraphAxisTitles("Priority", "Average pause time");
                chart1.Invalidate();
            }         
        }

        private void SetPoints2()
        {
            dataList = new List<DataForGraph1>();
            DataForGraph1.Deserialize(ref dataList);

            string xPoint = "";
            dataList = dataList.OrderBy(x => x.arisingTimeMin).ToList();
            foreach (var elem in dataList)
            {
                xPoint = elem.arisingTimeMin.ToString() + "-" + elem.arisingTimeMax.ToString();
                mySeries.Points.AddXY(xPoint, elem.processorFreePercent);
            }
            SetGraphAxisTitles("Arising time range", "Processor free percentage");
            chart1.Invalidate();
        }

        private void initChart()
        {
            chart1.Series.Clear();
            mySeries = new Series
            {
                Name = "mySeries",
                Color = System.Drawing.Color.RoyalBlue,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Spline, 
                BorderWidth = 3
            };

            chart1.Series.Add(mySeries);
            //chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
        }

        private void SetPoints1()
        {
            dataList = new List<DataForGraph1>();
            DataForGraph1.Deserialize(ref dataList);

            string xPoint = "";
            dataList = dataList.OrderBy(x => x.arisingTimeMin).ToList();
            foreach (var elem in dataList)
            {
                xPoint = elem.arisingTimeMin.ToString() + "-" + elem.arisingTimeMax.ToString();
                mySeries.Points.AddXY(xPoint, elem.averagePauseTime);
            }
            SetGraphAxisTitles("Arising time range", "Average pause time");
            chart1.Invalidate();
        }

    }
}
