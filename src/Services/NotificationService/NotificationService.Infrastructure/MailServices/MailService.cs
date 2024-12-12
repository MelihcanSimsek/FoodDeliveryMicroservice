using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.MailServices
{
    public class MailService : IMailService
    {
        public async Task SendMail(string email, string content)
        {
            Console.WriteLine("--------------  Sending Mail to -> " + email + "  --------------\n");
            Console.WriteLine(content);
        }
    }
}
