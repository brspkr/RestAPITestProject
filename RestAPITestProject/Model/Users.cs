using Newtonsoft.Json;


namespace RestAPIExampleProject.Model
{

    public class RootObject
    {
        [JsonProperty("code")]
        public int code { get; set; }

        [JsonProperty("meta")]
        public Meta meta { get; set; }

        [JsonProperty("data")]
        public Data data { get; set; }

        //[JsonProperty("data")]
        //public List<Data> data { get; set; }

    }

    public class Meta
    {
        [JsonProperty("pagination")]
        public Pagination pagination { get; set; }

    }

    public class Pagination
    {

        [JsonProperty("total")]
        public int total { get; set; }

        [JsonProperty("pages")]
        public int pages { get; set; }

        [JsonProperty("page")]
        public int page { get; set; }

        [JsonProperty("limit")]
        public int limit { get; set; }

    }

    public class Data
    {
        [JsonProperty("id")]
        public int id { get; set; }


        [JsonProperty("name")]
        public string name { get; set; }


        [JsonProperty("email")]
        public string email { get; set; }


        [JsonProperty("gender")]
        public string gender { get; set; }


        [JsonProperty("status")]
        public string status { get; set; }


        [JsonProperty("created_at")]
        public string created_at { get; set; }


        [JsonProperty("updated_at")]
        public string updated_at { get; set; }


    }
}
