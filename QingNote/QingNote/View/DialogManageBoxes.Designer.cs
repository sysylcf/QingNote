namespace cn.zuoanqh.open.QingNote.View
{
  partial class DialogManageBoxes
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogManageBoxes));
      this.lstBoxes = new System.Windows.Forms.ListBox();
      this.lblBoxDirectory = new System.Windows.Forms.Label();
      this.lblDateCreated = new System.Windows.Forms.Label();
      this.lblCreator = new System.Windows.Forms.Label();
      this.lblBoxIndexing = new System.Windows.Forms.Label();
      this.lstIndexItems = new System.Windows.Forms.ListBox();
      this.btnSaveBoxInfo = new System.Windows.Forms.Button();
      this.btnViewBoxContents = new System.Windows.Forms.Button();
      this.btnEditDateCreated = new System.Windows.Forms.Button();
      this.btnEditCreator = new System.Windows.Forms.Button();
      this.btnChooseIndexing = new System.Windows.Forms.Button();
      this.lblDescriptionCaption = new System.Windows.Forms.Label();
      this.btnUnlistBox = new System.Windows.Forms.Button();
      this.btnOpenBoxFolder = new System.Windows.Forms.Button();
      this.btnNewBox = new System.Windows.Forms.Button();
      this.txtBoxDescription = new System.Windows.Forms.TextBox();
      this.btnEditBoxName = new System.Windows.Forms.Button();
      this.btnAddChapter = new System.Windows.Forms.Button();
      this.btnDeleteChapter = new System.Windows.Forms.Button();
      this.btnMoveChapterUp = new System.Windows.Forms.Button();
      this.btnMoveChapterDown = new System.Windows.Forms.Button();
      this.btnAddCategory = new System.Windows.Forms.Button();
      this.btnDeleteCategory = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lstBoxes
      // 
      resources.ApplyResources(this.lstBoxes, "lstBoxes");
      this.lstBoxes.FormattingEnabled = true;
      this.lstBoxes.Name = "lstBoxes";
      this.lstBoxes.SelectedIndexChanged += new System.EventHandler(this.lstBoxes_SelectedIndexChanged);
      // 
      // lblBoxDirectory
      // 
      resources.ApplyResources(this.lblBoxDirectory, "lblBoxDirectory");
      this.lblBoxDirectory.Name = "lblBoxDirectory";
      // 
      // lblDateCreated
      // 
      resources.ApplyResources(this.lblDateCreated, "lblDateCreated");
      this.lblDateCreated.Name = "lblDateCreated";
      // 
      // lblCreator
      // 
      resources.ApplyResources(this.lblCreator, "lblCreator");
      this.lblCreator.Name = "lblCreator";
      // 
      // lblBoxIndexing
      // 
      resources.ApplyResources(this.lblBoxIndexing, "lblBoxIndexing");
      this.lblBoxIndexing.Name = "lblBoxIndexing";
      // 
      // lstIndexItems
      // 
      resources.ApplyResources(this.lstIndexItems, "lstIndexItems");
      this.lstIndexItems.FormattingEnabled = true;
      this.lstIndexItems.Name = "lstIndexItems";
      this.lstIndexItems.SelectedIndexChanged += new System.EventHandler(this.lstIndexItems_SelectedIndexChanged);
      // 
      // btnSaveBoxInfo
      // 
      resources.ApplyResources(this.btnSaveBoxInfo, "btnSaveBoxInfo");
      this.btnSaveBoxInfo.Name = "btnSaveBoxInfo";
      this.btnSaveBoxInfo.UseVisualStyleBackColor = true;
      this.btnSaveBoxInfo.Click += new System.EventHandler(this.btnSaveBoxInfo_Click);
      // 
      // btnViewBoxContents
      // 
      resources.ApplyResources(this.btnViewBoxContents, "btnViewBoxContents");
      this.btnViewBoxContents.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnViewBoxContents.Name = "btnViewBoxContents";
      this.btnViewBoxContents.UseVisualStyleBackColor = true;
      // 
      // btnEditDateCreated
      // 
      resources.ApplyResources(this.btnEditDateCreated, "btnEditDateCreated");
      this.btnEditDateCreated.Name = "btnEditDateCreated";
      this.btnEditDateCreated.UseVisualStyleBackColor = true;
      this.btnEditDateCreated.Click += new System.EventHandler(this.btnEditDateCreated_Click);
      // 
      // btnEditCreator
      // 
      resources.ApplyResources(this.btnEditCreator, "btnEditCreator");
      this.btnEditCreator.Name = "btnEditCreator";
      this.btnEditCreator.UseVisualStyleBackColor = true;
      this.btnEditCreator.Click += new System.EventHandler(this.btnEditCreator_Click);
      // 
      // btnChooseIndexing
      // 
      resources.ApplyResources(this.btnChooseIndexing, "btnChooseIndexing");
      this.btnChooseIndexing.Name = "btnChooseIndexing";
      this.btnChooseIndexing.UseVisualStyleBackColor = true;
      // 
      // lblDescriptionCaption
      // 
      resources.ApplyResources(this.lblDescriptionCaption, "lblDescriptionCaption");
      this.lblDescriptionCaption.Name = "lblDescriptionCaption";
      // 
      // btnUnlistBox
      // 
      resources.ApplyResources(this.btnUnlistBox, "btnUnlistBox");
      this.btnUnlistBox.Name = "btnUnlistBox";
      this.btnUnlistBox.UseVisualStyleBackColor = true;
      this.btnUnlistBox.Click += new System.EventHandler(this.btnUnlistBox_Click);
      // 
      // btnOpenBoxFolder
      // 
      resources.ApplyResources(this.btnOpenBoxFolder, "btnOpenBoxFolder");
      this.btnOpenBoxFolder.Name = "btnOpenBoxFolder";
      this.btnOpenBoxFolder.UseVisualStyleBackColor = true;
      this.btnOpenBoxFolder.Click += new System.EventHandler(this.btnOpenBoxFolder_Click);
      // 
      // btnNewBox
      // 
      resources.ApplyResources(this.btnNewBox, "btnNewBox");
      this.btnNewBox.Name = "btnNewBox";
      this.btnNewBox.UseVisualStyleBackColor = true;
      this.btnNewBox.Click += new System.EventHandler(this.btnNewBox_Click);
      // 
      // txtBoxDescription
      // 
      resources.ApplyResources(this.txtBoxDescription, "txtBoxDescription");
      this.txtBoxDescription.Name = "txtBoxDescription";
      // 
      // btnEditBoxName
      // 
      resources.ApplyResources(this.btnEditBoxName, "btnEditBoxName");
      this.btnEditBoxName.Name = "btnEditBoxName";
      this.btnEditBoxName.UseVisualStyleBackColor = true;
      this.btnEditBoxName.Click += new System.EventHandler(this.btnEditBoxName_Click);
      // 
      // btnAddChapter
      // 
      resources.ApplyResources(this.btnAddChapter, "btnAddChapter");
      this.btnAddChapter.Image = global::cn.zuoanqh.open.QingNote.IconScheme.Plus;
      this.btnAddChapter.Name = "btnAddChapter";
      this.btnAddChapter.UseVisualStyleBackColor = true;
      // 
      // btnDeleteChapter
      // 
      resources.ApplyResources(this.btnDeleteChapter, "btnDeleteChapter");
      this.btnDeleteChapter.Image = global::cn.zuoanqh.open.QingNote.IconScheme.Minus;
      this.btnDeleteChapter.Name = "btnDeleteChapter";
      this.btnDeleteChapter.UseVisualStyleBackColor = true;
      // 
      // btnMoveChapterUp
      // 
      resources.ApplyResources(this.btnMoveChapterUp, "btnMoveChapterUp");
      this.btnMoveChapterUp.Image = global::cn.zuoanqh.open.QingNote.IconScheme.Item_Up;
      this.btnMoveChapterUp.Name = "btnMoveChapterUp";
      this.btnMoveChapterUp.UseVisualStyleBackColor = true;
      // 
      // btnMoveChapterDown
      // 
      resources.ApplyResources(this.btnMoveChapterDown, "btnMoveChapterDown");
      this.btnMoveChapterDown.Image = global::cn.zuoanqh.open.QingNote.IconScheme.Item_Down;
      this.btnMoveChapterDown.Name = "btnMoveChapterDown";
      this.btnMoveChapterDown.UseVisualStyleBackColor = true;
      // 
      // btnAddCategory
      // 
      resources.ApplyResources(this.btnAddCategory, "btnAddCategory");
      this.btnAddCategory.Image = global::cn.zuoanqh.open.QingNote.IconScheme.Plus;
      this.btnAddCategory.Name = "btnAddCategory";
      this.btnAddCategory.UseVisualStyleBackColor = true;
      // 
      // btnDeleteCategory
      // 
      resources.ApplyResources(this.btnDeleteCategory, "btnDeleteCategory");
      this.btnDeleteCategory.Image = global::cn.zuoanqh.open.QingNote.IconScheme.Minus;
      this.btnDeleteCategory.Name = "btnDeleteCategory";
      this.btnDeleteCategory.UseVisualStyleBackColor = true;
      // 
      // DialogManageBoxes
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.btnMoveChapterDown);
      this.Controls.Add(this.btnMoveChapterUp);
      this.Controls.Add(this.btnDeleteChapter);
      this.Controls.Add(this.btnAddChapter);
      this.Controls.Add(this.txtBoxDescription);
      this.Controls.Add(this.btnNewBox);
      this.Controls.Add(this.btnOpenBoxFolder);
      this.Controls.Add(this.btnUnlistBox);
      this.Controls.Add(this.lblDescriptionCaption);
      this.Controls.Add(this.btnChooseIndexing);
      this.Controls.Add(this.btnEditCreator);
      this.Controls.Add(this.btnEditDateCreated);
      this.Controls.Add(this.btnViewBoxContents);
      this.Controls.Add(this.btnSaveBoxInfo);
      this.Controls.Add(this.lstIndexItems);
      this.Controls.Add(this.lblBoxIndexing);
      this.Controls.Add(this.lblCreator);
      this.Controls.Add(this.btnEditBoxName);
      this.Controls.Add(this.lblDateCreated);
      this.Controls.Add(this.lblBoxDirectory);
      this.Controls.Add(this.lstBoxes);
      this.Controls.Add(this.btnAddCategory);
      this.Controls.Add(this.btnDeleteCategory);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DialogManageBoxes";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListBox lstBoxes;
    private System.Windows.Forms.Label lblBoxDirectory;
    private System.Windows.Forms.Label lblDateCreated;
    private System.Windows.Forms.Label lblCreator;
    private System.Windows.Forms.Label lblBoxIndexing;
    private System.Windows.Forms.ListBox lstIndexItems;
    private System.Windows.Forms.Button btnSaveBoxInfo;
    private System.Windows.Forms.Button btnViewBoxContents;
    private System.Windows.Forms.Button btnEditDateCreated;
    private System.Windows.Forms.Button btnEditCreator;
    private System.Windows.Forms.Button btnChooseIndexing;
    private System.Windows.Forms.Label lblDescriptionCaption;
    private System.Windows.Forms.Button btnUnlistBox;
    private System.Windows.Forms.Button btnOpenBoxFolder;
    private System.Windows.Forms.Button btnNewBox;
    private System.Windows.Forms.TextBox txtBoxDescription;
    private System.Windows.Forms.Button btnEditBoxName;
    private System.Windows.Forms.Button btnAddChapter;
    private System.Windows.Forms.Button btnDeleteChapter;
    private System.Windows.Forms.Button btnMoveChapterUp;
    private System.Windows.Forms.Button btnMoveChapterDown;
    private System.Windows.Forms.Button btnAddCategory;
    private System.Windows.Forms.Button btnDeleteCategory;
  }
}