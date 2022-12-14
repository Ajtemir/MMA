using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MMA.Contract.Common;
using MMA.Contract.Common.Response;
using MMA.DAL.Common;
using MMA.Domain.Common;

namespace MMA.Services.Common.CommonService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class CommonService : ICommonService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public ServiceResultAll<User> GetUsers()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            using var context = new CommonContext(connectionString);
            var user = context.Users.ToList();
            return new ServiceResultAll<User>{Results = user};
        }
    
        
        public User GetUser()
        {
            // using var context = new CommonContext("data source=localhost;User ID=login;Password=password;Initial Catalog=MMA;Integrated Security=True");
            try
            {
                using var context = new CommonContext();
                // context.Database.Connection.Open();
                return context.Users.FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.InnerException?.Message);
            }
            
        }

        public ServiceResultAll<Category> GetAllCategories()
        {
            try
            {
                using var context = new CommonContext();
                var categories = context.Categories.ToList();
                return new ServiceResultAll<Category>(categories);
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException?.Message);
            }
           
        }

        public ServiceResult AddCategory(Category category)
        {
            try
            {
                using var context = new CommonContext();
                context.Categories.Add(category);
                context.SaveChanges();
                return new ServiceResult();
            }
            catch (Exception e)
            {
                return new ServiceResult(e.Message);
            }
            
            
        }
    }
}
