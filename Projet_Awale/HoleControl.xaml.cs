using System.Windows;
using System.Windows.Controls;

namespace Projet_Awale
{
    /// <summary>
    /// Logique d'interaction pour Hole.xaml
    /// </summary>
    public partial class HoleControl : UserControl
    {

        public static DependencyProperty NbrBillesProperty =
            DependencyProperty.Register("NbrBilles", typeof(int), typeof(HoleControl),
                new PropertyMetadata(new PropertyChangedCallback(NbrBillesPropertyChanged)));

       public int NbrBilles
        { get { return (int)GetValue(NbrBillesProperty); }
            set { SetValue(NbrBillesProperty,value); }
        } 
        public HoleControl()
        {
            InitializeComponent();
            NbrBilles = 4;
            this.DataContext = this; 

        }

        public static void NbrBillesPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HoleControl control = d as HoleControl;
            if (control !=null)
            {
                control.NbrBilles = (int)e.NewValue; 
            }


        }

        public void Jouer()
        {
            NbrBilles = 0;
        }

        public void Distribuer()
        {
            NbrBilles = NbrBilles + 1; 
        }

    }
}
