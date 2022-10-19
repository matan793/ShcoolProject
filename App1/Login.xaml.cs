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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        bool us = false;
        bool ps = false;
        public Login()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
        }

        private void playBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void username_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(username.Text != "")
                us = true;
            else
            us = false;
            if(us && ps)
                loginbtn.IsEnabled = true;
            else
                loginbtn.IsEnabled = false;
        }

        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (password.Text != "")
                ps = true;
            else
                ps = false;
            if (us && ps)
                loginbtn.IsEnabled = true;
            else
                loginbtn.IsEnabled = false;

        }

        private void Quitbtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Register));
        }

        private void TextBlock_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 0);
        }

        private void TextBlock_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 0);
        }
    }
}
