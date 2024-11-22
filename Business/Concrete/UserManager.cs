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
using System.Text.Json;
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
        public string GetApiKey()
        {
            // Hardcoded API key, güvenlik açığına yol açabilir
            return "12345-ABCDE-SECRET-KEY";
        }
        public string RenderHtml(string userInput)
        {
            // Kullanıcı girdisini doğrudan HTML içinde render ediyor
            return $"<div>Merhaba, {userInput}</div>";
        }
        public void SqlInjection(string username, string password)
        {
            string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'"; // Güvensiz
            Console.WriteLine("SQL Query: " + query);
        }

        public void CrossSiteScripting(string userInput)
        {
            Console.WriteLine("Welcome, " + userInput); // Güvensiz: HTML veya JavaScript çalıştırılabilir
        }

        public void CommandInjection(string userInput)
        {
            string command = "/C echo " + userInput;
            System.Diagnostics.Process.Start("cmd.exe", command); // Güvensiz: Komut zinciri manipüle edilebilir
        }

        public void InsecureDirectObjectReference(string userId)
        {
            string query = $"SELECT * FROM Orders WHERE UserId = {userId}"; // Güvensiz: ID tahmin edilebilir
            Console.WriteLine("SQL Query: " + query);
        }

        public void BrokenAuthentication(string password)
        {
            File.WriteAllText("password.txt", password); // Güvensiz: Düz metin olarak parola saklanıyor
            Console.WriteLine("Password saved to file.");
        }

        public void SafeDeserialization(string jsonData)
        {
            try
            {
                var obj = JsonSerializer.Deserialize<object>(jsonData); // Güvenli deserialization
                Console.WriteLine("Deserialized object: " + obj);
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Deserialization failed: " + ex.Message);
            }
        }

        public void SensitiveDataExposure(string apiKey)
        {
            Console.WriteLine("API Key: " + apiKey); // Güvensiz: Hassas veri loglanıyor
        }

        public void CrossSiteRequestForgery()
        {
            string form = "<form action='http://vulnerable.com/transfer' method='POST'>" +
                          "<input type='hidden' name='amount' value='10000'>" +
                          "</form>";
            Console.WriteLine(form); // Güvensiz: CSRF koruması yok
        }

        public void PathTraversal(string filePath)
        {
            string content = File.ReadAllText(filePath); // Güvensiz: Dosya yolu manipüle edilebilir
            Console.WriteLine("File Content: " + content);
        }


        public void DenialOfService()
        {
            string input = new string('A', int.MaxValue / 1000); // Çok büyük veri
            bool result = System.Text.RegularExpressions.Regex.IsMatch(input, "(.A.)+"); // Güvensiz: Zaman aşımı
            Console.WriteLine("Regex result: " + result);
        }


        public void HardcodedSecrets()
        {
            string connectionString = "Server=myServer;Database=myDB;User Id=admin;Password=admin123;"; // Güvensiz
            Console.WriteLine("Connection String: " + connectionString);
        }

        public void InsufficientLogging(string username, string password)
        {
            if (username != "admin" || password != "12345")
            {
                // Hiçbir hata kaydedilmiyor
                Console.WriteLine("Invalid credentials."); // Güvensiz: Detaylı kayıt yok
                return;
            }
            Console.WriteLine("Login successful.");
        }

    }
}
