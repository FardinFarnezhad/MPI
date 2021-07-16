using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AccountingNavid.DataLayer.Repository;
using AccountingNavid.iOS.DependencyServices;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace AccountingNavid.iOS.DependencyServices
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, filename);
        }
        public List<string> GetSpecialFolders()
        {
            List<string> folders = new List<string>();
            foreach (var folder in Enum.GetValues(typeof(System.Environment.SpecialFolder)))
            {
                if (!string.IsNullOrEmpty(System.Environment.GetFolderPath((System.Environment.SpecialFolder)folder)))
                {
                    folders.Add($"{folder}={System.Environment.GetFolderPath((System.Environment.SpecialFolder)folder)}");
                }
            }
            return folders;
        }
    }
}