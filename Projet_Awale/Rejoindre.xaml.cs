using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
    /// Logique d'interaction pour Rejoindre.xaml
    /// </summary>
    public partial class Rejoindre : Window
    {
        public Rejoindre(string ip)
        {
            InitializeComponent();
            bool done = false;
            String result = "" ; 
            UdpClient listener = new UdpClient(2323);
            IPAddress target = IPAddress.Parse(ip);
            IPEndPoint ep = new IPEndPoint(target, 2323);
            Task.Run(() =>
            {
                try
                {
                    while (done == false)
                    {
                        Console.WriteLine("En attente d'une connexion");
                        byte[] bytes = listener.Receive(ref ep);

                        Console.WriteLine("Received broadcast from {0} :\n {1}\n",
                            ep.ToString(),
                            Encoding.ASCII.GetString(bytes, 0, bytes.Length));
                        result = Encoding.ASCII.GetString(bytes, 0, bytes.Length);

                        done = true;

                    }
                    if (done == true)
                    {
                        Dispatcher.Invoke(() =>
                        {
                            var windowhost = new HostGame(ip);
                            windowhost.Show();
                        });
                    
                        //     this.Close();
                    }




                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    listener.Close();
                }
            });
        }



    }
}
