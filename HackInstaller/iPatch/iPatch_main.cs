using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Graph;
namespace iPatch
{
    class IPatch_main
    {
        public static GraphServiceClient KextRepo;
        public static string ID;
        public static IDriveItemChildrenCollectionPage MainFolder;
        public static async void GetKext(string KextName)
        {
            string FolderID, ItemID;
            ItemID = "NOT FOUND";
            foreach (var folder in MainFolder)//for each folder
            {
                if (folder.Name == KextName)
                {
                    FolderID = folder.Id;
                    IDriveItemChildrenCollectionPage FolderContent = await KextRepo.Shares[ID].Items[FolderID].Children.Request().GetAsync();
                    foreach(var Item in FolderContent)
                    {
                        if(Item.File.MimeType == "application/zip")
                        {
                            ItemID = Item.Id;
                        }
                    }
                    break;
                }
            }
            if (ItemID != "NOT FOUND")
            {
                var FileContent = await KextRepo.Shares[ID].Items[ItemID].Content.Request().GetAsync();
                using var fileStream = new FileStream(KextName, FileMode.Create, System.IO.FileAccess.Write);
                FileContent.CopyTo(fileStream);
            }
        }
        public static async void IPS_Initialise(string[] args)
        {
            Utilities utilities = new Utilities();/// some stuff
            MSGraphCrap Graph = new MSGraphCrap();///Local graph methods
            KextRepo = Graph.GetKextRepo(utilities.DoesStringContain(args,"debug"));///Get the repo and activate error reporting if debug
            ID = Graph.GetKextRepoID();//Get the sharing ID
            MainFolder = await KextRepo.Shares[ID].DriveItem.Children.Request().GetAsync();//get all the folders
            //var MainFolder = KextRepo
        }
    }
}
