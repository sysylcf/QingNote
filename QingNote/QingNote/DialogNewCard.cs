using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cn.zuoanqh.open.QingNote.IO;

namespace cn.zuoanqh.open.QingNote
{
  public partial class DialogNewCard : Form
  {
    private CardBoxFileData boxData;
    public DialogNewCard(CardBoxFileData boxData)
    {
      InitializeComponent();
      this.boxData = boxData;
    }

    private void lstKeywords_SelectedIndexChanged(object sender, EventArgs e)
    {
      btnRemoveKeyword.BackgroundImage = (lstKeywords.SelectedItems.Count == 0) ?
        IconScheme.Remove_Multiple : IconScheme.Remove_Single;
    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void DialogNewCard_Load(object sender, EventArgs e)
    {
      DateTime now = System.DateTime.Now;
      lblDate.Text = String.Format(Localization.Settings.Format_YMD, now.Year, now.Month, now.Day);
      lblCreater.Text=IO.SettingsFileData.getSettingItem(Localization.FileKeywords.Settings_UsersName);
      txtCategory.Items.AddRange(boxData.categories.ToArray());
      txtChapter.Items.AddRange(boxData.chapters.ToArray());
      txtNewKeyword.Items.AddRange(boxData.keywords.ToArray());
    }

  }
}
