using System;
using System.Collections.Generic;
using Microsoft.Graph;
namespace iPatch
{
    class iPatch_main
    {
        public static async void main(string[] args)
        {
            Utilities utilities = new Utilities();/// some stuff
            MSGraphCrap Graph = new MSGraphCrap();
            var KextRepo = Graph.GetKextRepo(utilities.does_string_contain(args,"debug"));
            string ID = Graph.get_kext_repo_id();
            IDriveItemChildrenCollectionPage MainFolder = await KextRepo.Shares[ID].DriveItem.Children.Request().GetAsync();
            foreach(var folder in MainFolder)
            {
                var SelectedFolder = await KextRepo.Shares[ID].DriveItem.ItemWithPath("").Request().GetAsync();
            }
            //var MainFolder = KextRepo
        }
    }
}
