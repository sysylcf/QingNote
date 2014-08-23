using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cn.zuoanqh.open.QingNote
{
  public partial class FrmMain : Form
  {
  public static readonly int PADDING = 3;
    public FrmMain()
    {
      //System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
      InitializeComponent();
      //txtCardContent.Text=""+txtCardContent.Height;
      txtCardContent.Height=lblKeyWords.Top-PADDING-txtCardContent.Top;
      lstSearchResults.Height=txtSearchInput.Top-PADDING-lstSearchResults.Top;
      //txtCardContent.Text+=""+txtCardContent.Height;
    }

    private void FrmMain_Load(object sender, EventArgs e)
    {
      
    }

  }
}
