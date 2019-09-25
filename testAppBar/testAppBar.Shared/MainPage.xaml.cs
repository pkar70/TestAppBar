using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace testAppBar
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

        private void uiClicked(object sender, RoutedEventArgs e)
        {
            // tylko po to, by móc złapać w trakcie działania do testowania
            int i;
            i = 10;
            CommandBar commandBar; // są tylko AppBar (nie ma Toggle) i tylko z SecondaryCommands
            AppBar appBar;  // są buttony i działają, ale nie ma ikonek
            AppBarButton appBarButton;
            BitmapIcon oIcon;
            WebView web;

            // 1.44.1: CommandBar, pokazuje w PrimaryCommands Label (dużą czcionką!), chyba że BitmapIcon, wtedy obrazek
            //          w dodatku Label moze byc bardzo szeroki, nie jest łamany dla zapewnienia szerokości
            // 1.45.0: CommandBar: pokazuje obrazek dla BitmapIcon lub nic dla innych Icon

            uiWeb.NavigateToString("<html><body><p>test</body><html>");

        }
        private async void uiClicked1(object sender, RoutedEventArgs e)
        {
            string sTmp;
            sTmp = "<html><body>";
            for(int i = 0; i<1000; i++)
            {
                // uiCounter.Text = i.ToString();
                System.Diagnostics.Debug.WriteLine("i=" + i.ToString());
                string sLinia = "Linia " + i.ToString() + " ";
                sTmp = sTmp + "<p>";
                for (int j = 0; j < 100; j++)
                    sTmp = sTmp + sLinia;
            }
            sTmp += "</body></html>";
            uiWeb.NavigateToString(sTmp);
        }
    }
}
