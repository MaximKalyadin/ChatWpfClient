using System;

namespace ClientToServerApi.Models.ReceivedModels.MessageModels 
{
	public class MessageReceiveModel 
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int ChatId { get; set; }
		public string UserMassage { get; set; }
		public DateTime Date { get; set; }
	}

}
