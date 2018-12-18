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
    public static class DrillService
    {
        private static RestClient client = new RestClient(API_Connection.URL);

        public static List<Drill> GetFullTrainingProgramById(int userId) {

            var request = new RestRequest("/api/Practice/getFullTrainingProgramById", Method.POST);

            request.AddParameter("userId", userId);

            IRestResponse<List<Drill>> response = client.Execute<List<Drill>>(request);

            return response.Data;
        }
    }
}
