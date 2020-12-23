using System;

namespace ClientToServerApi.Models.Enums.Transmissions
{
	public enum ListenerType {
		AuthorizationListener,
		RegistrationListener,
		ChatListListener,
		ChatListDeleteListener,
		ChatsMessagesListener,
		ChatsMessagesDeleteListener,
		UserListListener,
		FriendListListener,
		FriendListDeleteListener,
        NotificationListListener
	}

}
