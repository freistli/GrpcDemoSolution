using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using GrpcNetStandardClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GrpcUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Templorarily accept any cert with below code for gRPC communication.
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

                var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
                {
                    
                HttpHandler = new GrpcWebHandler(handler)

                }) ; 

                var client = new Greeter.GreeterClient(channel);
                var response = await client.SayHelloAsync(new HelloRequest { Name = " UWP " });
                MyMessage.Text = response.Message;
            }
            catch (Exception ex)
            {
                MyMessage.Text = ex.ToString();
            }
        }
    }
}
