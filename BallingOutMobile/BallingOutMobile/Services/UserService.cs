using BallingOutMobile.Models;
using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BallingOutMobile.Services
{
    public static class UserService
    {
        private static RestClient client = new RestClient(API_Connection.URL);

        public static async Task<User> AddUser(string name, string email, string password,
            string checkPassword, List<int> practiceDays)
        {
            var request = new RestRequest("/api/User/addUser", Method.POST);

            request.AddParameter("name", name);
            request.AddParameter("email", email);
            request.AddParameter("password", password);
            request.AddParameter("checkPassword", checkPassword);
            request.AddParameter("practiceDays", JsonConvert.SerializeObject(practiceDays));

            var response = await client.ExecuteTaskAsync<bool>(request);

            if (response.Data)
            {
                var user = await GetUserByEmail(email);
                return user;
            }

            return new User();
        }

        public static async Task<bool> CheckUser(string email, string password)
        {
            var request = new RestRequest("/api/User/checkUser", Method.POST);

            request.AddParameter("email", email);
            request.AddParameter("password", password);
            
            var res = await client.ExecuteTaskAsync<bool>(request);

            return res.Data;
        }

        public static bool ChangeName(string email, string name)
        {
            return true;
        }

        public static bool DeleteAccount(string email)
        {
            return true;
        }

        public static bool ChangePassword(string email, string oldPassword, string newPassword, string checkPassword)
        {
            return true;
        }

        public static async Task<User> GetUserByEmail(string email)
        {
            var request = new RestRequest("/api/User/getUserByEmail", Method.POST);

            request.AddParameter("email", email);

            var response = await client.ExecuteTaskAsync<User>(request);

            return response.Data;
        }
    }
}
