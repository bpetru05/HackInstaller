using System;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
namespace iPatch
{
    class OneDriveHandler
    {
        private const string Link = "https://1drv.ms/f/s!AiP7m5LaOED-m-J8-MLJGnOgAqnjGw";

        public static string GetKextRepoID()
        {
            string encodedUrl = Link;
            encodedUrl = "s" + encodedUrl.TrimStart("https://1drv.ms/f/".ToCharArray());//get the sharing ID
            return encodedUrl;
        }
        private static async GraphServiceClient Graph_Authenticate(bool is_debug)
        {
            Console.WriteLine("Authentifying with Graph");
            try
            {
                return kext_getter;//return it to caller
            }
            catch (Exception e)
            {
                //DEBUG
                Console.WriteLine("Something went wrong");
                if (is_debug)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine(e.InnerException);
                    Console.WriteLine(e.Source);
                }
            }
            return;
        }
        public static async GraphServiceClient GetKextRepo(bool is_debug)
        {
            IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
            .Create("8aeb94e0-3a44-4299-a393-3174cc2dd518")
            .WithClientSecret("3xrVt:]K3iy[?CDDHxvGYT9Kz6:4HP2=")
            .Build();//Build the auth keys
            string[] scopes = new string[2] { "Files.Read.All", "Sites.Read.All" };
            AuthorizationCodeProvider authenticationProvider = new AuthorizationCodeProvider(confidentialClientApplication);
            AuthenticationResult result = await authenticationProvider.ClientApplication.AcquireTokenSilent(scopes).ExecuteAsync();
            GraphServiceClient graphServiceClient = new GraphServiceClient(authenticationProvider);//obtaing the connection to graph
            if (graphServiceClient == null)//check connection
            {
                throw new System.AccessViolationException("Cannot access the KextRepo. Contact the software writer");//OOOF
            }
            return graphServiceClient;//retunn the bad boy
        }
    }
}
