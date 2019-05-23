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
using System.Windows.Shapes;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        public Calculator()
        {
            InitializeComponent();
            MenuItemDarkTheme.IsChecked = true;
            DataContext = new CalculatorViewModel();
        }

        private void LightThemeClick(object sender, RoutedEventArgs e)
        {
            (App.Current as App).ChangeSkin(Skin.Light);

            MenuItemLightTheme.IsChecked = true;
            MenuItemDarkTheme.IsChecked = false;
            MenuItemBlueTheme.IsChecked = false;
        }

        private void DarkThemeClick(object sender, RoutedEventArgs e)
        {
            (App.Current as App).ChangeSkin(Skin.Dark);

            MenuItemLightTheme.IsChecked = false;
            MenuItemDarkTheme.IsChecked = true;
            MenuItemBlueTheme.IsChecked = false;
        }

        private void BlueThemeClick(object sender, RoutedEventArgs e)
        {
            (App.Current as App).ChangeSkin(Skin.Blue);

            MenuItemLightTheme.IsChecked = false;
            MenuItemDarkTheme.IsChecked = false;
            MenuItemBlueTheme.IsChecked = true;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void WindowBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


    }
}
