using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.QingNote.IO
{
  class DirectoriesFileData
  {
    public static readonly string FILE_NAME = Localization.FileKeywords.FileName_Directory + Resources.FilePostfix;
    
    public delegate void onItemAdded(string absolutePath);
    public delegate void onItemDeleted(string absolutePath);

    static DirectoriesFileData()
    {
    }
  }
}
