using Grpc.Core;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GrpcService;
using grpcwpfserver.Services;

namespace grpcwpfserver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Server server;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            server = new Server()
            {
                Services = { GrpcService.Reciever.BindService(new RecieverService()) },
                Ports = { new ServerPort("localhost", 8099, ServerCredentials.Insecure) }
            };
            server.Start();
            SubtitleContent.Text = "gRPC Reciever started";
        }
    }
}
