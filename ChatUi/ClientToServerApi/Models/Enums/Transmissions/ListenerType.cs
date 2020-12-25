using System;

namespace ClientToServerApi.Models.Enums.Transmissions
{
	public enum ListenerType {
        AuthorizationListener,
        RegistrationListener,
        UserInfoListener,

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
