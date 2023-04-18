using BWERP.Api.Repositories.Interfaces;
using BWERP.Models.Email;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace BWERP.Api.Repositories.Services
{
	public class MailService : IMailService
	{
		private readonly IConfiguration _config;
		public MailService(IConfiguration config)
		{
			_config = config;
		}
		public void SendEmailAsync(EmailDto emailDto)
		{
			string[] recipients = emailDto.ToAdress.Split(';');

			var email = new MimeMessage();
			email.From.Add(MailboxAddress.Parse("notice-admin@buwon.com"));
			//GET LIST TO ADDRESS
			InternetAddressList list = new InternetAddressList();
			foreach (var item in recipients)
			{
				list.Add(MailboxAddress.Parse(item));
			}

			email.To.AddRange(list);

			if (!string.IsNullOrEmpty(emailDto.CcAddress))
			{
				email.Cc.Add(MailboxAddress.Parse(emailDto.CcAddress));
			}
			
			email.Subject = emailDto.Subject;

			// create body
			var builder = new BodyBuilder();
			builder.HtmlBody = @"<html><body><ul>" + string.Format(emailDto.Body) + "</ul></body></html>";
			email.Body = builder.ToMessageBody();
			
			using var smtp = new SmtpClient();
			smtp.Connect(_config.GetSection("SmtpServer").Value, 465, SecureSocketOptions.SslOnConnect);
			smtp.Authenticate("notice-admin@buwon.com", _config.GetSection("Password").Value);
			smtp.Send(email);
			smtp.Disconnect(true);
		}
	}
}
