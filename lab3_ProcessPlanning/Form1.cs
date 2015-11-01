using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ProcessesPlanning
{
    public partial class Form1 : Form
    {
        public BindingList<Process> _processes;
        private BindingList<Result> results;
        private Random random;
        private bool programIsRunning;
        private int processId;
        private Stopwatch watch;

        private Thread generateProcessesThread;
        private Thread doProcessesThread;

        private int executionTimeMin;
        private int executionTimeMax;
        private int arisingTimeMin;
        private int arisingTimeMax;

        public Form1()
        {
            InitializeData();
            InitializeComponent();
            SetInitialValuesInControls();

            random = new Random();
            programIsRunning = false;
            processId = 0;
            bindingSourceProcesses.DataSource = _processes;
            dataGridViewProcesses.AutoGenerateColumns = true;
            dataGridViewProcesses.DataSource = bindingSourceProcesses;
            bindingSourceResults.DataSource = results;
            dataGridViewResults.DataSource = bindingSourceResults;
        }

        private void SetInitialValuesInControls()
        {
            maskedTextBoxExecutionTimeIntervalMin.Text = executionTimeMin.ToString();
            maskedTextBoxExecutionTimeIntervalMax.Text = executionTimeMax.ToString();
            maskedTextBoxArisingTimeIntervalMin.Text = arisingTimeMin.ToString();
            maskedTextBoxArisingTimeIntervalMax.Text = arisingTimeMax.ToString();
        }

        private void InitializeData()
        {
            _processes = new BindingList<Process>();
            results = new BindingList<Result>();

            executionTimeMin = 1;
            executionTimeMax = 10;
            arisingTimeMin = 0;
            arisingTimeMax = 10;
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (generateProcessesThread != null)
                if (generateProcessesThread.IsAlive)
                    generateProcessesThread.Abort();
            if (doProcessesThread != null)
                if (doProcessesThread.IsAlive)
                    doProcessesThread.Abort();

            buttonStop.Enabled = true;
            buttonStart.Enabled = false;
            programIsRunning = true;
            results.Clear();
            _processes.Clear();
            dataGridViewProcesses.Refresh();

            generateProcessesThread = new Thread(() => GenerateProcesses(_processes));
            generateProcessesThread.Start();
            doProcessesThread = new Thread(() => DoProcesses(_processes));
            doProcessesThread.Start();
        }

        private void DoProcesses(BindingList<Process> _processes)
        {
            while (programIsRunning || _processes.Count > 0)
            {
                if (_processes.Count > 0)
                {
                    List<Process> sortedProcesses = _processes.OrderBy(x => x.ExecutionTime).ToList();
                    sortedProcesses[0].Execute();
                    this.Invoke((Action)(() =>
                    {
                        results.First(x => x.ProcessId == sortedProcesses[0].Id).PauseTime = sortedProcesses[0].GetPauseTime();
                        results.First(x => x.ProcessId == sortedProcesses[0].Id).EndTime = watch.ElapsedMilliseconds;
                        _processes.Remove(_processes.First(x => x.Id == sortedProcesses[0].Id));
                        dataGridViewResults.Refresh();
                    }));   
                }
                //else 
                //    Thread.Sleep(50);
            }

        }

        private void GenerateProcesses(BindingList<Process> _processes)
        {
            watch = Stopwatch.StartNew();
            while (programIsRunning)
            {
                int arrivalTime = random.Next(arisingTimeMin, arisingTimeMax);
                Thread.Sleep(arrivalTime * 1000);
                int executionTime = random.Next(executionTimeMin, executionTimeMax) * 1000;
                Process current = new Process(++processId, watch.ElapsedMilliseconds, executionTime);
                Result currRes = new Result() { ProcessId = processId };
                this.Invoke((Action)(() =>
                {
                    _processes.Add(current);
                    results.Add(currRes);
                    dataGridViewProcesses.Refresh();
                }));              
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
            programIsRunning = false;
        }


#region ui masked textboxes validation
        private void maskedTextBoxExecutionTimeIntervalMin_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(maskedTextBoxExecutionTimeIntervalMin.Text, out executionTimeMin) == false)
                executionTimeMin = 0;
            else
            {
                if (executionTimeMin < 0 || executionTimeMin > 99)
                {
                    MessageBox.Show("Insert number between 0 and 100");
                }
                else if (executionTimeMax < executionTimeMin)
                {
                    MessageBox.Show("Wrong interval. min must be < max");
                    executionTimeMin = executionTimeMax;
                    maskedTextBoxExecutionTimeIntervalMin.Text = executionTimeMin.ToString();
                }
            }
        }

        private void maskedTextBoxExecutionTimeIntervalMax_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(maskedTextBoxExecutionTimeIntervalMax.Text, out executionTimeMax) == false)
                executionTimeMax = 0;
            else
            {
                if (executionTimeMax < 0 || executionTimeMax > 99)
                {
                    MessageBox.Show("Insert number between 0 and 100");
                }
                else if (executionTimeMax < executionTimeMin)
                {
                    MessageBox.Show("Wrong interval. max must be > min");
                    executionTimeMax = executionTimeMin;
                    maskedTextBoxExecutionTimeIntervalMax.Text = executionTimeMax.ToString();
                }
            }
        }

        private void maskedTextBoxArisingTimeIntervalMin_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(maskedTextBoxArisingTimeIntervalMin.Text, out arisingTimeMin) == false)
                arisingTimeMin = 0;
            else
            {
                if (arisingTimeMin < 0 || arisingTimeMin > 99)
                {
                    MessageBox.Show("Insert number between 0 and 100");
                }
                else if (arisingTimeMax < arisingTimeMin)
                {
                    MessageBox.Show("Wrong interval. min must be < max");
                    arisingTimeMin = arisingTimeMax;
                    maskedTextBoxArisingTimeIntervalMin.Text = arisingTimeMin.ToString();
                }
            }
        }

        private void maskedTextBoxArisingTimeIntervalMax_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(maskedTextBoxArisingTimeIntervalMax.Text, out arisingTimeMax) == false)
                arisingTimeMax = 0;
            else
            {
                if (arisingTimeMax < 0 || arisingTimeMax > 99)
                {
                    MessageBox.Show("Insert number between 0 and 100");
                }
                else if (arisingTimeMax < arisingTimeMin)
                {
                    MessageBox.Show("Wrong interval. max must be > min");
                    arisingTimeMax = arisingTimeMin;
                    maskedTextBoxArisingTimeIntervalMax.Text = arisingTimeMax.ToString();
                }
            }
        }
#endregion
    }
}
