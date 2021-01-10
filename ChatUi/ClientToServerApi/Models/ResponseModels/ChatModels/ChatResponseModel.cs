using ClientToServerApi.Models.ResponseModel.ChatModels;
using System;
using System.Collections.Generic;

namespace ClientToServerApi.Models.ResponseModels.ChatModels 
{
	public class ChatResponseModel 
	{
        public int? Id { get; set; }

        public string ChatName { get; set; }

        public int CreatorId { get; set; }

        public DateTime DateOfCreation { get; set; }

        public List<ChatUserResponseModel> ChatUsers { get; set; }

    }

}
