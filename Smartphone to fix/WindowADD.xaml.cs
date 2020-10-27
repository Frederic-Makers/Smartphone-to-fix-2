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

namespace Smartphone_to_fix
{
    /// <summary>
    /// Interaction logic for WindowADD.xaml222
    /// </summary>
    public partial class WindowADD : Window
    {
        public WindowADD()
        {
            InitializeComponent();
        }
        private void Benvoyer_Click(object sender, RoutedEventArgs e)
        {
            ReparationPhone client = new ReparationPhone(Nnom.Text, Nprenom.Text, Nmobile.Text, NmobileModel.Text, Nemail.Text, NdateRecue.Text, Nstatus.Text, Ncout.Text, Ndescription.Text);
            Buisness.clients.Add(client);
            this.Close();
        }

        private void Envoye_Click(object sender, RoutedEventArgs e)
        {
            ReparationPhone client = new ReparationPhone(Nnom.Text, Nprenom.Text, Nmobile.Text, NmobileModel.Text, Nemail.Text, NdateRecue.Text, Nstatus.Text, Ncout.Text, Ndescription.Text);
            Buisness.clients.Add(client);
            Nprenom.Text = "";
            Nnom.Text = "";
            Nmobile.Text = "";
            NmobileModel.Text = "";
            Nemail.Text = "";
            NdateRecue.Text = "";
            Nstatus.Text = "";           
            Ndescription.Text = "";
            Ncout.Text = "";
        }
    }
}
