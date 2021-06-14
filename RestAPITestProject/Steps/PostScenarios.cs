using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestAPIExampleProject.Model;
using RestAPIExampleProject.Settings;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestAPIExampleProject.Steps
{
    [Binding]
    public class PostScenarios
    {

        private BaseSettings _baseSettings;
        private IRestResponse _responseRaw;
        private JObject _jObjectDeserialized;
        public PostScenarios(BaseSettings baseSettings)
        {
            this._baseSettings = baseSettings;

        }

        [Given(@"request configured as POST")]
        public void GivenRequestConfiguredAsPOST()
        {

            _baseSettings.Request = new RestRequest("users/", Method.POST);
        }

        [Given(@"authorization token is set")]
        public void GivenAuthorizationTokenIsSet()
        {
            _baseSettings.Request.AddHeader("Authorization", ApiKey.BearerToken);

        }


        [Given(@"invalid body parameters are set")]
        public void GivenInvalidBodyParametersAreSet(Table table)
        {
            var bodyData = table.CreateInstance<Data>();

            _baseSettings.Request.AddJsonBody(new Data { email = EmailHelper.generateRandomEmail(), gender = bodyData.gender, name = "TestUser", status = bodyData.status });
        }

        [Given(@"valid body parameters are set")]
        public void GivenValidBodyParametersAreSet()
        {
            _baseSettings.Request.AddJsonBody(new Data { email = EmailHelper.generateRandomEmail(), gender = "Female", name = "TestUser", status = "Active" });

        }


        [When(@"Post is executed")]
        public void WhenPostIsExecuted()
        {
            _responseRaw = _baseSettings.RestClient.Execute<RootObject>(_baseSettings.Request);
            _jObjectDeserialized = JObject.Parse(_responseRaw.Content);


        }

        [Then(@"the response code should be (.*)")]
        public void ThenTheResponseCodeShouldBe(int p0)
        {

            Assert.AreEqual(HttpStatusCode.OK, _responseRaw.StatusCode);
            Assert.AreEqual(p0, Int16.Parse(_jObjectDeserialized.SelectToken("code").ToString()));

            //  _responseCollection = _jsonDeserializer.Deserialize<RootObject>(_responseRaw);            
            //Assert.AreEqual(p0, _responseCollection.code);
            //  Assert.AreEqual("testuser13@mail.com", _responseCollection.data.email);

        }

        [Given(@"authorization token is incorrectly set")]
        public void GivenAuthorizationTokenIsIncorrectlySet()
        {
            _baseSettings.Request.AddHeader("Authorization", "Wrong Bearer Token");
        }


    }
}
