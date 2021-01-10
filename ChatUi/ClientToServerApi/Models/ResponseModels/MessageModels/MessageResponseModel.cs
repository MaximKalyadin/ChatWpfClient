using System;

namespace ClientToServerApi.Models.ResponseModels.MessageModels 
{
	public class MessageResponseModel 
	{
		public int? Id { get; set; }
		public int FromUserId { get; set; }
		public int ChatId { get; set; }
		public DateTime Date { get; set; }
		public string UserMassege { get; set; }
		public bool IsReaded { get; set; }
		public FileModel File { get; set; }
	}
}
