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
    /// Logique d'interaction pour Acceuil.xaml
    /// </summary>
    public partial class Acceuil : Window
    {

        public Joueur joueur; 
        public Acceuil()
        {
            InitializeComponent();
            joueur = Gestion.getInstance().Joueur1;
            this.DataContext = joueur;
        }

        private void Duo(object sender, RoutedEventArgs e)
        {
            var windowSolo = new Joueur2(); 
            windowSolo.Show();
        }

        private void Ai(object sender, RoutedEventArgs e)
        {
            var windowAi = new AwaleAI(); 
            windowAi.Show();
        }

        private void host(object sender, RoutedEventArgs e)
        {
            var windowhost = new Heberger();
            windowhost.Show();
        }

        private void connect(object sender, RoutedEventArgs e)
        {
            var windowC = new Rejoindre();
            windowC.Show();
        }

        private void historique(object sender, RoutedEventArgs e)
        {
            var windowh = new Historique();
            windowh.Show();
        }
    }
}

