using BallingOutMobile.Models;
using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BallingOutMobile.Services
{
    public static class UserService
    {
        private static RestClient client = new RestClient(API_Connection.URL);
        public static int AddUser(string name, string email, string password,
            string checkPassword, List<int> practiceDays)
        {
            var request = new RestRequest("/api/User/addUser", Method.POST);

            request.AddParameter("name", name);
            request.AddParameter("email", email);
            request.AddParameter("password", password);
            request.AddParameter("checkPassword", checkPassword);
            request.AddParameter("practiceDays", JsonConvert.SerializeObject(practiceDays));

            IRestResponse<bool> response = client.Execute<bool>(request);

            if (response.Data)
            {
                var user = GetUserIdByEmail(email);

                return user;
            }

            return -1;
        }

        public static bool CheckUser(string email, string password)
        {
            var request = new RestRequest("/api/User/checkUser", Method.POST);

            request.AddParameter("email", email);
            request.AddParameter("password", password);

            IRestResponse<bool> response = client.Execute<bool>(request);

            return response.Data;
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

        public static User GetUserById(int userId)
        {
            var request = new RestRequest("/api/User/getUserById", Method.POST);

            request.AddParameter("userId", userId);

            IRestResponse<User> response = client.Execute<User>(request);

            return response.Data;
        }

        public static int GetUserIdByEmail(string email)
        {
            var request = new RestRequest("/api/User/getUserIdByEmail", Method.POST);

            request.AddParameter("email", email);

            IRestResponse<int> response = client.Execute<int>(request);

            return response.Data;
        }
    }
}
