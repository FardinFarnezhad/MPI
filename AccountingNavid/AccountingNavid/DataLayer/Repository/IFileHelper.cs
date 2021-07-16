using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingNavid.DataLayer.Repository
{
    public interface IFileHelper
    {
        List<string> GetSpecialFolders();
        string GetLocalFilePath(string filename);
    }
}
