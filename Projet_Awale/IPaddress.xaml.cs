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

namespace Projet_Awale
{
    /// <summary>
    /// Logique d'interaction pour IPaddress.xaml
    /// </summary>
    public partial class IPaddress : Window
    {
        public string ip { get; set; }
        public string type { get; set; }
        public IPaddress(String g)
        {
            InitializeComponent();
            type = g;
            this.DataContext = this;
        }

        private void Start(object sender, RoutedEventArgs e)
        {

            Console.WriteLine(ip);

            if (type == "1")
            {
                var window = new Heberger(ip); //create your new form.
                window.Show();
            }
            else
            {
                var window = new Rejoindre(ip); //create your new form.
                window.Show();
            }
            this.Close();
        }
    }
}
