using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_API_Automation_RestSharp.CRUD_USER
{
    [TestFixture]
    public class CrudUserAPI
    {
        [OneTimeSetUp]
        public void Setup()
        {
        }

        [OneTimeTearDown]
        public void Teardown()
        {
        }


        string username = "Charles";
        string url = "https://petstore.swagger.io/v2/";
        string get_id = "";
        [Test]
        [Order(0)]
        public void AddUser()
        {
            var client = new RestClient(url+"user");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
                        " + "\n" +
                        @"  ""id"": 0, " + "\n" +
                        @"  ""username"":" +"\""+username+"\""+ "," + "\n" +
                        @"  ""firstName"": ""June"", " + "\n" +
                        @"  ""lastName"": ""Remonte""," + "\n" +
                        @"  ""email"": ""june@gmail.com"", " + "\n" +
                        @"  ""password"": ""password"", " + "\n" +
                        @"  ""phone"": ""123456"", " + "\n" +
                        @"  ""userStatus"": 0 " + "\n" +
                        @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Post(request);
            GetUser();
        }

        [Test]
        [Order(1)]
        public void GetUser()
        {
            var client = new RestClient(url+"user/"+username);
            var request = new RestRequest();
            var response = client.Get(request);
            var obj = JsonConvert.DeserializeObject<dynamic>(response.Content);
            get_id = Convert.ToString(obj["id"]);
            Console.WriteLine(response.Content);
        }

        [Test]
        [Order(2)]
        public void UpdateUser()
        {
            var client = new RestClient(url + "user/" + username);
            var request = new RestRequest();
            username = "Adrian";
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
                        " + "\n" +
                        @"  ""id"": " + Convert.ToInt64(get_id) + "," + "\n" +
                        @"  ""username"":" + "\"" + username + "\"" + "," + "\n" +
                        @"  ""firstName"": ""Cha""," + "\n" +
                        @"  ""lastName"": ""Ruth""," + "\n" +
                        @"  ""email"": ""charuth@gmail.com""," + "\n" +
                        @"  ""password"": ""password""," + "\n" +
                        @"  ""phone"": ""3131233""," + "\n" +
                        @"  ""userStatus"": 0" + "\n" +
                        @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Put(request);
            Console.WriteLine(response.Content);
            GetUser();
        }

        [Test]
        public void DeleteUser()
        {
            var client = new RestClient(url + "user/" + username);
            var request = new RestRequest();
            var response = client.Delete(request);
            Console.WriteLine(response.Content);
            GetUser();
        }
    }
}
