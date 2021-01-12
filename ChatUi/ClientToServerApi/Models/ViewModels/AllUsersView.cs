using System;
using System.Collections.Generic;
using System.Text;

namespace ClientToServerApi.Models.ViewModels
{
    public class AllUsersView
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public FileModel Picture { get; set; }
        public string IsOnline { get; set; }
        public bool Online { get; set; }
    }
}
