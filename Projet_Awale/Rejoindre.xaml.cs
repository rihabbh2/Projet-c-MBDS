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
        public Rejoindre()
        {
            InitializeComponent();
            UdpClient listener = new UdpClient(2323);
            IPAddress target = IPAddress.Parse("127.0.0.1");
            IPEndPoint ep = new IPEndPoint(target, 2323);

            byte[] bytes = listener.Receive(ref ep);
            String msg = Encoding.ASCII.GetString(bytes, 0, bytes.Length);

            Console.WriteLine(msg);


        }

    }
}
