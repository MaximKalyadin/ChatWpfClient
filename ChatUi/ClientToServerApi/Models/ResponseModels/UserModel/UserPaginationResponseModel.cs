using System;

namespace ClientToServerApi.Models.ResponseModels.UserModel 
{
	public class UserPaginationResponseModel 
	{
		public int UserId { get; set; }
		public int Page { get; set; }
		public string SearchingUserName { get; set; }
	}
}
