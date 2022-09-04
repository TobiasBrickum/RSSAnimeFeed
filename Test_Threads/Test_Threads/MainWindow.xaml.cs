using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test_Threads
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread trd;

        public MainWindow()
        {
            InitializeComponent();

            trd = new Thread(new ThreadStart(this.ThreadTask));
            trd.IsBackground = true;
            trd.Start();
        }

        //RoutedEventArgs
        public void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is the main thread");
        }

        public void Form1_Load(object sender, System.EventArgs e)
        {
            Thread trd = new Thread(new ThreadStart(this.ThreadTask));
            trd.IsBackground = true;
            trd.Start();
        }

        public void ThreadTask()
        {
            double stp;
            double newval;
            Random rnd = new Random();

            while (true)
            {
                stp = progressBar1.Value; //* rnd.Next(-1, 2);
                /* -.-
                 * System.InvalidOperationException: 'Der aufrufende Thread kann nicht auf dieses 
                 * Objekt zugreifen, da sich das Objekt im Besitz eines anderen Threads befindet.'
                 */
                newval = this.progressBar1.Value + stp;
                if (newval > this.progressBar1.Maximum)
                    newval = this.progressBar1.Maximum;
                else if (newval < this.progressBar1.Minimum)
                    newval = this.progressBar1.Minimum;
                this.progressBar1.Value = newval;
                Thread.Sleep(100);
            }
        }

  
    }
}
