using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestAPIExampleProject.Model;
using RestAPIExampleProject.Settings;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace RestAPIExampleProject.Steps
{
    [Binding]
    public class PutAndDeleteScenarios
    {
        private BaseSettings _baseSettings;
        private IRestResponse _responseRaw;
        private JObject _jObjectDeserialized;
        public string _userId;

        public PutAndDeleteScenarios(BaseSettings baseSettings)
        {
            this._baseSettings = baseSettings;
        }

        [Given(@"User is already created")]
        public void GivenUserIsAlreadyCreated()
        {

            _baseSettings.Request = new RestRequest("users/", Method.POST);

            _baseSettings.Request.AddHeader("Authorization", ApiKey.BearerToken);

            _baseSettings.Request.AddJsonBody(new Data { email = EmailHelper.generateRandomEmail(), gender = "Female", name = "TestUser", status = "Active" });

            _responseRaw = _baseSettings.RestClient.Execute<RootObject>(_baseSettings.Request);

            _jObjectDeserialized = JObject.Parse(_responseRaw.Content);

            Assert.AreEqual(HttpStatusCode.OK, _responseRaw.StatusCode);

            Assert.AreEqual(201, Int16.Parse(_jObjectDeserialized.SelectToken("code").ToString()));

            _userId = _jObjectDeserialized.SelectToken("data.id").ToString();

        }

        [Given(@"Request configures as PUT")]
        public void GivenRequestConfiguresAsPUT()
        {

            _baseSettings.Request = new RestRequest("users/{id}", Method.PUT);

        }

        [Given(@"existent UserID is set")]
        public void GivenExistentUserIDIsSet()
        {
            _baseSettings.Request.AddUrlSegment("id", _userId);
        }

        [Given(@"Non-existent UserID is set")]
        public void GivenNon_ExistentUserIDIsSet()
        {

            _baseSettings.Request.AddUrlSegment("id", "999999");


        }



        [Given(@"authorization bearer token is set")]
        public void GivenAuthorizationBearerTokenIsSet()
        {
            _baseSettings.Request.AddHeader("Authorization", ApiKey.BearerToken);
        }

        [Given(@"valid email parameters are set")]
        public void GivenValidEmailParametersAreSet()
        {
            _baseSettings.Request.AddParameter("email", EmailHelper.generateRandomEmail());
        }

        [When(@"PUT request is executed")]
        public void WhenPUTRequestIsExecuted()
        {
            _responseRaw = _baseSettings.RestClient.Execute<RootObject>(_baseSettings.Request);

            _jObjectDeserialized = JObject.Parse(_responseRaw.Content);

        }

        [Then(@"the http response should be '(.*)'")]
        public void ThenTheHttpResponseShouldBe(int p0)
        {

            Assert.AreEqual(HttpStatusCode.OK, _responseRaw.StatusCode);

            Assert.AreEqual(p0, Int16.Parse(_jObjectDeserialized.SelectToken("code").ToString()));

        }

        [Given(@"authorization invalid bearer token is set")]
        public void GivenAuthorizationInvalidBearerTokenIsSet()
        {
            _baseSettings.Request.AddHeader("Authorization", "invalid bearer token");

        }

        [Given(@"Request configures as DEL")]
        public void GivenRequestConfiguresAsDEL()
        {

            _baseSettings.Request = new RestRequest("users/{id}", Method.DELETE);

        }

        [When(@"DEL request is executed")]
        public void WhenDELRequestIsExecuted()
        {
            _responseRaw = _baseSettings.RestClient.Execute<RootObject>(_baseSettings.Request);

            _jObjectDeserialized = JObject.Parse(_responseRaw.Content);

        }


    }
}
