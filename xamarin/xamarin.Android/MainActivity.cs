using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace xamarin.Droid
{
    [Activity(Label = "xamarin", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());


            // przygotowanie stringu
            string sTmp;
            sTmp = "<html><body>";
            for (int i = 0; i < 1000; i++)
            {
                string sLinia = "Linia " + i.ToString() + " ";
                sLinia = sLinia.PadRight(1000, 'x');
                sTmp = sTmp + "<p>" + sLinia;
            }
            sTmp += "</body></html>";

            Android.Webkit.WebView _webView;
            _webView = new Android.Webkit.WebView(getApplicationContext());

            _webView.SetWebViewClient(new InternalClient(_webView));
            //_webView.SetWebChromeClient(new InternalWebChromeClient());
            _webView.Settings.JavaScriptEnabled = true;
            _webView.Settings.DomStorageEnabled = true;
            _webView.Settings.BuiltInZoomControls = true;
            _webView.Settings.DisplayZoomControls = false;
            _webView.Settings.SetSupportZoom(true);
            _webView.Settings.LoadWithOverviewMode = true;
            _webView.Settings.UseWideViewPort = true;

            _webView.LoadData(sTmp, "text/html; charset=utf-8", "utf-8");

            //oAV.NavigateToString(sTmp);



        }
    }

    class InternalClient : Android.Webkit.WebViewClient
    {
        private readonly Android.Webkit.WebView _webView;
        //This is because we go through onReceivedError() and OnPageFinished() when the call fail.
        private bool _webViewSuccess = true;
        //This is to not have duplicate event call
        //private Android.Webkit.WebErrorStatus _webErrorStatus = Android.Webkit.WebErrorStatus.Unknown;
        public InternalClient(Android.Webkit.WebView webView)
        {
            _webView = webView;
            //SetLayerType disables hardware acceleration for a single view.
            //This is required to remove glitching issues particularly when having a keyboard pop-up with a webview present.
            //http://developer.android.com/guide/topics/graphics/hardware-accel.html
            //http://stackoverflow.com/questions/27172217/android-systemui-glitches-in-lollipop
            _webView.SetLayerType(LayerType.Software, null);
        }

        public override void OnPageFinished(Android.Webkit.WebView view, string url)
        {
            //_webView.OnNavigationHistoryChanged();

            //var args = new WebViewNavigationCompletedEventArgs()
            //{
            //    IsSuccess = _webViewSuccess,
            //    Uri = new Uri(url),
            //    WebErrorStatus = _webErrorStatus
            //};

            //_webView.NavigationCompleted?.Invoke(_webView, args);
            base.OnPageFinished(view, url);
        }
    }
}