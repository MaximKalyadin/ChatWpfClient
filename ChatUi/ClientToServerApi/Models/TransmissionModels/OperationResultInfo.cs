using ClientToServerApi.Models.Enums.Transmissions;

namespace ClientToServerApi.Models.TransmissionModels
{
    public class OperationResultInfo 
	{
		public string ErrorInfo { get; set; }
		public object JsonData { get; set; }
		public ListenerType ToListener { get; set; }
		public OperationsResults OperationsResults { get; set; }
	}

}
