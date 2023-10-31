//using Microsoft.AspNetCore.Authorization;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Net;
//using System.Net.Mail;
//using System.Threading.Tasks;

//namespace MyApi.Identidade
//{
//    public class IdentidadeService : DomainService
//    {
//        private readonly IRepository<User, long> _userRepository;
//        private readonly IEmailSender _emailSender;

//        private readonly IConfiguration _configuration;

//        public IdentidadeService(IRepository<User, long> userRepository, IEmailSender emailSender, IConfiguration configuration)
//        {
//            _userRepository = userRepository;
//            _emailSender = emailSender;
//            _configuration = configuration;
//        }

//        [AllowAnonymous]
//        [AbpAllowAnonymous]
//        public async Task SendEmailAsync(UserDto usuario, string code, string subject, string body)
//        {
//            if (usuario.EmailAddress != null)
//            {

//                try
//                {
//                    string smtpServer = "smtp.office365.com";
//                    int smtpPort = 587;
//                    string userName = "hracademy2023@outlook.com";
//                    string password = "02252713Fc!";

//                    SmtpClient client = new SmtpClient(smtpServer, smtpPort);
//                    client.EnableSsl = true;
//                    client.Credentials = new NetworkCredential(userName, password);

//                    MailMessage message = new MailMessage();
//                    message.From = new MailAddress("hracademy2023@outlook.com");
//                    message.To.Add(usuario.EmailAddress);
//                    message.Subject = subject;
//                    message.Body = string.Format(body, usuario.Name, code);
//                    message.IsBodyHtml = true;
//                    client.Send(message);
//                }
//                catch (Exception ex)
//                {
//                    Logger.Error("Erro ao tentar enviar e-mail.", ex);
//                }
//            }
//            else
//                throw new UserFriendlyException("Usuário não possui e-mail cadastrado.");
//        }

//        public async Task SendEmailRecoveryPasswordAsync(UserDto usuario, string code, string subject, string body)
//        {
//            if (usuario.EmailAddress != null)
//            {

//                try
//                {
//                    string smtpServer = "smtp.office365.com";
//                    int smtpPort = 587;
//                    string userName = "hracademy2023@outlook.com";
//                    string password = "02252713Fc!";

//                    SmtpClient client = new SmtpClient(smtpServer, smtpPort);
//                    client.EnableSsl = true;
//                    client.Credentials = new NetworkCredential(userName, password);

//                    MailMessage message = new MailMessage();
//                    message.From = new MailAddress("hracademy2023@outlook.com");
//                    message.To.Add(usuario.EmailAddress);
//                    message.Subject = subject;
//                    message.Body = string.Format(body, usuario.Name, code);
//                    message.IsBodyHtml = true;
//                    client.Send(message);
//                }
//                catch (Exception ex)
//                {
//                    Logger.Error("Erro ao tentar enviar e-mail.", ex);
//                }
//            }
//            else
//                throw new UserFriendlyException("Usuário não possui e-mail cadastrado.");
//        }
//    }
//}