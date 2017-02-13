using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDotNet_Task
{
    interface ISmtpSender
    {
        void SendMail(string message);
    }
}
