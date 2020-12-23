using ClientToServerApi.Models.ReceivedModels.ChatModels;
using System;
using System.Collections.Generic;

namespace ClientToServerApi.Models.ReceivedModels 
{
	public class ChatReceiveModel 
	{
		public int Id { get; set; }
		public string ChatName { get; set; }
		public int CreatorId { get; set; }
		public int CountUsers { get; set; }
		public List<ChatUserReceiveModel> ChatUsers { get; set; }

	}

}
