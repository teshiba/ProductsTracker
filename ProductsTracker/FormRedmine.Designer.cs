namespace ProductsTracker;

partial class FormRedmine
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
        if (disposing && (components != null)) {
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
        components = new System.ComponentModel.Container();
        listViewTicket = new ListView();
        columnHeaderId = new ColumnHeader();
        columnHeaderStatus = new ColumnHeader();
        columnHeaderSubject = new ColumnHeader();
        columnHeaderTargetId = new ColumnHeader();
        columnHeaderDescription = new ColumnHeader();
        contextMenuStripIssueList = new ContextMenuStrip(components);
        textBoxManageUrl = new TextBox();
        label1 = new Label();
        textBoxManageUser = new TextBox();
        label4 = new Label();
        groupBox1 = new GroupBox();
        checkBoxManageUsingProxy = new CheckBox();
        textBoxCustomFieldIndexOfTrackingId = new TextBox();
        labelCustomFieldIndexOfTrackingId = new Label();
        textBoxManageProjectId = new TextBox();
        label7 = new Label();
        textBoxManagePassword = new TextBox();
        label5 = new Label();
        groupBox2 = new GroupBox();
        checkBoxTargetUsingProxy = new CheckBox();
        textBoxTargetProjectId = new TextBox();
        label8 = new Label();
        textBoxTargetUrl = new TextBox();
        textBoxTargetUser = new TextBox();
        textBoxTargetPassword = new TextBox();
        label2 = new Label();
        label3 = new Label();
        label6 = new Label();
        buttonGetTicket = new Button();
        labelError = new Label();
        labelReadUrl = new Label();
        buttonCopy = new Button();
        tabControl1 = new TabControl();
        tabPage1 = new TabPage();
        checkBoxHideClosed = new CheckBox();
        tabPage2 = new TabPage();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        tabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        tabPage2.SuspendLayout();
        SuspendLayout();
        // 
        // listViewTicket
        // 
        listViewTicket.Activation = ItemActivation.OneClick;
        listViewTicket.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        listViewTicket.Columns.AddRange(new ColumnHeader[] { columnHeaderId, columnHeaderStatus, columnHeaderSubject, columnHeaderTargetId, columnHeaderDescription });
        listViewTicket.ContextMenuStrip = contextMenuStripIssueList;
        listViewTicket.FullRowSelect = true;
        listViewTicket.GridLines = true;
        listViewTicket.Location = new Point(8, 53);
        listViewTicket.MultiSelect = false;
        listViewTicket.Name = "listViewTicket";
        listViewTicket.Size = new Size(1273, 894);
        listViewTicket.TabIndex = 0;
        listViewTicket.UseCompatibleStateImageBehavior = false;
        listViewTicket.View = View.Details;
        listViewTicket.Click += ListViewTicket_Click;
        // 
        // columnHeaderId
        // 
        columnHeaderId.Text = "ID";
        columnHeaderId.Width = 100;
        // 
        // columnHeaderStatus
        // 
        columnHeaderStatus.Text = "Status";
        // 
        // columnHeaderSubject
        // 
        columnHeaderSubject.Text = "題名";
        columnHeaderSubject.Width = 240;
        // 
        // columnHeaderTargetId
        // 
        columnHeaderTargetId.Text = "追跡ID";
        columnHeaderTargetId.Width = 100;
        // 
        // columnHeaderDescription
        // 
        columnHeaderDescription.Text = "説明";
        columnHeaderDescription.Width = 500;
        // 
        // contextMenuStripIssueList
        // 
        contextMenuStripIssueList.Name = "contextMenuStripIssueList";
        contextMenuStripIssueList.Size = new Size(61, 4);
        // 
        // textBoxManageUrl
        // 
        textBoxManageUrl.Location = new Point(91, 22);
        textBoxManageUrl.Name = "textBoxManageUrl";
        textBoxManageUrl.Size = new Size(430, 23);
        textBoxManageUrl.TabIndex = 2;
        textBoxManageUrl.Validating += TextBoxManageUrl_Validating;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(54, 26);
        label1.Name = "label1";
        label1.Size = new Size(28, 15);
        label1.TabIndex = 3;
        label1.Text = "URL";
        // 
        // textBoxManageUser
        // 
        textBoxManageUser.Location = new Point(91, 70);
        textBoxManageUser.Name = "textBoxManageUser";
        textBoxManageUser.Size = new Size(98, 23);
        textBoxManageUser.TabIndex = 2;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(27, 74);
        label4.Name = "label4";
        label4.Size = new Size(55, 15);
        label4.TabIndex = 3;
        label4.Text = "ユーザー名";
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(checkBoxManageUsingProxy);
        groupBox1.Controls.Add(textBoxCustomFieldIndexOfTrackingId);
        groupBox1.Controls.Add(labelCustomFieldIndexOfTrackingId);
        groupBox1.Controls.Add(textBoxManageProjectId);
        groupBox1.Controls.Add(label7);
        groupBox1.Controls.Add(textBoxManageUrl);
        groupBox1.Controls.Add(textBoxManageUser);
        groupBox1.Controls.Add(textBoxManagePassword);
        groupBox1.Controls.Add(label5);
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(label4);
        groupBox1.Location = new Point(22, 20);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(857, 161);
        groupBox1.TabIndex = 5;
        groupBox1.TabStop = false;
        groupBox1.Text = "管理用Redmine";
        // 
        // checkBoxManageUsingProxy
        // 
        checkBoxManageUsingProxy.AutoSize = true;
        checkBoxManageUsingProxy.Location = new Point(542, 24);
        checkBoxManageUsingProxy.Name = "checkBoxManageUsingProxy";
        checkBoxManageUsingProxy.Size = new Size(120, 19);
        checkBoxManageUsingProxy.TabIndex = 8;
        checkBoxManageUsingProxy.Text = "プロキシ設定を利用";
        checkBoxManageUsingProxy.UseVisualStyleBackColor = true;
        // 
        // textBoxCustomFieldIndexOfTrackingId
        // 
        textBoxCustomFieldIndexOfTrackingId.Location = new Point(460, 111);
        textBoxCustomFieldIndexOfTrackingId.Name = "textBoxCustomFieldIndexOfTrackingId";
        textBoxCustomFieldIndexOfTrackingId.Size = new Size(61, 23);
        textBoxCustomFieldIndexOfTrackingId.TabIndex = 6;
        textBoxCustomFieldIndexOfTrackingId.Text = "0";
        // 
        // labelCustomFieldIndexOfTrackingId
        // 
        labelCustomFieldIndexOfTrackingId.AutoSize = true;
        labelCustomFieldIndexOfTrackingId.Location = new Point(253, 115);
        labelCustomFieldIndexOfTrackingId.Name = "labelCustomFieldIndexOfTrackingId";
        labelCustomFieldIndexOfTrackingId.Size = new Size(201, 15);
        labelCustomFieldIndexOfTrackingId.TabIndex = 7;
        labelCustomFieldIndexOfTrackingId.Text = "追跡チケット番号入力カスタムフィールドID";
        // 
        // textBoxManageProjectId
        // 
        textBoxManageProjectId.Location = new Point(91, 111);
        textBoxManageProjectId.Name = "textBoxManageProjectId";
        textBoxManageProjectId.Size = new Size(98, 23);
        textBoxManageProjectId.TabIndex = 4;
        textBoxManageProjectId.Text = "0";
        textBoxManageProjectId.Validating += TextBoxManageProjectId_Validating;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(12, 115);
        label7.Name = "label7";
        label7.Size = new Size(70, 15);
        label7.TabIndex = 5;
        label7.Text = "プロジェクトID";
        // 
        // textBoxManagePassword
        // 
        textBoxManagePassword.Location = new Point(262, 70);
        textBoxManagePassword.Name = "textBoxManagePassword";
        textBoxManagePassword.PasswordChar = '*';
        textBoxManagePassword.Size = new Size(113, 23);
        textBoxManagePassword.TabIndex = 2;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(205, 74);
        label5.Name = "label5";
        label5.Size = new Size(51, 15);
        label5.TabIndex = 3;
        label5.Text = "パスワード";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(checkBoxTargetUsingProxy);
        groupBox2.Controls.Add(textBoxTargetProjectId);
        groupBox2.Controls.Add(label8);
        groupBox2.Controls.Add(textBoxTargetUrl);
        groupBox2.Controls.Add(textBoxTargetUser);
        groupBox2.Controls.Add(textBoxTargetPassword);
        groupBox2.Controls.Add(label2);
        groupBox2.Controls.Add(label3);
        groupBox2.Controls.Add(label6);
        groupBox2.Location = new Point(22, 200);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(857, 64);
        groupBox2.TabIndex = 6;
        groupBox2.TabStop = false;
        groupBox2.Text = "追跡先Redmine";
        // 
        // checkBoxTargetUsingProxy
        // 
        checkBoxTargetUsingProxy.AutoSize = true;
        checkBoxTargetUsingProxy.Location = new Point(542, 26);
        checkBoxTargetUsingProxy.Name = "checkBoxTargetUsingProxy";
        checkBoxTargetUsingProxy.Size = new Size(120, 19);
        checkBoxTargetUsingProxy.TabIndex = 9;
        checkBoxTargetUsingProxy.Text = "プロキシ設定を利用";
        checkBoxTargetUsingProxy.UseVisualStyleBackColor = true;
        // 
        // textBoxTargetProjectId
        // 
        textBoxTargetProjectId.Location = new Point(97, 111);
        textBoxTargetProjectId.Name = "textBoxTargetProjectId";
        textBoxTargetProjectId.Size = new Size(98, 23);
        textBoxTargetProjectId.TabIndex = 6;
        textBoxTargetProjectId.Text = "0";
        textBoxTargetProjectId.TextChanged += TextBoxTargetProjectId_TextChanged;
        textBoxTargetProjectId.Validating += TextBoxTargetProjectId_Validating;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(12, 115);
        label8.Name = "label8";
        label8.Size = new Size(70, 15);
        label8.TabIndex = 7;
        label8.Text = "プロジェクトID";
        // 
        // textBoxTargetUrl
        // 
        textBoxTargetUrl.Location = new Point(97, 22);
        textBoxTargetUrl.Name = "textBoxTargetUrl";
        textBoxTargetUrl.Size = new Size(424, 23);
        textBoxTargetUrl.TabIndex = 2;
        textBoxTargetUrl.Validating += TextBoxTargetUrl_Validating;
        // 
        // textBoxTargetUser
        // 
        textBoxTargetUser.Location = new Point(97, 66);
        textBoxTargetUser.Name = "textBoxTargetUser";
        textBoxTargetUser.Size = new Size(98, 23);
        textBoxTargetUser.TabIndex = 2;
        // 
        // textBoxTargetPassword
        // 
        textBoxTargetPassword.Location = new Point(268, 66);
        textBoxTargetPassword.Name = "textBoxTargetPassword";
        textBoxTargetPassword.PasswordChar = '*';
        textBoxTargetPassword.Size = new Size(113, 23);
        textBoxTargetPassword.TabIndex = 2;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(211, 70);
        label2.Name = "label2";
        label2.Size = new Size(51, 15);
        label2.TabIndex = 3;
        label2.Text = "パスワード";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(54, 25);
        label3.Name = "label3";
        label3.Size = new Size(28, 15);
        label3.TabIndex = 3;
        label3.Text = "URL";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(27, 70);
        label6.Name = "label6";
        label6.Size = new Size(55, 15);
        label6.TabIndex = 3;
        label6.Text = "ユーザー名";
        // 
        // buttonGetTicket
        // 
        buttonGetTicket.Location = new Point(8, 6);
        buttonGetTicket.Name = "buttonGetTicket";
        buttonGetTicket.Size = new Size(137, 41);
        buttonGetTicket.TabIndex = 7;
        buttonGetTicket.Text = "チケット一覧取得";
        buttonGetTicket.UseVisualStyleBackColor = true;
        buttonGetTicket.Click += ButtonGetTicket_Click;
        // 
        // labelError
        // 
        labelError.AutoSize = true;
        labelError.Location = new Point(280, 27);
        labelError.Name = "labelError";
        labelError.Size = new Size(87, 15);
        labelError.TabIndex = 8;
        labelError.Text = "通信状態：----";
        // 
        // labelReadUrl
        // 
        labelReadUrl.AutoSize = true;
        labelReadUrl.Location = new Point(813, 231);
        labelReadUrl.Name = "labelReadUrl";
        labelReadUrl.Size = new Size(42, 15);
        labelReadUrl.TabIndex = 9;
        labelReadUrl.Text = "http://";
        // 
        // buttonCopy
        // 
        buttonCopy.Location = new Point(749, 225);
        buttonCopy.Name = "buttonCopy";
        buttonCopy.Size = new Size(54, 27);
        buttonCopy.TabIndex = 10;
        buttonCopy.Text = "Copy";
        buttonCopy.UseVisualStyleBackColor = true;
        buttonCopy.Click += ButtonCopy_Click;
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabPage1);
        tabControl1.Controls.Add(tabPage2);
        tabControl1.Dock = DockStyle.Fill;
        tabControl1.Location = new Point(0, 0);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(1297, 983);
        tabControl1.TabIndex = 11;
        // 
        // tabPage1
        // 
        tabPage1.Controls.Add(checkBoxHideClosed);
        tabPage1.Controls.Add(listViewTicket);
        tabPage1.Controls.Add(buttonGetTicket);
        tabPage1.Controls.Add(labelError);
        tabPage1.Location = new Point(4, 24);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new Padding(3);
        tabPage1.Size = new Size(1289, 955);
        tabPage1.TabIndex = 0;
        tabPage1.Text = "Main";
        tabPage1.UseVisualStyleBackColor = true;
        // 
        // checkBoxHideClosed
        // 
        checkBoxHideClosed.AutoSize = true;
        checkBoxHideClosed.Location = new Point(169, 28);
        checkBoxHideClosed.Name = "checkBoxHideClosed";
        checkBoxHideClosed.Size = new Size(95, 19);
        checkBoxHideClosed.TabIndex = 10;
        checkBoxHideClosed.Text = "完了を非表示";
        checkBoxHideClosed.UseVisualStyleBackColor = true;
        checkBoxHideClosed.CheckedChanged += CheckBoxHideClosed_CheckedChanged;
        // 
        // tabPage2
        // 
        tabPage2.Controls.Add(groupBox1);
        tabPage2.Controls.Add(groupBox2);
        tabPage2.Controls.Add(buttonCopy);
        tabPage2.Controls.Add(labelReadUrl);
        tabPage2.Location = new Point(4, 24);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new Padding(3);
        tabPage2.Size = new Size(1289, 955);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "Settings";
        tabPage2.UseVisualStyleBackColor = true;
        // 
        // FormRedmine
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1297, 983);
        Controls.Add(tabControl1);
        Margin = new Padding(4);
        Name = "FormRedmine";
        Text = "FormRedmine";
        FormClosing += FormRedmine_FormClosing;
        Load += FormRedmine_Load;
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        tabControl1.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        tabPage1.PerformLayout();
        tabPage2.ResumeLayout(false);
        tabPage2.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private ListView listViewTicket;
    private ColumnHeader columnHeaderId;
    private ColumnHeader columnHeaderDescription;
    private ColumnHeader columnHeaderTargetId;
    private TextBox textBoxManageUrl;
    private Label label1;
    private TextBox textBoxManageUser;
    private Label label4;
    private GroupBox groupBox1;
    private TextBox textBoxManagePassword;
    private Label label5;
    private GroupBox groupBox2;
    private TextBox textBoxTargetUrl;
    private TextBox textBoxTargetUser;
    private TextBox textBoxTargetPassword;
    private Label label2;
    private Label label3;
    private Label label6;
    private Button buttonGetTicket;
    private TextBox textBoxManageProjectId;
    private Label label7;
    private ColumnHeader columnHeaderSubject;
    private TextBox textBoxCustomFieldIndexOfTrackingId;
    private Label labelCustomFieldIndexOfTrackingId;
    private TextBox textBoxTargetProjectId;
    private Label label8;
    private Label labelError;
    private Label labelReadUrl;
    private Button buttonCopy;
    private ContextMenuStrip contextMenuStripIssueList;
    private CheckBox checkBoxManageUsingProxy;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private CheckBox checkBoxTargetUsingProxy;
    private ColumnHeader columnHeaderStatus;
    private CheckBox checkBoxHideClosed;
}