namespace cn.zuoanqh.open.QingNote
{
  partial class FrmMain
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
      this.lbl_D_CardBoxName = new System.Windows.Forms.Label();
      this.btnSwitchCardBox = new System.Windows.Forms.Button();
      this.btnCopyPath = new System.Windows.Forms.Button();
      this.tvwCards = new System.Windows.Forms.TreeView();
      this.tctIndexSearch = new System.Windows.Forms.TabControl();
      this.tabIndex = new System.Windows.Forms.TabPage();
      this.btnNewCard = new System.Windows.Forms.Button();
      this.btnSwitchIndexingMethod = new System.Windows.Forms.Button();
      this.tabSearch = new System.Windows.Forms.TabPage();
      this.rbtSearchKeywordOnly = new System.Windows.Forms.RadioButton();
      this.rbtSearchFullText = new System.Windows.Forms.RadioButton();
      this.txtSearchInput = new System.Windows.Forms.TextBox();
      this.lstSearchResults = new System.Windows.Forms.ListBox();
      this.lblCardTitle = new System.Windows.Forms.Label();
      this.txtCardContent = new System.Windows.Forms.TextBox();
      this.lstAttachments = new System.Windows.Forms.ListView();
      this.btnOpenAttachmentFolder = new System.Windows.Forms.Button();
      this.lblKeyWords = new System.Windows.Forms.Label();
      this.btnDeleteCard = new System.Windows.Forms.Button();
      this.btnEditMeta = new System.Windows.Forms.Button();
      this.btnSaveCard = new System.Windows.Forms.Button();
      this.lblMessage = new System.Windows.Forms.Label();
      this.tctIndexSearch.SuspendLayout();
      this.tabIndex.SuspendLayout();
      this.tabSearch.SuspendLayout();
      this.SuspendLayout();
      // 
      // lbl_D_CardBoxName
      // 
      resources.ApplyResources(this.lbl_D_CardBoxName, "lbl_D_CardBoxName");
      this.lbl_D_CardBoxName.Name = "lbl_D_CardBoxName";
      // 
      // btnSwitchCardBox
      // 
      resources.ApplyResources(this.btnSwitchCardBox, "btnSwitchCardBox");
      this.btnSwitchCardBox.Name = "btnSwitchCardBox";
      this.btnSwitchCardBox.UseVisualStyleBackColor = true;
      // 
      // btnCopyPath
      // 
      resources.ApplyResources(this.btnCopyPath, "btnCopyPath");
      this.btnCopyPath.Name = "btnCopyPath";
      this.btnCopyPath.UseVisualStyleBackColor = true;
      // 
      // tvwCards
      // 
      resources.ApplyResources(this.tvwCards, "tvwCards");
      this.tvwCards.Name = "tvwCards";
      // 
      // tctIndexSearch
      // 
      resources.ApplyResources(this.tctIndexSearch, "tctIndexSearch");
      this.tctIndexSearch.Controls.Add(this.tabIndex);
      this.tctIndexSearch.Controls.Add(this.tabSearch);
      this.tctIndexSearch.Name = "tctIndexSearch";
      this.tctIndexSearch.SelectedIndex = 0;
      // 
      // tabIndex
      // 
      this.tabIndex.Controls.Add(this.btnNewCard);
      this.tabIndex.Controls.Add(this.btnSwitchIndexingMethod);
      this.tabIndex.Controls.Add(this.tvwCards);
      resources.ApplyResources(this.tabIndex, "tabIndex");
      this.tabIndex.Name = "tabIndex";
      this.tabIndex.UseVisualStyleBackColor = true;
      // 
      // btnNewCard
      // 
      resources.ApplyResources(this.btnNewCard, "btnNewCard");
      this.btnNewCard.Name = "btnNewCard";
      this.btnNewCard.UseVisualStyleBackColor = true;
      // 
      // btnSwitchIndexingMethod
      // 
      resources.ApplyResources(this.btnSwitchIndexingMethod, "btnSwitchIndexingMethod");
      this.btnSwitchIndexingMethod.Name = "btnSwitchIndexingMethod";
      this.btnSwitchIndexingMethod.UseVisualStyleBackColor = true;
      // 
      // tabSearch
      // 
      this.tabSearch.Controls.Add(this.rbtSearchKeywordOnly);
      this.tabSearch.Controls.Add(this.rbtSearchFullText);
      this.tabSearch.Controls.Add(this.txtSearchInput);
      this.tabSearch.Controls.Add(this.lstSearchResults);
      resources.ApplyResources(this.tabSearch, "tabSearch");
      this.tabSearch.Name = "tabSearch";
      this.tabSearch.UseVisualStyleBackColor = true;
      // 
      // rbtSearchKeywordOnly
      // 
      resources.ApplyResources(this.rbtSearchKeywordOnly, "rbtSearchKeywordOnly");
      this.rbtSearchKeywordOnly.Checked = true;
      this.rbtSearchKeywordOnly.Name = "rbtSearchKeywordOnly";
      this.rbtSearchKeywordOnly.TabStop = true;
      this.rbtSearchKeywordOnly.UseVisualStyleBackColor = true;
      // 
      // rbtSearchFullText
      // 
      resources.ApplyResources(this.rbtSearchFullText, "rbtSearchFullText");
      this.rbtSearchFullText.Name = "rbtSearchFullText";
      this.rbtSearchFullText.UseVisualStyleBackColor = true;
      // 
      // txtSearchInput
      // 
      resources.ApplyResources(this.txtSearchInput, "txtSearchInput");
      this.txtSearchInput.Name = "txtSearchInput";
      // 
      // lstSearchResults
      // 
      resources.ApplyResources(this.lstSearchResults, "lstSearchResults");
      this.lstSearchResults.FormattingEnabled = true;
      this.lstSearchResults.Name = "lstSearchResults";
      // 
      // lblCardTitle
      // 
      resources.ApplyResources(this.lblCardTitle, "lblCardTitle");
      this.lblCardTitle.Name = "lblCardTitle";
      // 
      // txtCardContent
      // 
      resources.ApplyResources(this.txtCardContent, "txtCardContent");
      this.txtCardContent.Name = "txtCardContent";
      // 
      // lstAttachments
      // 
      resources.ApplyResources(this.lstAttachments, "lstAttachments");
      this.lstAttachments.Name = "lstAttachments";
      this.lstAttachments.UseCompatibleStateImageBehavior = false;
      // 
      // btnOpenAttachmentFolder
      // 
      resources.ApplyResources(this.btnOpenAttachmentFolder, "btnOpenAttachmentFolder");
      this.btnOpenAttachmentFolder.Name = "btnOpenAttachmentFolder";
      this.btnOpenAttachmentFolder.UseVisualStyleBackColor = true;
      // 
      // lblKeyWords
      // 
      resources.ApplyResources(this.lblKeyWords, "lblKeyWords");
      this.lblKeyWords.Name = "lblKeyWords";
      // 
      // btnDeleteCard
      // 
      resources.ApplyResources(this.btnDeleteCard, "btnDeleteCard");
      this.btnDeleteCard.Name = "btnDeleteCard";
      this.btnDeleteCard.UseVisualStyleBackColor = true;
      // 
      // btnEditMeta
      // 
      resources.ApplyResources(this.btnEditMeta, "btnEditMeta");
      this.btnEditMeta.Name = "btnEditMeta";
      this.btnEditMeta.UseVisualStyleBackColor = true;
      // 
      // btnSaveCard
      // 
      resources.ApplyResources(this.btnSaveCard, "btnSaveCard");
      this.btnSaveCard.Name = "btnSaveCard";
      this.btnSaveCard.UseVisualStyleBackColor = true;
      // 
      // lblMessage
      // 
      resources.ApplyResources(this.lblMessage, "lblMessage");
      this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblMessage.Name = "lblMessage";
      // 
      // FrmMain
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.Controls.Add(this.lblMessage);
      this.Controls.Add(this.btnSaveCard);
      this.Controls.Add(this.btnEditMeta);
      this.Controls.Add(this.btnDeleteCard);
      this.Controls.Add(this.lblKeyWords);
      this.Controls.Add(this.btnOpenAttachmentFolder);
      this.Controls.Add(this.lstAttachments);
      this.Controls.Add(this.txtCardContent);
      this.Controls.Add(this.lblCardTitle);
      this.Controls.Add(this.tctIndexSearch);
      this.Controls.Add(this.btnCopyPath);
      this.Controls.Add(this.btnSwitchCardBox);
      this.Controls.Add(this.lbl_D_CardBoxName);
      this.Name = "FrmMain";
      this.Load += new System.EventHandler(this.FrmMain_Load);
      this.tctIndexSearch.ResumeLayout(false);
      this.tabIndex.ResumeLayout(false);
      this.tabSearch.ResumeLayout(false);
      this.tabSearch.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lbl_D_CardBoxName;
    private System.Windows.Forms.Button btnSwitchCardBox;
    private System.Windows.Forms.Button btnCopyPath;
    private System.Windows.Forms.TreeView tvwCards;
    private System.Windows.Forms.TabControl tctIndexSearch;
    private System.Windows.Forms.TabPage tabIndex;
    private System.Windows.Forms.TabPage tabSearch;
    private System.Windows.Forms.TextBox txtSearchInput;
    private System.Windows.Forms.ListBox lstSearchResults;
    private System.Windows.Forms.Button btnSwitchIndexingMethod;
    private System.Windows.Forms.RadioButton rbtSearchKeywordOnly;
    private System.Windows.Forms.RadioButton rbtSearchFullText;
    private System.Windows.Forms.Label lblCardTitle;
    private System.Windows.Forms.TextBox txtCardContent;
    private System.Windows.Forms.ListView lstAttachments;
    private System.Windows.Forms.Button btnOpenAttachmentFolder;
    private System.Windows.Forms.Label lblKeyWords;
    private System.Windows.Forms.Button btnDeleteCard;
    private System.Windows.Forms.Button btnEditMeta;
    private System.Windows.Forms.Button btnSaveCard;
    private System.Windows.Forms.Button btnNewCard;
    private System.Windows.Forms.Label lblMessage;
  }
}

