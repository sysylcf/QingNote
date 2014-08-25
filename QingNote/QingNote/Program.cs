using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cn.zuoanqh.open.QingNote
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
    List<string> f = ZDictionaryFileIO.findCultureNames("Settings");
    foreach(string s in f) Console.WriteLine(s);
    //Application.
      //Application.EnableVisualStyles();
      //Application.SetCompatibleTextRenderingDefault(false);
      //Application.Run(new FrmMain());
    }
  }
}
