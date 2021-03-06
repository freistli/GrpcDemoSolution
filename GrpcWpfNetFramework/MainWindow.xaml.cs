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
using GrpcNetStandardClass;
using Grpc.Core;
using Grpc.Net.Client;
using System.Net.Http;
using GrpcService;

namespace GrpcWpfNetFramework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
                
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
                {
                    HttpHandler = new WinHttpHandler()
                });

                var client = new Greeter.GreeterClient(channel);
                var response = await client.SayHelloAsync(new HelloRequest { Name = ".NET Framework" });
                MyMessage.Text = response.Message;
            }
            catch (Exception ex)
            {
                MyMessage.Text = ex.ToString();
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var channel2 = GrpcChannel.ForAddress("http://localhost:8099");

                var client2 = new Reciever.RecieverClient(channel2);

                while (true)
                {
                    var response2 = await client2.ShowSubtitleAsync(new Subtitle { Message = "test" });

                    if (MyMessage.Text != response2.Message)
                    {
                        MyMessage.Text = response2.Message;
                    }
                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                MyMessage.Text = ex.ToString();
            }
        }
    }
}
