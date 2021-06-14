using RestSharp;


namespace RestAPIExampleProject.Settings
{
    public class BaseSettings
    {
        //       public Uri GoRestBaseURL { get; set; }

        public IRestRequest Request { get; set; }

        //       public IRestResponse<RootObject> Response { get; set; }

        public RestClient RestClient { get; set; } = new RestClient();

    }
}
