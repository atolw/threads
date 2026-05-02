namespace WindowsFormsThreadingApp
{
    public partial class MainForm : Form
    {
        private int[] numbers = new int[10000];
        private int max;
        private int min;
        private double average;

        private Button btnStart;
        private Label lblResults;

        public MainForm()
        {
            InitializeComponent();
        }
                      

        private void BtnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            lblResults.Text = "Триває обчислення та запис у файл...";


            Thread mainWorker = new Thread(ProcessData);
            mainWorker.IsBackground = true;
            mainWorker.Start();
        }

        private void ProcessData()
        {

            Random rand = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next(1, 100000);
            }


            Thread maxThread = new Thread(() => { max = numbers.Max(); });
            Thread minThread = new Thread(() => { min = numbers.Min(); });
            Thread avgThread = new Thread(() => { average = numbers.Average(); });

            maxThread.Start();
            minThread.Start();
            avgThread.Start();

            maxThread.Join();
            minThread.Join();
            avgThread.Join();

            // Потік для файлу (Завдання 5)
            Thread fileThread = new Thread(WriteToFile);
            fileThread.Start();
            fileThread.Join();

            // Оновлення інтерфейсу (вимагає Invoke, оскільки ми в іншому потоці)
            this.Invoke((MethodInvoker)delegate
            {
                lblResults.Text = $"Максимум: {max}\n" +
                                  $"Мінімум: {min}\n" +
                                  $"Середнє арифметичне: {average:F2}\n\n" +
                                  $"Дані збережено у файл 'results_gui.txt'!";
                btnStart.Enabled = true;
            });
        }

        private void WriteToFile()
        {
            string filePath = "results_gui.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Максимум: {max}");
                writer.WriteLine($"Мінімум: {min}");
                writer.WriteLine($"Середнє арифметичне: {average:F2}");
                writer.WriteLine(new string('-', 30));
                writer.WriteLine("Масив чисел:");
                writer.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
