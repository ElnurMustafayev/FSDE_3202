using System;

namespace Shared
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderName { get; set; }
        public string Content { get; set; }
        public long ChatId { get; set; }
    }
}
