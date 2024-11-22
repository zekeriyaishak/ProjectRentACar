using Business.Abstract;
using Business.Constants.Messages;
using CorePackagesGeneral.Entities.Concrete;
using CorePackagesGeneral.Utilities.Results.Abstract;
using CorePackagesGeneral.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult AddUser(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult DeleteUser(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IResult UpdateUser(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdate);
        }
 public class Credentials
        {
            private string FirstName = "zekeriya ishak";
            private string password = "password";
        }
        public void UnsafeSqlQuery(string userInput)
        {
            var connectionString = "Data Source=DESKTOP-SDKFJ6F;Initial Catalog=rent-a-car-prod;Integrated Security=True;Trusted_Connection=true;TrustServerCertificate=True";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var query = "Select * from Users where FirstName = '" + userInput + "'";
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                }
            }
        }

        public void InefficientLoop()
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 100000; i++)
            {
                numbers.Add(i);
            }

            foreach (int number in numbers)
            {
                for (int i = 0; i < numbers.Count; i++) // İç içe döngü performans sorunlarına yol açabilir
                {
                    if (numbers[i] == number)
                    {
                        Console.WriteLine("Found: " + number);
                    }
                }
            }
        }
        public void SendSensitiveData()
        {
            var sensitiveData = "creditCardNumber=1234-5678-9012-3456";
            using (var client = new HttpClient())
            {
                var content = new StringContent(sensitiveData);
                client.PostAsync("http://example.com", content); // HTTPS yerine HTTP kullanılıyor
            }
        }
         public void MemoryLeak()
        {
            List<byte[]> largeData = new List<byte[]>();
            for (int i = 0; i < 1000000; i++)
            {
                largeData.Add(new byte[1024 * 1024]); // Belleği sürekli dolduran büyük nesneler
            }
        }
    }
}
