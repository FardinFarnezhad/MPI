using AccountingNavid.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AccountingNavid.DataLayer.Cummon.Helpers
{
    public static class GeneralHelper
    {
        public static string GetLocalFilePath(string parameter)
        {
            return Xamarin.Forms.DependencyService.Get<IFileHelper>().GetLocalFilePath(parameter);
        }
        public static List<string> GetSpecialFoldersPath()
        {
            return Xamarin.Forms.DependencyService.Get<IFileHelper>().GetSpecialFolders();
        }
    }
}
