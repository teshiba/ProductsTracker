namespace ProductsTracker;

using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProductsTracker.Properties;

using Redmine.Net.Api.Exceptions;

/// <summary>
/// Show Redmine properties form class.
/// </summary>
public partial class FormRedmine : Form
{
    private readonly List<Action<string>> listViewItemActions = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="FormRedmine"/> class.
    /// </summary>
    public FormRedmine()
    {
        InitializeComponent();
        InitListviewActions();
    }

    /// <summary>
    /// Gets controler.
    /// </summary>
    public CtrlRedmine CtrlRedmine { get; private set; } = new ();

    private void InitListviewActions()
    {
        listViewItemActions.Add(ListViewTicketId_Click);
        listViewItemActions.Add(ListViewTicketTitle_Click);
        listViewItemActions.Add(ListViewTicketTrackedId_Click);
        listViewItemActions.Add(ListViewTicketDescription_Click);
    }

    private void LoadSettings()
    {
        textBoxManagePassword.Text = Settings.Default.ManagePassword;
        textBoxManageUser.Text = Settings.Default.ManageUser;
        textBoxManageUrl.Text = Settings.Default.ManageHost;
        textBoxManageProjectId.Text = Settings.Default.ManageProjectId.ToString();
        checkBoxManageUsingProxy.Checked = Settings.Default.ManageUsingProxy;

        textBoxTargetPassword.Text = Settings.Default.TargetPassword;
        textBoxTargetUser.Text = Settings.Default.TargetUser;
        textBoxTargetUrl.Text = Settings.Default.TargetHost;
        textBoxTargetProjectId.Text = Settings.Default.TargetProjectId.ToString();
        checkBoxTargetUsingProxy.Checked = Settings.Default.TargetUsingProxy;

        checkBoxHideClosed.Checked = Settings.Default.HideClosedTicket;

        textBoxCustomFieldIndexOfTrackingId.Text = Settings.Default.CustomFieldIndexOfTrackingId.ToString();
    }

    private void SaveSettings()
    {
        Settings.Default.ManagePassword = textBoxManagePassword.Text;
        Settings.Default.ManageUser = textBoxManageUser.Text;
        Settings.Default.ManageHost = textBoxManageUrl.Text;
        Settings.Default.ManageUsingProxy = checkBoxManageUsingProxy.Checked;

        Settings.Default.TargetPassword = textBoxTargetPassword.Text;
        Settings.Default.TargetUser = textBoxTargetUser.Text;
        Settings.Default.TargetHost = textBoxTargetUrl.Text;
        Settings.Default.TargetUsingProxy = checkBoxTargetUsingProxy.Checked;

        Settings.Default.HideClosedTicket = checkBoxHideClosed.Checked;

        // It is expected that the string of the textbox has been validated as integer value.
        Settings.Default.ManageProjectId = int.Parse(textBoxManageProjectId.Text);
        Settings.Default.CustomFieldIndexOfTrackingId = int.Parse(textBoxCustomFieldIndexOfTrackingId.Text);

        Settings.Default.Save();
    }

    private async Task<bool> ReloadDataAsync()
    {
        var ret = false;

        SaveSettings();

        try {
            CtrlRedmine.ReloadManager();
            labelError.Text = $"通信状態:Loading...";

            ret = await CtrlRedmine.RedmineSync.LoadIssuesAsync();
            labelError.Text = ret ? $"通信状態:Load Issue" : $"通信状態:Error Load Issue";
        } catch (RedmineException ex) {
            labelError.Text = $"通信状態: Invalid redmine parameter err:{ex.Message}";
        } catch (Exception ex) {
            var webEx = ex.InnerException as WebException;
            labelError.Text = $"通信状態: Invalid parameter";
            labelReadUrl.Text = $"{webEx?.Response?.ResponseUri}";
        }

        return ret;
    }

    private void UpdateView()
    {
        if (CtrlRedmine.RedmineSync is not null) {
            listViewTicket.BeginUpdate();
            listViewTicket.Items.Clear();
            labelReadUrl.Text = string.Empty;

            var listViewItems = CtrlRedmine.CreateTicketListView(checkBoxHideClosed.Checked);
            listViewTicket.Items.AddRange(listViewItems);

            listViewTicket.EndUpdate();
        }
    }

    private void OnClickListviewItem(ListView listView)
    {
        var clientPosition = listView.PointToClient(MousePosition);
        var cell = listView.GetCell(clientPosition);
        listViewItemActions[cell.Col](cell.Value);
    }

    ///////////////////////////////////////////////////////////////////////////
    // Listview Event handlers
    ///////////////////////////////////////////////////////////////////////////

    private void ListViewTicket_Click(object sender, EventArgs e)
        => OnClickListviewItem((ListView)sender);

    private void ListViewTicketId_Click(string value)
        => CtrlRedmine.RedmineSync.ManagerRedmine.OpenIssue(value);

    private void ListViewTicketTitle_Click(string value)
    {
    }

    private void ListViewTicketTrackedId_Click(string value)
        => CtrlRedmine.RedmineSync.TargetRedmine.OpenIssue(value);

    private void ListViewTicketDescription_Click(string value)
    {
    }

    ///////////////////////////////////////////////////////////////////////////
    // Event handlers
    ///////////////////////////////////////////////////////////////////////////
    private void FormRedmine_Load(object sender, EventArgs e)
        => LoadSettings();

    private void FormRedmine_FormClosing(object sender, FormClosingEventArgs e)
        => SaveSettings();

    [SuppressMessage("Usage", "VSTHRD100:Avoid async void methods", Justification = SuppressReason.GuiEvent)]
    private async void ButtonGetTicket_Click(object sender, EventArgs e)
    {
        _ = await ReloadDataAsync();
        UpdateView();
    }

    private void CheckBoxHideClosed_CheckedChanged(object sender, EventArgs e)
    {
        SaveSettings();
        UpdateView();
    }

    private void ButtonCopy_Click(object sender, EventArgs e)
        => Clipboard.SetText(labelReadUrl.Text);

    private void TextBoxTargetProjectId_TextChanged(object sender, EventArgs e)
        => ((TextBox)sender).ValidateIntValue();

    private void TextBoxManageProjectId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        => ((TextBox)sender).ValidateIntValue();

    private void TextBoxTargetProjectId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        => ((TextBox)sender).ValidateIntValue();

    private void TextBoxManageUrl_Validating(object sender, System.ComponentModel.CancelEventArgs e)
         => textBoxManageUrl.Text = textBoxManageUrl.Text.Trim('/');

    private void TextBoxTargetUrl_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        => textBoxTargetUrl.Text = textBoxTargetUrl.Text.Trim('/');
}
