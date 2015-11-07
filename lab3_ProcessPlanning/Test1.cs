using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3_ProcessPlanning
{
    public partial class Test1 : Form
    {
        public int ArisingTimeMax;
        public int ArisingTimeMin;
        public int Step;

        public Test1()
        {
            InitParams();
            InitializeComponent();
            SetInitialValuesInControls();
        }

        private void SetInitialValuesInControls()
        {
            maskedTextBoxArisingTimeIntervalMin.Text = ArisingTimeMin.ToString();
            maskedTextBoxArisingTimeIntervalMax.Text = ArisingTimeMax.ToString();
            textBoxStep.Text = Step.ToString();
        }

        private void InitParams()
        {
            ArisingTimeMin = 10;
            ArisingTimeMax = 100;
            Step = 10;
        }

        

    #region ui texboxes handling

        private void textBoxStep_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBoxStep.Text, out Step) == false)
            {
                MessageBox.Show("Must be integer number");
            }
            else
            {
                if (Step < 0)
                {
                    MessageBox.Show("Insert number above 0");
                }
                else if (Step >= ArisingTimeMax - ArisingTimeMin)
                {
                    MessageBox.Show("Step not valid!");
                }
            }
        }

        private void maskedTextBoxArisingTimeIntervalMax_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(maskedTextBoxArisingTimeIntervalMax.Text, out ArisingTimeMax) == false)
                ArisingTimeMax = 0;
            else
            {
                if (ArisingTimeMax < 0 || ArisingTimeMax > 99999)
                {
                    MessageBox.Show("Insert number between 0 and 99999");
                }
            }
        }

        private void maskedTextBoxArisingTimeIntervalMin_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(maskedTextBoxArisingTimeIntervalMin.Text, out ArisingTimeMin) == false)
                ArisingTimeMin = 0;
            else
            {
                if (ArisingTimeMin < 0 || ArisingTimeMin > 99999)
                {
                    MessageBox.Show("Insert number between 0 and 100");
                }
            }
        }

    #endregion

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
