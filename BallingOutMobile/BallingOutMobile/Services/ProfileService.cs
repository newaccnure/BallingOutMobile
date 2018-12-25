using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BallingOutMobile.Models;
using RestSharp;

namespace BallingOutMobile.Services
{
    public static class ProfileService
    {
        private static RestClient client = new RestClient(API_Connection.URL);
        public static List<UserStats> GetUserStatsById(int userId) {
            var request = new RestRequest("/api/Practice/getUserStatsById", Method.POST);

            request.AddParameter("userId", userId);

            var response = client.Execute<List<UserStats>>(request);

            return response.Data;
        }
    }
}
