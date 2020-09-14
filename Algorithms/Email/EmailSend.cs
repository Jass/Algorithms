using System;
using MailKit.Net.Smtp;
using MimeKit;

namespace Algorithms.Email
{
    public class EmailBO
    {
        private string _fromE;
        private string _toE;

        private string _fromName;
        private string _toName;

        private string _fromAddr;
        private string _toAddr;

        public EmailBO()
        {
            }

        

        public void DoSend()
        {
            MimeMessage emsg = new MimeMessage();
            emsg.From.Add(new MailboxAddress("lida", "colodream2020@gmail.com"));
            emsg.To.Add(new MailboxAddress("lyye",@"lyye83@gmail.com"));
            emsg.Subject = "hello";
            emsg.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "hello hello hello"
            };

            try
            {
                SmtpClient _client = new SmtpClient();
                using (_client)
                {
                    _client.Connect("smtp.gmail.com", 465);
                    _client.Authenticate(@"colodream2020@gmail.com", "dream2010");
                    _client.Send(emsg);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
    }

    public class EmailSend
    {
        
    }
}
