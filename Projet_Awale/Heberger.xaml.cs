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
    /// Logique d'interaction pour Heberger.xaml
    /// </summary>
    public partial class Heberger : Window
    {
        public Heberger()
        {
            InitializeComponent();

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress target = IPAddress.Parse("127.0.0.1");
            IPEndPoint ep = new IPEndPoint(target, 2323);

            byte[] msg = Encoding.ASCII.GetBytes("Test");
            s.SendTo(msg, ep);
                    var windowhost = new GuestGame();

                    
                    windowhost.Show();
                  //  this.Close();
        

    }
    }
}
