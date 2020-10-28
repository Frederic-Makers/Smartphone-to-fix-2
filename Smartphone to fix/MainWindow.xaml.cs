using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
using System.IO;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Reflection.Emit;

namespace Smartphone_to_fix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml44161414
    /// </summary>
    /// 
    //COCOCHANEL
    public partial class MainWindow : Window
    {
        public String savefile = null;
        public MainWindow()
        {
            InitializeComponent();
            this.Closed += MainWindow_Closed;
            settimer();

            Mygrid.ItemsSource = Buisness.clients;
            if (Nautosave.IsChecked == true)
            {
                try
                {
                    String[] importfile = File.ReadAllLines("./autosave.csv");
                    openCSVfile(importfile, Mygrid);
                }
                catch (Exception)
                {
                    File.WriteAllText("./autosave.csv", toCSV(Mygrid));
                }
            }
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            exitfunction();
        }

        private void settimer()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Mygrid.ItemsSource = Buisness.clients;
            File.WriteAllText("./autosave-auto.csv", toCSV(Mygrid));
        }

        private void newClient_Click(object sender, RoutedEventArgs e)
        {
            Buisness.addWindown.Show();
        }

        private void addCase_Click(object sender, RoutedEventArgs e)
        {
            ReparationPhone client = new ReparationPhone("", "", "", "", "", "", "", "", "");
            Buisness.clients.Add(client);
        }

        private void exiter_Click(object sender, RoutedEventArgs e)
        {
            exitfunction();

        }
        public void exitfunction()
        {
            Application.Current.Shutdown();

            if (Nautosave.IsChecked == true)
            {
                Mygrid.ItemsSource = Buisness.clients;
                File.WriteAllText("./autosave.csv", toCSV(Mygrid));
            }
            else
            {
                Mygrid.ItemsSource = Buisness.clients;
                Buisness.clients.Clear();
                File.WriteAllText("./autosave.csv", toCSV(Mygrid));
            }
        } 

        private void new_Click(object sender, RoutedEventArgs e)
        {
            Buisness.clients.Clear();
            Mygrid.ItemsSource = Buisness.clients;
            this.savefile = null;
            Nsaveto.Content = "Non-enregistrer";
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Format (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                Buisness.clients.Clear();
                String[] importfile = File.ReadAllLines(openFileDialog.FileName);      
                openCSVfile(importfile, Mygrid);
            }
            this.savefile = openFileDialog.FileName;
            Nsaveto.Content = "localisation du fichier: " + this.savefile;
        }

        public static void openCSVfile(String[] importfile, DataGrid dg)
        {
            int tailleTab = importfile.Length;
            for (int i = 0; i < tailleTab; i++)
            {
                String ligne = importfile[i];
                String[] morceau = ligne.Split(',');               
                String nom = morceau[0];
                String prenom = morceau[1];
                String contact = morceau[2];
                String modelPhone = morceau[3];
                String email = morceau[4];
                String dateRecue = morceau[5];
                String status = morceau[6];
                String prix = morceau[7];
                String description = morceau[8];
                
                Buisness.clients.Add(new ReparationPhone(nom, prenom, contact, modelPhone, email, dateRecue, status, prix, description));
            }
           dg.ItemsSource = Buisness.clients;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Format (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, toCSV(Mygrid));
                savefile = saveFileDialog.FileName;
            } 
            
            if (this.savefile != null)
            {
                Nsaveto.Content = "localisation du fichier: " + this.savefile;
            }
        }
        public static String save(DataGrid dg, String savefile)
        {
            if(savefile == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV Format (*.csv)|*.csv";
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, toCSV(dg));
                    savefile = saveFileDialog.FileName;
                } 
            }
            else
            {
                File.WriteAllText(savefile, toCSV(dg));
            }
            return savefile;
        }
        private static String toCSV(DataGrid dg)
        {
            dg.ItemsSource = Buisness.clients;
            dg.SelectAllCells();
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
            ApplicationCommands.Copy.Execute(null, dg);
            dg.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);

            return result;
        }

        private void newCSV_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Format (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                String[] importfile = File.ReadAllLines(openFileDialog.FileName);
                openCSVfile(importfile, Mygrid);
            }
        }

        private void saver_Click(object sender, RoutedEventArgs e)
        {
            this.savefile = save(Mygrid, this.savefile);
            if (this.savefile != null)
            {
                Nsaveto.Content = "localisation du fichier: " + this.savefile;
            }
        }

        private void openAutotimer_Click(object sender, RoutedEventArgs e)
        {
            Buisness.clients.Clear();
            String[] importfile = File.ReadAllLines("./autosave-auto.csv");
            openCSVfile(importfile, Mygrid);
        }

        private void print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(Mygrid, "Grid Printing.");
            if (printDlg.ShowDialog() == true)
            {
                printDlg.PrintVisual(Mygrid, "Grid printing");
            }
        }

        private void CATotale_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RepEnCour_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RepTerminer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

