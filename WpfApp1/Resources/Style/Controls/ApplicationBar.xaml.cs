using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp1.Resources.Style.Controls
{
    /// <summary>
    /// Interaction logic for ApplicationBar.xaml
    /// </summary>
    public partial class ApplicationBar : UserControl
    {
        public ApplicationBar()
        {
            InitializeComponent();
        }

        
        #region Drag
        public static readonly RoutedEvent MyButtonDownEvent =
            EventManager.RegisterRoutedEvent("MyButtonDown", RoutingStrategy.Bubble,
            typeof(MouseButtonEventHandler), typeof(ApplicationBar));

        public event MouseButtonEventHandler Drag
        {
            add { AddHandler(MyButtonDownEvent, value); }
            remove { RemoveHandler(MyButtonDownEvent, value); }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RaiseEvent(new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton)
            {
                RoutedEvent = MyButtonDownEvent
            });
        }
        #endregion


        #region Close Button
        public static readonly RoutedEvent CloseEvent =
            EventManager.RegisterRoutedEvent("CloseClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(ApplicationBar));

        public event RoutedEventHandler CloseClick
        {
            add { AddHandler(CloseEvent, value); }
            remove { RemoveHandler(CloseEvent, value); }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(CloseEvent));
        }
        #endregion  

        #region Minimize Button
        public static readonly RoutedEvent MinimizeEvent =
            EventManager.RegisterRoutedEvent("MinimizeClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(ApplicationBar));

        public event RoutedEventHandler MinimizeClick
        {
            add { AddHandler(MinimizeEvent, value); }
            remove { RemoveHandler(MinimizeEvent, value); }
        }
       
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(MinimizeEvent));
        }
        #endregion

        #region Maximize Button
        public static readonly RoutedEvent MaximizeEvent =
            EventManager.RegisterRoutedEvent("MaximizeClick", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(ApplicationBar));

        public event RoutedEventHandler MaximizeClick
        {
            add { AddHandler(MaximizeEvent, value); }
            remove { RemoveHandler(MaximizeEvent, value); }
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(MaximizeEvent));
        }
        #endregion


    }
}
