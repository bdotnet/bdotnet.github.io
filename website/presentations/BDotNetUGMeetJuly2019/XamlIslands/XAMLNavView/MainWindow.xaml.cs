using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using System;
using System.Windows;
using Windows.UI.Xaml.Controls;
using XamlIslands = Windows.UI.Xaml.Controls;

namespace XAMLNavView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            inkCanvas.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse;
        }

        private void WindowsXamlHost_ChildChanged(object sender, EventArgs e)
        {
            WindowsXamlHost windowsXamlHost = (WindowsXamlHost)sender;

            var navView = (NavigationView)windowsXamlHost.Child;

            if(navView != null)
            {
                navView.PaneDisplayMode = NavigationViewPaneDisplayMode.Left;
                navView.MenuItems.Add(CreateMenu("Mouse", "\uF71E"));
                navView.MenuItems.Add(CreateMenu("Pen", "\uE76D"));
                navView.MenuItems.Add(CreateMenu("Touch", "\uED5F"));
                navView.ItemInvoked += NavView_ItemInvoked;               
            }

        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if(args.IsSettingsInvoked)
            {

            }
            else
            {
                switch (args.InvokedItem.ToString())
                {
                    case "Mouse":
                        inkCanvas.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse;
                        break;
                    case "Pen":
                        inkCanvas.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Pen;
                        break;
                    case "Touch":
                        inkCanvas.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Touch;
                        break;
                }
            }            
        }

        private static XamlIslands.NavigationViewItem CreateMenu(string menuName, string IconName)
        {
            XamlIslands.NavigationViewItem mnuItem = new XamlIslands.NavigationViewItem
            {
                Name = menuName,
                Content = menuName,
                Tag = menuName
            };
            var mnuIcon = new XamlIslands.FontIcon { Glyph = IconName };
            mnuItem.Icon = mnuIcon;
            return mnuItem;
        }
    }
}
