using MoviesClientApp.View;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MoviesClientApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RootPage : Page
    {
        public RootPage(Frame frame)
        {
            this.InitializeComponent();
            MySplitView.Content = frame;
            (MySplitView.Content as Frame).Navigate(typeof(HomePage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame myFrame = this.MySplitView.Content as Frame;
            if (myFrame.CanGoBack)
            {
                myFrame.GoBack();
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Movies_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
