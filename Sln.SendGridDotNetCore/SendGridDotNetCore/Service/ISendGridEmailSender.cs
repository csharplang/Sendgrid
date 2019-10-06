using System;
using System.Threading.Tasks;

namespace SendGridDotNetCore.Service
{
    public interface ISendGridEmailSender
    {
        Task<Tuple<string, string, string>> Execute(string filePath); 
    }
}