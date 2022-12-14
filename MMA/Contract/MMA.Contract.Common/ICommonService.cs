using System.Runtime.Serialization;
using System.ServiceModel;
using MMA.Contract.Common.Response;
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
        ServiceResultAll<User> GetUsers();
        
        [OperationContract]
        User GetUser();
        
        [OperationContract]
        ServiceResultAll<Category> GetAllCategories();

        [OperationContract]
        ServiceResult AddCategory(Category category);
        
        
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