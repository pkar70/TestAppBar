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

namespace testAppBar
{

    public sealed partial class MainPage : Page
    {


        public MainPage()
        {
            this.InitializeComponent();
            (Application.Current as App).UnhandledException += GlobalError;
        }


        // breakpoint wstawiać na wąs (nawias) otwierający funkcję

        private void GlobalError(object sender, Windows.UI.Xaml.UnhandledExceptionEventArgs e)
        {
            // e.Handled = True    ' // prevent the application from crashing
            MsgBox("Global catch:");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void uiGlobe_Click(object sender, RoutedEventArgs e)
        {
            MsgBox("nacisniety GLOBE");
        }

        private void WcisnietoCzytaj(object sender, RoutedEventArgs e)
        {
            MsgBox("nacisniety jestem");
        }

        private void uiClicked(object sender, RoutedEventArgs e)
        {
            MsgBox("uiClicked");

            //CommandBar commandBar; // są tylko AppBar (nie ma Toggle) i tylko z SecondaryCommands
            //AppBar appBar;  // są buttony i działają, ale nie ma ikonek
            //AppBarButton appBarButton;
            //BitmapIcon oIcon;
            //WebView web;

            // 1.44.1: CommandBar, pokazuje w PrimaryCommands Label (dużą czcionką!), chyba że BitmapIcon, wtedy obrazek
            //          w dodatku Label moze byc bardzo szeroki, nie jest łamany dla zapewnienia szerokości
            // 1.45.0: CommandBar: pokazuje obrazek dla BitmapIcon lub nic dla innych Icon


            //uiWeb.NavigationCompleted += UiWeb_NavigationCompleted;
            uiWeb.NavigateToString("<html><body><p>test</body><html>");
            
        }

        //private void UiWeb_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        //{
        //    throw new NotImplementedException();
        //}
        private  void bEvent_Click(object sender, RoutedEventArgs e)
        {
            MsgBox("bEvent_Click");
        }
            private  void bBirth_Click(object sender, RoutedEventArgs e)
        {
            MsgBox("bBirth_Click");
        }
        private  void bDeath_Click(object sender, RoutedEventArgs e)
        {
            MsgBox("bDeath_Click");
        }
        private  void uiClicked1(object sender, RoutedEventArgs e)
        {

            uiWeb.NavigateToString("<html><body><p>test znacznei dluzszy</body><html>");

            //string sTmp;
            //sTmp = "<html><body>";
            ////for (int i = 0; i < 1000; i++)
            ////{
            ////    // uiCounter.Text = i.ToString();
            ////    System.Diagnostics.Debug.WriteLine("i=" + i.ToString());
            ////    string sLinia = "Linia " + i.ToString() + " ";
            ////    sTmp = sTmp + "<p>";
            ////    for (int j = 0; j < 100; j++)
            ////        sTmp = sTmp + sLinia;
            ////}
            //for (int i = 0; i < 1000; i++)
            //{
            //    // uiCounter.Text = i.ToString();
            //    string sLinia = "Linia " + i.ToString() + " ";
            //    sLinia = sLinia.PadRight(1000, 'x');
            //    sTmp = sTmp + "<p>" + sLinia;
            //}

            //sTmp += "</body></html>";
            //uiWeb.NavigateToString(sTmp);


        }

        private void MsgBox(string sMsg)
        {
            Windows.UI.Popups.MessageDialog oMsg = new Windows.UI.Popups.MessageDialog(sMsg);
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            oMsg.ShowAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

    }

}