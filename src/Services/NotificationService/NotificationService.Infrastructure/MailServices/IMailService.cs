using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.MailServices
{
    public interface IMailService
    {
        Task SendMail(string email, string content);
    }
}
