using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using TestHW.Models;

namespace TestHW.ApiExternes
{
    public class PoleEmploiApiAuthorize
    {
        private readonly HttpClient _client;

        // Todo sécuriser l'id+secret key (wallet windows, regkey, fichier chiffré, à définir)
        private const string ID_CLIENT = "PAR_testhw_3a56b2f2ecac7f93fb2d88edf41a941e08d9fa1f2402ff93f7ff2c3d499475fb";
        private const string SECRET_KEY = "ce216ab3b1cdd104a127b5b698a351e74dc632f07f69a192b1750ffa7920a7c1";


        private const string URL_API_AUTHORIZE_INDIVIDU = "https://authentification-candidat.francetravail.fr/connexion/oauth2/authorize";

        public PoleEmploiApiAuthorize()
        {
            _client = new HttpClient();
        }

        public async Task<string> Connect()
        {
            // Todo faire marcher 
            // https://francetravail.io/compte/applications/10773
            // https://francetravail.io/produits-partages/documentation/open-id-connect/authentifier-utilisateur

            string url = $"{URL_API_AUTHORIZE_INDIVIDU}?realm=individu&response_type=code&client_id={ID_CLIENT}";
            string response = await _client.GetStringAsync(url);
            return response;
        }
    }
}
