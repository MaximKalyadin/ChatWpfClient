using ClientToServerApi.Models.Enums;
using System;

namespace ClientToServerApi.Models.ReceivedModels.UserModel
{
	public class UserReceiveModel 
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string name { get; set; }
		public string secondName { get; set; }
		public Gender gender { get; set; }
		public string phoneNumber { get; set; }
		public Country country { get; set; }
		public City city { get; set; }
		public byte[] picture { get; set; }
		public bool isOnline { get; set; }

	}

}
