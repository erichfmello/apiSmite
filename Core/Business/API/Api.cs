using RestSharp;
using System.Reflection;
using System.Text.Json;

namespace Core.Business.API
{
    public class Api
    {
        private readonly string baseUrl;
        private readonly string devID;
        private readonly string authKey;
        private string timespan;

        public Api(string date)
        {
            baseUrl = "https://api.smitegame.com/smiteapi.svc";
            devID = "3876";
            authKey = "DDE5482EC2BB4488A92BD32A1E523D25";
            timespan = date;
        }

        public List<Models.God.God>? GodList()
        {
            int language = (int)Models.Language.LanguageTypes.Portuguese;
            string signatureKey = "getgods";
            string signature = GetMD5Hash($"{devID}{signatureKey}{authKey}{timespan}");

            string? sessionID = CreateSession();
            string url = $"/{signatureKey}JSON/{devID}/{signature}/{sessionID}/{timespan}/{language}";

            return ApiRequest<List<Models.God.God>>(url);
        }

        public List<Models.Item.Item>? ItemList()
        {
            int language = (int)Models.Language.LanguageTypes.Portuguese;
            string signatureKey = "getitems";
            string signature = GetMD5Hash($"{devID}{signatureKey}{authKey}{timespan}");

            string? sessionID = CreateSession();
            string url = $"/{signatureKey}JSON/{devID}/{signature}/{sessionID}/{timespan}/{language}";

            return ApiRequest<List<Models.Item.Item>>(url);
        }

        public List<Models.Item.ItemRecomended>? ItemRecomendedList(int godID)
        {
            int language = (int)Models.Language.LanguageTypes.Portuguese;
            string signatureKey = "getgodrecommendeditems";
            string signature = GetMD5Hash($"{devID}{signatureKey}{authKey}{timespan}");

            string? sessionID = CreateSession();
            string url = $"/{signatureKey}JSON/{devID}/{signature}/{sessionID}/{timespan}/{godID}/{language}";

            return ApiRequest<List<Models.Item.ItemRecomended>>(url);
        }

        #region privateMethods
        private string? CreateSession()
        {
            string signatureKey = "createsession";
            string signature = GetMD5Hash($"{devID}{signatureKey}{authKey}{timespan}");
            string url = $"/{signatureKey}JSON/{devID}/{signature}/{timespan}";

            return ApiRequest<Models.Session.Session>(url)?.session_id;
        }

        private static string GetMD5Hash(string input)
        {
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            bytes = md5.ComputeHash(bytes);
            var sb = new System.Text.StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
        #endregion privateMethods

        #region API
        private T? ApiRequest<T>(string url)
        {
            RestClient restClient = RestClient();

            RestRequest restRequest = new(url, Method.Get);

            var response = restClient.Execute(restRequest);

            if (!response.IsSuccessful)
                throw new Exception($"ERROR: RestSharpRequest -- {MethodBase.GetCurrentMethod()}");

            response.Content ??= "";

            return JsonSerializer.Deserialize<T>(response.Content);
        }

        private RestClient RestClient()
        {
            return new RestClient(baseUrl);
        }
        #endregion API


    }
}
