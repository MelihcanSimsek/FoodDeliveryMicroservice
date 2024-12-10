using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.MailService
{
    public static class MailService
    {
        public static Task SendMail(string email,string orderNumber,string content)
        {
            Console.WriteLine();

            return Task.CompletedTask;
        }
    }
}
