using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xcelerate.Core.Models.Account.UserProfile
{
    public class ChatMessageViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreatedTime { get; set; }
        public string SenderName { get; set; }
    }
}
