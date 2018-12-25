using BallingOutMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace BallingOutMobile.Services
{
    public static class PracticeService
    {
        private static RestClient client = new RestClient(API_Connection.URL);

        public static async Task<List<Drill>> GetFullTrainingProgramById(int userId) {

            var request = new RestRequest("/api/Practice/getFullTrainingProgramById", Method.POST);

            request.AddParameter("userId", userId);

            var response = await client.ExecuteTaskAsync<List<Drill>>(request);

            return response.Data;
        }

        public static async Task<bool> CheckDayOfPractice(int userId)
        {

            var request = new RestRequest("/api/Practice/checkDayOfPractice", Method.POST);

            request.AddParameter("userId", userId);

            var response = await client.ExecuteTaskAsync<bool>(request);

            return response.Data;
        }

        public static async Task<bool> AddDrillToCompleted(int userId, int drillId)
        {

            var request = new RestRequest("/api/Practice/addDrillToCompleted", Method.POST);
            //TODO
            Random r = new Random();
            double averageSpeed = r.NextDouble();
            double averageAccuracy = r.NextDouble() / 2 + 0.5;
            double repeatitionsPerSecond = r.NextDouble();

            request.AddParameter("userId", userId);
            request.AddParameter("drillId", drillId);

            var response = await client.ExecuteTaskAsync<bool>(request);

            return response.Data;
        }
    }
}
