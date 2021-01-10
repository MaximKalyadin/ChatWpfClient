using System;

namespace ClientToServerApi.Models.Enums.Transmissions 
{
	public enum ClientOperations 
	{
        //users
        Authorization,
        Registration,
        UpdateProfile,
        GetUsers,
        GetUser,

        //messages
        SendMessage,
        GetMessages,
        UpdateMessage,
        DeleteMessage,

        //chats
        CreateChat,
        DeleteChat,
        UpdateChat,
        GetChats,

        //friends
        AddFriend,
        DeleteFriend,
        GetFriends,

        //notifications
        UpdateNotification,
        GetNotifications,

        //encoding
        SendEncodingPublicKey
    }

}
