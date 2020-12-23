using System;

namespace ClientToServerApi.Models.ReceivedModels.UserModel 
{
	public class UserListReceiveModel 
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public byte[] Picture { get; set; }
	}

}
