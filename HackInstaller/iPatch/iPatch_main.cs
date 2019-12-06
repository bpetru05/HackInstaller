using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Graph;
namespace iPatch
{
    public static class IPatch_main
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
            KextRepo = OneDriveHandler.GetKextRepo(Utilities.DoesStringContain(args,"debug"));///Get the repo and activate error reporting if debug
            ID = OneDriveHandler.GetKextRepoID();//Get the sharing ID
            MainFolder = await KextRepo.Shares[ID].DriveItem.Children.Request().GetAsync();//get all the folders
            //var MainFolder = KextRepo
        }
        public static void Main()
        {
            IPS_Initialise(new string[1] { "" });
        }
    }
}
