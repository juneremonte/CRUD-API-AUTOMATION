using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRUD_API_Automation_RestSharp.CRUD_USER
{
    
    internal class CrudUserAPITest
    {
        string bearer_token = "";
        string get_user_id = "";
        string email = "";

        [OneTimeSetUp]
        public void Setup()
        {
            var client = new RestClient("");

            var request = new RestRequest();
            request.AlwaysMultipartFormData = true;
            request.AddParameter("grant_type", "");
            request.AddParameter("client_id", "");
            request.AddParameter("scope", "");
            request.AddParameter("password", "");
            request.AddParameter("username", "");
            var response = client.Post(request);
            var obj = JsonConvert.DeserializeObject<dynamic>(response.Content);
            bearer_token = Convert.ToString(obj["access_token"]);
            Console.WriteLine(response.Content);
        }

        [OneTimeTearDown]
        public void Teardown()
        {

        }


        [Test]
        [Order(0)]
        public void AddUser()
        {
            var client = new RestClient("");
            var request = new RestRequest();
            request.AddHeader("Authorization", "Bearer " + bearer_token);
            request.AddHeader("Content-Type", "application/json");
            var body = "";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Post(request);
            var obj = JsonConvert.DeserializeObject<dynamic>(response.Content);
            get_user_id = Convert.ToString(obj["Data"]);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);
            GetUser();
        }

        [Test]
        [Order(1)]
        public void GetUser()
        {
            var client = new RestClient("");
            var request = new RestRequest();
            request.AddHeader("Authorization", "Bearer " + bearer_token);
            var response = client.Get(request);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);
        }

        [Test]
        [Order(2)]
        public void UpdateUser()
        {
            Thread.Sleep(3000);
            var client = new RestClient("");
            var request = new RestRequest();
            request.AddHeader("Authorization", "Bearer " + bearer_token);
            request.AddHeader("Content-Type", "application/json");
            var body = "";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Post(request);
            GetUser();
            Console.WriteLine(response.StatusCode);
        }

        [Test]
        public void DeleteUser()
        {
            var client = new RestClient("");
            var request = new RestRequest();
            request.AddHeader("Authorization", "Bearer " + bearer_token);
            var response = client.Post(request);
            Console.WriteLine(response.Content);
            GetUser();
            Console.WriteLine(response.StatusCode);
        }
    }
}
