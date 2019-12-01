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
            MSGraphCrap Graph = new MSGraphCrap();///Local graph methods
            var KextRepo = Graph.GetKextRepo(utilities.DoesStringContain(args,"debug"));///Get the repo and activate error reporting if debug
            string ID = Graph.GetKextRepoID();//Get the sharing ID
            IDriveItemChildrenCollectionPage MainFolder = await KextRepo.Shares[ID].DriveItem.Children.Request().GetAsync();//get all the folders
            foreach(var folder in MainFolder)//for each folder
            {
                ;
            }
            //var MainFolder = KextRepo
        }
    }
}
