using ClientToServerApi.Models.Enums.Transmissions;

namespace ClientToServerApi.Models.TransmissionModels
{
    public class OperationResultInfo 
	{
		public string ErrorInfo { get; set; }
		public object JsonData { get; set; }
		public OperationsResults OperationsResult { get; set; }
		public ListenerType ToListener { get; set; }
	}

}
