using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MMA.Contract.Common.Response
{
    [DataContract]
    public class ServiceResultAll<T> : ServiceResult
    {
        public ServiceResultAll(List<T> results)
        {
            Results = results;
        }
        public ServiceResultAll(){}
        [DataMember]
        public List<T> Results { get; set; }
    }
}