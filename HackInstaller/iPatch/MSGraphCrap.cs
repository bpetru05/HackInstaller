using System;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
namespace iPatch
{
    class MSGraphCrap
    {
        public string GetKextRepoID()
        {
            string encodedUrl = "https://1drv.ms/f/s!AiP7m5LaOED-m-J8-MLJGnOgAqnjGw";
            encodedUrl = "s" + encodedUrl.TrimStart("https://1drv.ms/f/".ToCharArray());//get the sharing ID
            return encodedUrl;
        }
        private GraphServiceClient Graph_Authenticate(bool is_debug)
        {
            Console.WriteLine("Authentifying with Graph");
            try
            {
                IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
                    .Create("8aeb94e0-3a44-4299-a393-3174cc2dd518")
                    .WithClientSecret("f383e6bb-273e-4c1e-8398-64a8c6c60f72")
                    .Build();//Build the auth keys
                AuthorizationCodeProvider authenticationProvider = new AuthorizationCodeProvider(confidentialClientApplication);
                GraphServiceClient kext_getter = new GraphServiceClient(authenticationProvider);//obtaing the connection to graph
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
            return null;
        }
        public GraphServiceClient GetKextRepo(bool is_debug)
        {
            GraphServiceClient graphServiceClient = Graph_Authenticate(is_debug);//Get connection
            if (graphServiceClient == null)//check connection
            {
                throw new System.AccessViolationException("Cannot access the KextRepo. Contact the software writer");//OOOF
            }
            return graphServiceClient;
        }
    }
}
