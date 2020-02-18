using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace All.Identity.Server
{
    public static class Config
    {


        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new ApiResource[]
            {
                new ApiResource("reourceAll", "Recurso al q puede acceder el cliente ")


            };
        }


        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                // client credentials flow client
                new Client
                {
                    ClientId = "client1",
                    ClientName = "Sebastian",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("claveQueSeDaAlCliente".Sha256()) },

                    AllowedScopes = { "reourceAll" }
                },
                
                // client credentials flow client
                new Client
                {
                    ClientId = "client2",
                    ClientName = "Mauricio",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("claveParaMauricio".Sha256()) },

                    AllowedScopes = { "reourceAll" }
                }

            };
        }


    }
}
