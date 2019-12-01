using System;
using System.Collections.Generic;
using Microsoft.Graph;
namespace iPatch
{
    class IPatch_main
    {
        public static async void Main(string[] args)
        {
            Utilities utilities = new Utilities();/// some stuff
            MSGraphCrap Graph = new MSGraphCrap();
            var KextRepo = Graph.GetKextRepo(utilities.DoesStringContain(args,"debug"));
            string ID = Graph.GetKextRepoID();
            IDriveItemChildrenCollectionPage MainFolder = await KextRepo.Shares[ID].DriveItem.Children.Request().GetAsync();
            foreach(var folder in MainFolder)
            {
                ;
            }
            //var MainFolder = KextRepo
        }
    }
}
