using RestAPIExampleProject.Settings;
using TechTalk.SpecFlow;

namespace RestAPIExampleProject.Hooks
{
    [Binding]
    public class Hooks
    {

        private BaseSettings _baseSettings;

        public Hooks(BaseSettings baseSettings)
        {
            this._baseSettings = baseSettings;
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            _baseSettings.RestClient.BaseUrl = new System.Uri(UrlHelper.BaseURL);

        }

        [AfterScenario]
        public void AfterScenario()
        {

        }
    }
}
