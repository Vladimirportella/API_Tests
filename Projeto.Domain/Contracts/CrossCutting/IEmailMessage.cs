using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.CrossCutting
{
    public interface IEmailMessage
    {
        void SendMessage(string mailTo, string subject, string body);
    }
}
