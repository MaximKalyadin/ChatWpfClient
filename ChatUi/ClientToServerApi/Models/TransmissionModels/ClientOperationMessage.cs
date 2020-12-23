using ClientToServerApi.Models.Enums.Transmissions;
using System;

namespace ClientToServerApi.Models.TransmissionModels 
{
	public class ClientOperationMessage 
	{
		public ClientOperations Operation { get; set; }
		public string JsonData { get; set; }
	}

}
