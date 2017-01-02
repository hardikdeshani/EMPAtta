
namespace EMPAttLogic
{
    public class General
    {
        public string GetPassword(string Mobile)
        {
            return Mobile.Substring(Mobile.Length - 3, 3).Trim() + "123";
        }

        public int SendEmail(string Msg, string Name)
        {
            try
            {
                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                mailMessage.To.Add("gandhi@websmithsolution.com");
                mailMessage.From = new System.Net.Mail.MailAddress("pm@websmithsolution.com");
                mailMessage.Subject = "Late comers " + Name;
                mailMessage.Body = Msg;
                mailMessage.IsBodyHtml = true;
                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient("mail.websmithsolution.com", 25);
                smtpClient.Credentials = new System.Net.NetworkCredential("pm@websmithsolution.com", "kunal1989!@#");
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
                return 1;
            }
            catch
            {
                return 0;
            }

        }
    }
}
