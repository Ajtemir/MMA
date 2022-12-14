using System.Runtime.Serialization;

namespace MMA.Contract.Common.Response
{
    [DataContract]
    public class ServiceResult
    {
        public ServiceResult(bool isSuccess = true)
        {
            IsSuccess = isSuccess;
        }

        public ServiceResult(string message, bool isSuccess = false)
        {
            
        }
        [DataMember]
        public bool IsSuccess { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}