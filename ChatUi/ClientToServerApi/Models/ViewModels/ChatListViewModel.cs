using System;
using System.Collections.Generic;
using System.Text;

namespace ClientToServerApi.Models.ViewModels
{
    public class ChatListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOnline { get; set; }
        public string Online { get; set; }
        public DateTime Date { get; set; }
        public string LastMassege { get; set; }
        public string NewMessage { get; set; }
        public int? MessageCount { get; set; }
        public bool IsRead { get; set; }
        public int CountUsers { get; set; }
        public int CreatorId { get; set; }
    }
}
