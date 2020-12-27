using System;

namespace ClientToServerApi.Models.ReceivedModels.UserModel 
{
	public class UserListReceiveModel 
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public FileModel Picture { get; set; }
		public bool IsOnline { get; set; }
	}

}
