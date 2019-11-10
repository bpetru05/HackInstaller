using System;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;

namespace iPatch
{
    class iPatch_main
    {
        private static string get_kext_repo_url()
        {
            string base64Value = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("https://onedrive.live.com/redir?resid=1231244193912!12&authKey=1201919!12921!1"));
            string encodedUrl = "u!" + base64Value.TrimEnd('=').Replace('/', '_').Replace('+', '-');
            return encodedUrl;
        }
        private static GraphServiceClient Graph_authenticate()
        {
            IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
                .Create("8aeb94e0-3a44-4299-a393-3174cc2dd518")
                .WithClientSecret("f383e6bb-273e-4c1e-8398-64a8c6c60f72")
                .Build();
            AuthorizationCodeProvider authenticationProvider = new AuthorizationCodeProvider(confidentialClientApplication);
            GraphServiceClient kext_getter = new GraphServiceClient(authenticationProvider);
            return kext_getter;
        }
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string KextRepoURL = get_kext_repo_url();
            GraphServiceClient KextRepo = Graph_authenticate();
           ///Not functional
            var MainFolder = await KextRepo.Shares.RequestUrl();            
        }
    }
}
