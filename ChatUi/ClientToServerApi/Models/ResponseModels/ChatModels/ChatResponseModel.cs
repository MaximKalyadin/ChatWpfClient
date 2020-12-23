using ClientToServerApi.Models.ResponseModel.ChatModels;
using System;
using System.Collections.Generic;

namespace ClientToServerApi.Models.ResponseModels.ChatModels 
{
	public class ChatResponseModel 
	{
		public int id { get; set; }
		public string chatName { get; set; }
		public int creatorId { get; set; }
		public DateTime dateOfCreation { get; set; }
		public List<ChatUserResponseModel> chatUsers { get; set; }

	}

}
