using System;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;

namespace iPatch
{
    class Utilities
    {
        public bool does_string_contain(string[] input, string check)
        {
            foreach(var i in input)
            {
                if (i == check)
                    return true;
            }
            return false;
        }
    }
    class iPatch_main
    {
        private static string get_kext_repo_id()
        {
            string base64Value = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("https://onedrive.live.com/redir?resid=1231244193912!12&authKey=1201919!12921!1"));
            string encodedUrl = "u!" + base64Value.TrimEnd('=').Replace('/', '_').Replace('+', '-');
            return encodedUrl;
        }
        private static GraphServiceClient Graph_authenticate(bool is_debug)
        {
            Console.WriteLine("Authentifying with Graph");
            try
            {
                IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
                    .Create("8aeb94e0-3a44-4299-a393-3174cc2dd518")
                    .WithClientSecret("f383e6bb-273e-4c1e-8398-64a8c6c60f72")
                    .Build();
                AuthorizationCodeProvider authenticationProvider = new AuthorizationCodeProvider(confidentialClientApplication);
                GraphServiceClient kext_getter = new GraphServiceClient(authenticationProvider);
                return kext_getter;
            }
            catch(Exception e)
            {
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
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Utilities URepresentant = new Utilities();
            string KextRepoID = get_kext_repo_id();
            if(KextRepoID==null)
            {
                throw new System.AccessViolationException("Cannot access the KextRepo. Contact the software writer");
            }
            GraphServiceClient KextRepo = Graph_authenticate(URepresentant.does_string_contain(args,"debug"));
            ///Probably functional
            var MainFolder = KextRepo.Shares[KextRepoID].DriveItem.Request().Expand("children");
            
        }
    }
}
