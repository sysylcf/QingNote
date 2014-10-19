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
using System.IO;
using Ookii.Dialogs;

namespace cn.zuoanqh.open.QingNote
{
  public partial class DialogNewBox : Form
  {
    public DialogNewBox()
    {
      InitializeComponent();
    }

    private void btnCommit_Click(object sender, EventArgs e)
    {
      CardBoxFileData boxData = new CardBoxFileData();
      boxData.title = txtBoxName.Text;
      if (rbtByCategory.Checked)
        boxData.indexing = Localization.FileKeywords.CardBox_Index_Category;
      else if (rbtByChapter.Checked)
        boxData.indexing = Localization.FileKeywords.CardBox_Index_Chapters;
      else
        boxData.indexing = Localization.FileKeywords.CardBox_Index_Chronological;

      boxData.datecreated = QNoteIO.formatNow();
      boxData.creator = SettingsFileData.getSettingItem(Localization.FileKeywords.Settings_UsersName);

      boxData.writeFile(txtBoxPath.Text);
      DirectoriesFileData.addCardBoxAndSave(txtBoxPath.Text);
    }

    private void btnBrowse_Click(object sender, EventArgs e)
    {
      VistaFolderBrowserDialog dlgChooseFolder = new VistaFolderBrowserDialog();
      DialogResult res = dlgChooseFolder.ShowDialog();
      if (res == DialogResult.OK) txtBoxPath.Text = dlgChooseFolder.SelectedPath;
    }

  }
}
