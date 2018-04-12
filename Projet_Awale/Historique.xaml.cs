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
using System.IO;


namespace Projet_Awale
{
    /// <summary>
    /// Logique d'interaction pour Historique.xaml
    /// </summary>
    public partial class Historique : Window
    {
    public String historique { get; set; }
    public String path { get; set; }

        public Historique()
        {
            InitializeComponent();
            String path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Score.txt");
            historique = System.IO.File.ReadAllText(@path);
            this.DataContext = this;
        }
    }
}
