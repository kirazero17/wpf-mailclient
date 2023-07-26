using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lab5.pages;

public partial class Receive : Page
{
    public Receive()
    {
        this.InitializeComponent();
    }

   private void onLoad(object sender, RoutedEventArgs e)
    {
        
    }

    private void Btn_Back_Clicked(object sender, RoutedEventArgs e)
    {
        this.NavigationService.GoBack();
    }
}

public class Mail
{
    public string Subj { get; set; }

    public int Src { get; set; }

    public string Time { get; set; }
}
