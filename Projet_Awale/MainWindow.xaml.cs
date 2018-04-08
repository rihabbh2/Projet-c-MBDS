using System.Windows;


namespace Projet_Awale
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Joueur joueur; 

        public MainWindow()
        {
            InitializeComponent();
            joueur = new Joueur() ;
            this.DataContext = joueur; 
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            Gestion.getInstance().setJoueur1(joueur);
            var window = new Acceuil(); //create your new form.
            window.Show();
            this.Close();
        }

    }
}
