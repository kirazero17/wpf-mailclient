using System;
using System.Windows;
using System.Windows.Controls;

namespace Lab5.pages;

public partial class Home : Page
{
    public Home()
    {
    }

    private void Btn_Send_Click(object sender, RoutedEventArgs e)
    {
        this.NavigationService.Navigate(new Uri("/pages/Send/Send.xaml", UriKind.Relative));
        Window.GetWindow(this).MinHeight = 500;
        Window.GetWindow(this).MinWidth = 650;
    }
    private void Btn_Recv_Click(object sender, RoutedEventArgs e)
    {
        this.NavigationService.Navigate(new Uri("/pages/Receive/Recv.xaml", UriKind.Relative));
        Window.GetWindow(this).MinHeight = 500;
        Window.GetWindow(this).MinWidth = 650;
    }
    private void Btn_Logout_Click(object sender, RoutedEventArgs e)
    {
        
        if (!this.NavigationService.CanGoBack && !this.NavigationService.CanGoForward)
        {
            return;
        }

        var entry = this.NavigationService.RemoveBackEntry();
        while (entry != null)
        {
            entry = this.NavigationService.RemoveBackEntry();
        }
        Data.email = "";
        Data.password = "";
        this.NavigationService.Navigate(new Uri("/pages/Login/Login.xaml", UriKind.Relative));
        Window.GetWindow(this).MinHeight = 400;
        Window.GetWindow(this).MinWidth = 500;
        Window.GetWindow(this).Height = Window.GetWindow(this).MinHeight;
        Window.GetWindow(this).Width = Window.GetWindow(this).MinWidth;
    }
}
