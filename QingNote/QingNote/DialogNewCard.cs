using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cn.zuoanqh.open.QingNote
{
  public partial class DialogNewCard : Form
  {
    public DialogNewCard()
    {
      InitializeComponent();
    }

    private void lstKeywords_SelectedIndexChanged(object sender, EventArgs e)
    {
      btnRemoveKeyword.BackgroundImage = (lstKeywords.SelectedItems.Count == 0) ?
        IconScheme.Remove_Multiple : IconScheme.Remove_Single;
    }

  }
}
