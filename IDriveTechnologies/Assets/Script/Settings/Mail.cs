using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Mail : MonoBehaviour {

    public InputField subject;
    public InputField messageLine;
    public Text error;
    public InputField customerMail;
    private string Email = "IDriveTechnologiesReport@gmail.com";
    private string password = "Loost1k22";
    private string login = "IDriveTechnologiesReport@gmail.com";
    private string smtp = "smtp.gmail.com";


    public void SendEmail()
    {
        //if (messageLine.text == "" || subject.text == "")
        //{
        //    error.text = "Please , fill in all the fields";
        //}
        //else
        //{

        //    MailMessage message = new MailMessage(Email, Email ,subject.text, messageLine.text);
        //    SmtpClient client = new SmtpClient(smtp);
        //    client.Port = 587;
        //    client.Credentials = new NetworkCredential(login , password) as ICredentialsByHost;
        //    client.EnableSsl = true;
        //    client.Send(message);


        //}


        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("IDriveTechnologiesReport@gmail.com");
        mail.To.Add("IDriveTechnologiesReport@gmail.com");
        mail.Subject = "Test Mail";
        mail.Body = "This is for testing SMTP mail from GMAIL";

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("IDriveTechnologiesReport@gmail.com", "Loost1k22") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.Send(mail);
        Debug.Log("success");
    }

}
