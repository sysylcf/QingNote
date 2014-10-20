using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.QingNote.View
{
  static class ViewUtil
  {
    public static string FormatDialogTitle(string title)
    {
      return Localization.Messages.Dialog_Title_Prefix + title;
    }
  }
}
