﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Projet_Awale
{
    /// <summary>
    /// Logique d'interaction pour GuestGame.xaml
    /// </summary>

    public partial class GuestGame : Window, INotifyPropertyChanged
    {
        public String joueur1 { get; set; }

        public Boolean tour { get; set; }
        private int _score1;
        public int Score1
        {
            get { return _score1; }
            set { _score1 = value; NotifyPropertyChanged("Score1"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public String joueur2 { get; set; }
        private int _score2;
        public int Score2
        {
            get { return _score2; }
            set { _score2 = value; NotifyPropertyChanged("Score2"); }
        }
        public ObservableCollection<HoleControl> Plateau1 { get; set; }
        public ObservableCollection<HoleControl> Plateau2 { get; set; }

        public GuestGame()
        {
            InitializeComponent();
            Joueur j1 = Gestion.getInstance().Joueur1;
            Joueur j2 = Gestion.getInstance().Joueur2;
            joueur1 = j1.Nom;
            Score1 = j1.Score;
           // joueur2 = j2.Nom;
            Score2 = 0;
            tour =false; 
            Plateau1 = new ObservableCollection<HoleControl>();
            Plateau2 = new ObservableCollection<HoleControl>();
            for (int i = 6; i > 0; i--)
            {
                Plateau1.Add(new HoleControl());
                Plateau2.Add(new HoleControl());
            }
            this.DataContext = this;

        }




        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }



        private void ListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tour == true)
            {
                int i = Ennemy.SelectedIndex;
                int total = Plateau2[i].NbrBilles;
                Plateau2[i].Jouer();
                int j = -1;
                for (int k = total; k > 0; k--)
                {
                    i = i - 1;
                    if (i >= 0)
                    {
                        Plateau2[i].Distribuer();
                    }
                    else
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
                                MessageBox.Show("Vous avez a gagné");
                                this.Close();
                            }
                        }
                        else
                        {
                            i = 1;
                            j = -1;
                        }
                    }
                    Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    IPAddress target = IPAddress.Parse("127.0.0.1");
                    IPEndPoint ep = new IPEndPoint(target, 2323);

                    byte[] msg = Encoding.ASCII.GetBytes(i.ToString());
                    s.SendTo(msg, ep);
                    tour = false;
                }
            } else
            {
                UdpClient listener = new UdpClient(2323);
                IPAddress target = IPAddress.Parse("127.0.0.1");
                IPEndPoint ep = new IPEndPoint(target, 2323);

                try
                {
                    while (tour == false)
                    {
                      
                        byte[] bytes = listener.Receive(ref ep);

                     
                        tour = true;

                       String attack = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                        int a;
                        Int32.TryParse(attack, out a);
                        int total2 = Plateau1[a].NbrBilles;
                        Plateau1[a].Jouer();
                        int b = -1;
                        for (int k = total2; k > 0; k--)
                        {
                            a = a +1 ;
                            if (a > 6)
                            {
                                Plateau1[a].Distribuer();
                            }
                            else
                            {
                                b = b - 1;
                                if (b > 0)
                                {
                                    Plateau1[b].Distribuer();
                                    if (Plateau1[b].NbrBilles == 2)
                                    {
                                        Plateau1[b].NbrBilles = 0;
                                        this.Score1 = this.Score1 + 2;
                                    }
                                    else if (Plateau1[b].NbrBilles == 3)
                                    {
                                        Plateau1[b].NbrBilles = 0;
                                        this.Score1 = this.Score1 + 3;
                                    }

                                    if (Score1 > 24)
                                    {
                                        MessageBox.Show("Votre adversaire a gagné");
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    a = 0;
                                    b = -1;
                                }
                            }
                        }
                    }

                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1.ToString());
                }
                finally
                {
                    listener.Close();
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
