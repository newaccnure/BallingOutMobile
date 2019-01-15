using BallingOutMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Globalization;

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

            request.AddParameter("userId", userId);
            request.AddParameter("drillId", drillId);
            request.AddParameter("averageSpeed", 12);
            request.AddParameter("averageAccuracy", 12);
            request.AddParameter("repeatitionsPerSecond", 12);

            var response = await client.ExecuteTaskAsync<bool>(request);

            return response.Data;
        }

        public static async Task<IRestResponse<bool>> StartDrillPractice(int userId, int drillId)
        {

            var request = new RestRequest("/api/Practice/startDrillPractice", Method.POST);
            
            request.AddParameter("userId", userId);
            request.AddParameter("drillId", drillId);

            var response = await client.ExecuteTaskAsync<bool>(request);

            return response;
        }

        public static async Task<DrillStats> GetDrillStatsById(int userId, int drillId)
        {

            var request = new RestRequest("/api/Practice/getDrillStatsById", Method.POST);

            request.AddParameter("userId", userId);
            request.AddParameter("drillId", drillId);

            var response = await client.ExecuteTaskAsync<DrillStats>(request);

            return response.Data;
        }

        public static async Task<bool> PracticeWasStarted(int userId)
        {

            var request = new RestRequest("/api/Practice/practiceWasStarted", Method.POST);

            request.AddParameter("userId", userId);

            var response = await client.ExecuteTaskAsync<bool>(request);

            return response.Data;
        }
    }
}
