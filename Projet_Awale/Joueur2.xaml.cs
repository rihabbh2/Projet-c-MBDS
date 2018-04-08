
using System.Windows;


namespace Projet_Awale
{
    /// <summary>
    /// Logique d'interaction pour Joueur2.xaml
    /// </summary>
    public partial class Joueur2 : Window
    {
        public Joueur joueur2;
        public Joueur2()
        {
            InitializeComponent();
            joueur2 = new Joueur();
            this.DataContext = joueur2;
        }


        private void Start(object sender, RoutedEventArgs e)
        {
            Gestion.getInstance().setJoueur2(joueur2);
            var window =  new Awale(); //create your new form.
            window.Show();
            this.Close();
        }

    }
}
