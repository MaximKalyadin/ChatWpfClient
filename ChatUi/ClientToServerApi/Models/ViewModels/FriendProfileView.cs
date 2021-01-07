using ClientToServerApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientToServerApi.Models.ViewModels
{
    public class FriendProfileView
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public Country? Country { get; set; }
        public City? City { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Online { get; set; }
        public bool IsOnline { get; set; }
        public int Count { get; set; }
        public int CreatorId { get; set; }
    }
}
