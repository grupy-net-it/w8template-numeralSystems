using System;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace NumeralSystems
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new ViewModel();

            (DataContext as ViewModel).Reset();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void OneButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (DataContext as ViewModel).Binary += '1';
        }

        private void ZeroButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (DataContext as ViewModel).Binary += '0';
        }

        private void ClearButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            (DataContext as ViewModel).Reset();
        }
    }
}
