using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.ComponentModel;

namespace Projet_Awale
{
    /// <summary>
    /// Logique d'interaction pour Awale.xaml
    /// </summary>
    public partial class Awale : Window , INotifyPropertyChanged
    {
        public String joueur1 { get; set; }

        private int _score1;
        public int Score1
        {
            get { return _score1; }
            set { _score1 = value; NotifyPropertyChanged("Score1"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
      
      //  public int Score1 { get; set; }
        public String joueur2 { get; set; }
        // public int Score2 { get; set; }
        private int _score2;
        public int Score2
        {
            get { return _score2; }
            set { _score2 = value; NotifyPropertyChanged("Score2"); }
        }
        public ObservableCollection<HoleControl> Plateau1 { get; set; }
        public ObservableCollection<HoleControl> Plateau2 { get; set; }

        public Awale()
        {
            InitializeComponent();
            Joueur j1 = Gestion.getInstance().Joueur1;
            Joueur j2 = Gestion.getInstance().Joueur2;
            joueur1 = j1.Nom;
            Score1 = j1.Score;
            joueur2 = j2.Nom;
            Score2 = j2.Score;
            Plateau1 = new ObservableCollection<HoleControl>();
            Plateau2 = new ObservableCollection<HoleControl>();
            for (int i=6; i>0; i--)
            {
                Plateau1.Add(new HoleControl());
                Plateau2.Add(new HoleControl());
            }
            this.DataContext = this;

        }



        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = Me.SelectedIndex;
            int total = Plateau1[i].NbrBilles; 
            Plateau1[i].Jouer();
            int j = 6;
            for (int k = total; k > 0; k--)
            {
                i = i + 1;
                if (i < 6)
                {
                    Plateau1[i].Distribuer();
                }
                else
                {
                    j = j - 1;
                    if (j < 6 && j>-1)
                    {
                        Plateau2[j].Distribuer();
                        if (Plateau2[j].NbrBilles == 2)
                        {
                            Plateau2[j].NbrBilles = 0;
                            this.Score1 = this.Score1 + 2;
                        }
                        else if (Plateau2[j].NbrBilles == 3)
                        {
                            Plateau2[j].NbrBilles = 0;
                            this.Score1 = this.Score1 + 3;
                        }
                        if (Score1 > 24)
                        {
                            MessageBox.Show(joueur1 + " a gagné");
                            this.Close();
                        }
                    }
                    else
                    {
                        i = 1;
                        j = -1;
                    }
                }
            }
        }


        private void ListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = Ennemy.SelectedIndex;
            int total = Plateau2[i].NbrBilles;
            Plateau2[i].Jouer();
            int j = -1;
            for (int k = total; k > 0; k--)
            {
                i = i - 1;
                if (i >= 0) { 
                Plateau2[i].Distribuer();
                } else
                {
                    j = j + 1;
                    if (j < 6)
                    {
                        Plateau1[j].Distribuer();
                        if (Plateau1[j].NbrBilles == 2)
                        {
                            Plateau1[j].NbrBilles = 0;
                            this.Score2 = this.Score2 + 2;
                        }
                        else if (Plateau1[j].NbrBilles == 3)
                        {
                            Plateau1[j].NbrBilles = 0;
                            this.Score2 = this.Score2 + 3;
                        }

                        if (Score2 > 24)
                        {
                            MessageBox.Show(joueur2 + " a gagné");
                            this.Close();
                        }
                    } else
                    {
                        i=1 ;
                        j = -1;
                    }
                }
            }
        }

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
