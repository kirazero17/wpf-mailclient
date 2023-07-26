using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace Lab5.pages;

public partial class Login : Page
{
    string Login_Msg;
    public Login()
    {
        string Login_Msg="";
    }

    private void Btn_Login_Clicked(object sender, RoutedEventArgs e)
    {
        string email = this.txtMail.Text.ToString().Trim();
        string password = this.txtPass.Text.ToString().Trim();
        //if (ValidateCredentials(email, password, "192.69.4.20", true) )
        //{
        //    Data.email = email;
        //    Data.password = password;
            this.NavigationService.Navigate(new Uri("/pages/Home/Home.xaml", UriKind.Relative));
            Window.GetWindow(this).MinHeight = 500;
            Window.GetWindow(this).MinWidth = 650;
        //}
    }

    public bool ValidateCredentials(string username, string password, string server, bool certificationValidation)
    {
        try
        {
            using var client = new MailKit.Net.Smtp.SmtpClient();
            client.Timeout = 5000;
            try
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => certificationValidation;
                client.Connect(server, 25, false);
                client.Authenticate(username, password);
                client.Disconnect(true);
                return true;
            }
            catch (Exception ex)
            {
                this.Lbl_Status.Content = ex.Message;
            }
        }
        catch (System.Exception ex)
        {
            this.Lbl_Status.Content = ex.Message;
        }

        return false;
    }
}
