using System;

namespace ClientToServerApi.Models.ReceivedModels.NotificationModels 
{
	public class NotificationReceiveModel 
	{
		public int Id { get; set; }
		public string Message { get; set; }
		public int FromUserId { get; set; }
		public string FromUserName { get; set; }
		public FileModel UserPicture { get; set; }

	}

}
