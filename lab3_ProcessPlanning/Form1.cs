﻿using lab3_ProcessPlanning;
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
        private int priorityMin;
        private int priorityMax;
        private int processorFreeTime;
        private int processesAmount;

        private static Mutex mut = new Mutex();

        private List<DataForGraph> dataList;

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
            maskedTextBoxPriorityMin.Text = priorityMin.ToString();
            maskedTextBoxPriorityMax.Text = priorityMax.ToString();
            textBoxProcessesAmount.Text = processesAmount.ToString();
        }

        private void InitializeData()
        {
            _processes = new BindingList<Process>();
            results = new BindingList<Result>();
            dataList = new List<DataForGraph>();
            DataForGraph.Deserialize(ref dataList);

            executionTimeMin = 1;
            executionTimeMax = 10;
            arisingTimeMin = 0;
            arisingTimeMax = 10;
            priorityMin = 1;
            priorityMax = 3;
            processesAmount = 150;
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (generateProcessesThread != null)
                if (generateProcessesThread.IsAlive)
                    generateProcessesThread.Abort();
            if (doProcessesThread != null)
                if (doProcessesThread.IsAlive)
                    doProcessesThread.Abort();

            processId = 0;

            if (ValidateAll())
            {
                DataForGraph.Deserialize(ref dataList);
                processorFreeTime = 0;
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
        }

        private bool ValidateAll()
        {
            if (executionTimeMax < executionTimeMin)
            {
                MessageBox.Show("Wrong executionTime interval. min must be < max");
                return false;
            }
            if (arisingTimeMax < arisingTimeMin)
            {
                MessageBox.Show("Wrong arisingTime interval. min must be < max");
                return false;
            }
            if (priorityMax < priorityMin)
            {
                MessageBox.Show("Wrong interval. min must be < max");
                return false;
            }
            return true;
        }

        private void DoProcesses(BindingList<Process> _processes)
        {
            while (programIsRunning || _processes.Count > 0)
            {
                if (_processes.Count > 0)
                {
                    mut.WaitOne();
                    List<Process> sortedProcesses = _processes.OrderBy(x => x.Priority).ToList();
                    mut.ReleaseMutex();
                    sortedProcesses[0].Execute();
                    this.Invoke((Action) (() =>
                    {
                        results.First(x => x.ProcessId == sortedProcesses[0].Id).PauseTime =
                            sortedProcesses[0].GetPauseTime();
                        results.First(x => x.ProcessId == sortedProcesses[0].Id).EndTime = watch.ElapsedMilliseconds;
                        _processes.Remove(_processes.First(x => x.Id == sortedProcesses[0].Id));
                        dataGridViewResults.Refresh();
                    }));
                }
                else
                {
                    Thread.Sleep(10);
                    processorFreeTime += 10;
                }
                    
            }
            ActionsAfterProgramStops();
        }

        private void ActionsAfterProgramStops()
        {
            long averagePauseTime = CountAveragePauseTime();
            this.Invoke((Action)(() =>
            {
                labelAveragePauseTime.Text = averagePauseTime.ToString();
            }));
            double processorFreePercent = (processorFreeTime * 100) / results.Max(x => x.EndTime);
            if (dataList.Exists(x => x.arisingTimeMin == this.arisingTimeMin && x.arisingTimeMax == this.arisingTimeMax))
                dataList.Remove(
                    dataList.First(
                        x => x.arisingTimeMin == this.arisingTimeMin && x.arisingTimeMax == this.arisingTimeMax));
            dataList.Add(new DataForGraph()
            {
                arisingTimeMin = this.arisingTimeMin,
                arisingTimeMax = this.arisingTimeMax,
                averagePauseTime = averagePauseTime,
                processorFreePercent = processorFreePercent
            });
            DataForGraph.Serialize(dataList);
            MessageBox.Show("Done!");
        }

        private void GenerateProcesses(BindingList<Process> _processes)
        {
            watch = Stopwatch.StartNew();
            while (programIsRunning)
            {
                int arrivalTime = random.Next(arisingTimeMin, arisingTimeMax);
                Thread.Sleep(arrivalTime);
                int executionTime = random.Next(executionTimeMin, executionTimeMax) * 10;
                int priority = random.Next(priorityMin, priorityMax);
                Process current = new Process(++processId, watch.ElapsedMilliseconds, executionTime, priority);
                Result currRes = new Result() { ProcessId = processId };
                this.Invoke((Action)(() =>
                {
                    mut.WaitOne();
                    _processes.Add(current);
                    mut.ReleaseMutex();
                    results.Add(currRes);
                    dataGridViewProcesses.Refresh();
                }));
                if (processId >= processesAmount)
                    buttonStop_Click(this.buttonStop, new EventArgs());
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            this.Invoke((Action) (() =>
            {
                buttonStop.Enabled = false;
                buttonStart.Enabled = true;
                programIsRunning = false;
            }));           
        }

        private long CountAveragePauseTime()
        {
            int amountOfRes = 0;
            long allPauseTime = 0;
            foreach (var res in results)
            {
                if (res.EndTime != 0)
                {
                    amountOfRes++;
                    allPauseTime += res.PauseTime;
                }
            }
            if (amountOfRes > 0)
                return allPauseTime/amountOfRes;
            else
                return 0;
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
            }
        }

        private void maskedTextBoxArisingTimeIntervalMin_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(maskedTextBoxArisingTimeIntervalMin.Text, out arisingTimeMin) == false)
                arisingTimeMin = 0;
            else
            {
                if (arisingTimeMin < 0 || arisingTimeMin > 99999)
                {
                    MessageBox.Show("Insert number between 0 and 100");
                }
            }
        }

        private void maskedTextBoxArisingTimeIntervalMax_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(maskedTextBoxArisingTimeIntervalMax.Text, out arisingTimeMax) == false)
                arisingTimeMax = 0;
            else
            {
                if (arisingTimeMax < 0 || arisingTimeMax > 99999)
                {
                    MessageBox.Show("Insert number between 0 and 100");
                }
            }
        }

        private void maskedTextBoxPriorityMin_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(maskedTextBoxPriorityMin.Text, out priorityMin) == false)
                priorityMin = 0;
            else
            {
                if (priorityMin < 1 || priorityMin > 32)
                {
                    MessageBox.Show("Insert number between 1 and 32");
                }
            }
        }

        private void maskedTextBoxPriorityMax_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(maskedTextBoxPriorityMax.Text, out priorityMax) == false)
                priorityMax = 0;
            else
            {
                if (priorityMax < 1 || priorityMax > 32)
                {
                    MessageBox.Show("Insert number between 1 and 32");
                }
            }
        }

#endregion

        private void buttonGraph1_Click(object sender, EventArgs e)
        {
            Graph1 graph1 = new Graph1(1);
            graph1.ShowDialog();
        }

        private void buttonGraph2_Click(object sender, EventArgs e)
        {
            Graph1 graph1 = new Graph1(2);
            graph1.ShowDialog();
        }

        private void textBoxProcessesAmount_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBoxProcessesAmount.Text, out processesAmount) == false)
            {
                MessageBox.Show("Must be integer number");
            }
            else
            {
                if (processesAmount < 0)
                {
                    MessageBox.Show("Insert number above 0");
                }
            }
        }

        
    }
}
