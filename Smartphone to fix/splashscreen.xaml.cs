using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Smartphone_to_fix
{
    /// <summary>
    /// Interaction logic for splashscreen.xaml
    /// </summary>
    public partial class splashscreen : Window
    {
        DispatcherTimer dT = new DispatcherTimer();
        public splashscreen()
        {
            InitializeComponent();
            dT.Tick += new EventHandler(dT_Tick);
            dT.Interval = new TimeSpan(0, 0, 2);
            dT.Start();
            //Npg.Minimum = 0;
            //Npg.Maximum = 100;
        }
        private void dT_Tick(object sender, EventArgs e)
        {            
            MainWindow mw = new MainWindow();
            mw.Show();
            dT.Stop();
            this.Close();
            
        }
    }
}
