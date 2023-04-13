using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvendeTest60.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Sent_at { get; set; }

        public MessageModel(string subject, string body)
        {
            Subject = subject;
            Body = body;
        }
    }
}
