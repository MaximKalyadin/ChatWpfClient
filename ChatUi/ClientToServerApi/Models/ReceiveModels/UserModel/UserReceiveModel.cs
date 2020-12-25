using ClientToServerApi.Models.Enums;
using System;

namespace ClientToServerApi.Models.ReceivedModels.UserModel
{
	public class UserReceiveModel 
	{
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }

        public Gender? Gender { get; set; }

        public string PhoneNumber { get; set; }

        public Country? Country { get; set; }

        public City? City { get; set; }

        public FileModel File { get; set; }

        public bool IsOnline { get; set; }

    }

}
