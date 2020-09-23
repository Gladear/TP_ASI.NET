using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ClientConvertisseurV2.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RootPage : Page
    {
        public RootPage(Frame frame)
        {
            InitializeComponent();
            RootSplitView.Content = frame;
            (RootSplitView.Content as Frame).Navigate(typeof(MainPage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            RootSplitView.IsPaneOpen = !RootSplitView.IsPaneOpen;
        }

        private void MenuButtonConvert_Click(object sender, RoutedEventArgs e)
        {
            (RootSplitView.Content as Frame).Navigate(typeof(MainPage));
        }

        private void MenuButtonReverse_Click(object sender, RoutedEventArgs e)
        {
            (RootSplitView.Content as Frame).Navigate(typeof(ReversePage));
        }
    }
}
