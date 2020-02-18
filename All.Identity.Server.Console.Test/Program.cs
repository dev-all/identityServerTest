using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace All.Identity.Server.Console.Test
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    MainAsync().GetAwaiter().GetResult();
        //}

           
        static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        
        private static async Task MainAsync()
        {
            /// primer paso obtener un token

            var discoveryClient = await DiscoveryClient.GetAsync("http://localhost:5000");
            if (discoveryClient.IsError)
            {
                throw new Exception(" error en discoverycliente");
            }

            var Token = new TokenClient(discoveryClient.TokenEndpoint, "client1", "claveQueSeDaAlCliente");
            //en base al token obtenido se busca el recurso del api 
            var TokenResponse = await Token.RequestClientCredentialsAsync("resourceAll");

            if (TokenResponse.IsError)
            {
                throw new Exception("Error en TokenResponse");
            }

            Newtonsoft.Json.Linq.JObject TokenJson = TokenResponse.Json;


            /// segundo paso hacer la llamada con el token  la api

            var client = new HttpClient();
            client.SetBearerToken(TokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:5001/api/TestIdentityServer");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("error llamando el recurso");
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
            }

        }



    }
}
