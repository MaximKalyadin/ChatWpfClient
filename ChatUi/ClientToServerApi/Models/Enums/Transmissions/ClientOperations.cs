using System;

namespace ClientToServerApi.Models.Enums.Transmissions 
{
	public enum ClientOperations 
	{
		Authorization,
		Registration,
		UpdateProfile,
		GetUsers,
		SendMessage,
		GetMessages,
		UpdateMessage,
		DeleteMessage,
		CreateChat,
		DeleteChat,
		UpdateChat,
		GetChats,
		AddFriend,
		DeleteFriend,
		GetFriends,
		UpdateNotification,
		GetNotifications
	}

}
