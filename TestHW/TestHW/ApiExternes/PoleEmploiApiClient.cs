using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Newtonsoft.Json;

using TestHW.Models;

namespace TestHW.ApiExternes
{
    public class PoleEmploiApiClient
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Url de l'api de recherche de pole emploi
        /// </summary>
        private const string URL_API_SEARCH_OFFER = @"https://api.francetravail.io/partenaire/offresdemploi/v2/offres/search";

        public PoleEmploiApiClient()
        {
            _client = new HttpClient();
            // TODO gérer le token via PoleEmploiApiAuthorize.Connect
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "djp5TYgl1tol2hN2Ydy32pbjZM8");
        }

        public async Task<List<Offre>> GetJobOffersAsync(List<int> villesInsee)
        {
            var builder = new UriBuilder(URL_API_SEARCH_OFFER);
            NameValueCollection query = HttpUtility.ParseQueryString(builder.Query);

            query.Add("commune", String.Join(",", villesInsee));

            builder.Query = query.ToString();
            var urlAvecQuery = builder.ToString();

            var response = await _client.GetStringAsync(urlAvecQuery);
            return JsonConvert.DeserializeObject<List<Offre>>(response) ?? new List<Offre>();
        }
    }
}
