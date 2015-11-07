using lab3_ProcessPlanning;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessesPlanning
{
    public partial class Form1 : Form
    {
        public BindingList<Process> _processes;
        private BindingList<Result> results;
        private Random random;
        private bool programIsRunning;
        private bool workDone;
        private bool test1Running;
        private bool test2Running;
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

        private List<DataForGraph1> dataList;

        public Form1()
        {
            InitializeData();
            InitializeComponent();

            random = new Random();
            programIsRunning = false;
            processId = 0;
            bindingSourceProcesses.DataSource = _processes;
            dataGridViewProcesses.AutoGenerateColumns = true;
            dataGridViewProcesses.DataSource = bindingSourceProcesses;
            bindingSourceResults.DataSource = results;
            dataGridViewResults.DataSource = bindingSourceResults;          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshValuesInControls();
        }

        private void RefreshValuesInControls()
        {
            this.Invoke((Action)(() =>
            {
                maskedTextBoxExecutionTimeIntervalMin.Text = executionTimeMin.ToString();
                maskedTextBoxExecutionTimeIntervalMax.Text = executionTimeMax.ToString();
                maskedTextBoxArisingTimeIntervalMin.Text = arisingTimeMin.ToString();
                maskedTextBoxArisingTimeIntervalMax.Text = arisingTimeMax.ToString();
                maskedTextBoxPriorityMin.Text = priorityMin.ToString();
                maskedTextBoxPriorityMax.Text = priorityMax.ToString();
                textBoxProcessesAmount.Text = processesAmount.ToString();
            }));           
        }

        private void InitializeData()
        {
            _processes = new BindingList<Process>();
            results = new BindingList<Result>();
            dataList = new List<DataForGraph1>();
            //DataForGraph1.Deserialize(ref dataList);

            executionTimeMin = 5;
            executionTimeMax = 10;
            arisingTimeMin = 10;
            arisingTimeMax = 20;
            priorityMin = 1;
            priorityMax = 15;
            processesAmount = 150;
        }

        private void RunTest1(int min, int max, int step)
        {
            test1Running = true;
            test2Running = false;

            for (int i = min; i <= max - step; i+=step)
            {
                workDone = false;

                arisingTimeMin = i;
                arisingTimeMax = i + step;
                RefreshValuesInControls();
                RunApp();

                while (true)
                {
                    if (!programIsRunning && workDone)
                        break;
                    else
                        Thread.Sleep(100);
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            DataForGraph1.Deserialize(ref dataList);
            RunApp();
        }

        private void RunApp()
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
                //DataForGraph1.Deserialize(ref dataList);
                processorFreeTime = 0;
                programIsRunning = true;
                
                this.Invoke((Action) (() =>
                {
                    results.Clear();
                    _processes.Clear();
                    buttonStop.Enabled = true;
                    buttonStart.Enabled = false;
                    dataGridViewProcesses.Refresh();
                }));
                                               
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
            if (test1Running)
                CreateGraph1Data();
            if (test2Running)
                CreateGraph3Data();
            if (!test2Running && !test1Running)
            {
                CreateGraph1Data();
                CreateGraph3Data();
            }
            workDone = true;
            //MessageBox.Show("Done!");
        }

        private void CreateGraph3Data()
        {
            var dataList = new List<DataForGraph3>();
            var groupedResults = results.GroupBy(x => x.ProcessPriority).Select(grp => grp.ToList()).ToList();
            foreach (var grp in groupedResults)
            {
                int amountOfRes = 0;
                long allPauseTime = 0;
                
                foreach (var res in grp)
                {
                    if (res.EndTime != 0)
                    {
                        amountOfRes++;
                        allPauseTime += res.PauseTime;
                    }
                }
                if (amountOfRes > 0)
                {
                    long averagePauseTime = allPauseTime / amountOfRes;
                    dataList.Add(new DataForGraph3()
                    {
                        averagePauseTime = averagePauseTime, 
                        priority = grp[0].ProcessPriority
                    });
                }
            }
            DataForGraph3.Serialize(dataList);
        }

        private void CreateGraph1Data()
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
            dataList.Add(new DataForGraph1()
            {
                arisingTimeMin = this.arisingTimeMin,
                arisingTimeMax = this.arisingTimeMax,
                averagePauseTime = averagePauseTime,
                processorFreePercent = processorFreePercent
            });
            DataForGraph1.Serialize(dataList);
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
                Result currRes = new Result() { ProcessId = processId, ProcessPriority = priority };
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


        private void inputFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graph1 graph1 = new Graph1(1);
            graph1.ShowDialog();
        }

        private void processorFreeTimePercentageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graph1 graph2 = new Graph1(2);
            graph2.ShowDialog();
        }

        private void prioritiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graph1 graph3 = new Graph1(3);
            graph3.ShowDialog();
        }

        private void runTestSet1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test1 test1 = new Test1();
            var result = test1.ShowDialog();
            if (result == DialogResult.OK)
            {                
                Thread Test1Thread = new Thread(() => RunTest1(test1.ArisingTimeMin, test1.ArisingTimeMax, test1.Step));
                Test1Thread.Start();
            }
        }

        private void runTest2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            test2Running = true;
            test1Running = false;

            priorityMin = 1;
            priorityMax = 32;
            arisingTimeMin = 15;
            arisingTimeMax = 15;
            executionTimeMin = 15;
            executionTimeMax = 20;

            RefreshValuesInControls();
            RunApp();
        }
        
    }
}
