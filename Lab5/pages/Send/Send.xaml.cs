using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Lab5.pages;

public partial class Send : Page
{
    private void Btn_Back_Clicked(object sender, RoutedEventArgs e)
    {
        this.NavigationService.GoBack();
    }
    private void Btn_Send_Clicked(object sender, RoutedEventArgs e)
    {
        using (SmtpClient smtpClient = new SmtpClient("127.0.0.1"))
        {
            using (MailMessage message = new MailMessage())
            {
                MailAddress fromAddress = new MailAddress(Data.email);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(Data.email, Data.password);

                message.From = fromAddress;
                message.Subject = this.txtSubj.Text.ToString().Trim();
                // Set IsBodyHtml to true means you can send HTML email.
                message.IsBodyHtml = true;
                message.Body = new TextRange(this.txtBody.Document.ContentStart, this.txtBody.Document.ContentEnd).Text;
                message.To.Add(this.txtTo.Text.ToString().Trim());

                try
                {
                    smtpClient.Send(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
