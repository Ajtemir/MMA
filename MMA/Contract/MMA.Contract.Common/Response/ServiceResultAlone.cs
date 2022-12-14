using System.Runtime.Serialization;

namespace MMA.Contract.Common.Response
{
    [DataContract]
    public class ServiceResultAlone<T> : ServiceResult
    {
        [DataMember]
        public T Entity { get; set; }
    }
}