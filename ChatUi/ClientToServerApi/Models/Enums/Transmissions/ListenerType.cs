using System;

namespace ClientToServerApi.Models.Enums.Transmissions
{
	public enum ListenerType {
        AuthorizationListener,
        RegistrationListener,
        UserInfoListener,
        UserUpdateProfileListener,

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
