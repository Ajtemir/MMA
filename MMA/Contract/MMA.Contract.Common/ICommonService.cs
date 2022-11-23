using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using MMA.Domain.Common;

namespace MMA.Contract.Common
{
    [ServiceContract]
    
    public interface ICommonService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
        [OperationContract]
        ServiceResult<User> GetUsers();
        [OperationContract]
        User GetUser();
    }

    [DataContract]
    public class ServiceResult<T>
    {
        [DataMember]
        public List<T> Entites { get; set; }
    }
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}