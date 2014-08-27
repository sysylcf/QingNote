using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.QingNote.IO
{
  class CardFileData
  {
    public string name, creater, category, chapterName, dateCreated, text;
    public HashSet<string> keywords;

    public static CardFileData readFile()
    { return null;}


    public CardFileData()
    { }
    public CardFileData(string name, string creater, string dateCreated, string text)
    { }
  }
}
