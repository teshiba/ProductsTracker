namespace ProductsTracker;

using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProductsTracker.Properties;

using Redmine.Net.Api.Types;

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
        CtrlRedmine = new ();
        listViewItemActions.Add(ListViewTicketId_Click);
        listViewItemActions.Add(ListViewTicketTitle_Click);
        listViewItemActions.Add(ListViewTicketTrackedId_Click);
        listViewItemActions.Add(ListViewTicketDescription_Click);
    }

    /// <summary>
    /// Gets controler.
    /// </summary>
    public CtrlRedmine CtrlRedmine { get; private set; } = new ();

    private static void ValidateIntValue(object sender)
    {
        var textbox = (TextBox)sender;

        if (!int.TryParse(textbox.Text, out _)) {
            textbox.Text = "0";
        }
    }

    private List<ListViewItem> CreateTicketListView(List<Issue> issues)
    {
        var ret = new List<ListViewItem>();

        foreach (var issue in issues) {
            var customFieldId = CtrlRedmine.RedmineSync.CustomFieldId;
            var customFields = issue.CustomFields.First((x) => x.Id == customFieldId);
            var listviewItem = new ListViewItem(issue.Id.ToString());

            listviewItem.SubItems.Add(issue.Status.Name);
            listviewItem.SubItems.Add(issue.Subject);
            listviewItem.SubItems.Add(customFields.Values[0].Info);
            listviewItem.SubItems.Add(issue.Description);
            listviewItem.Tag = issue;

            ret.Add(listviewItem);
        }

        return ret;
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

        // It is expected that the string of the textbox has been validated as integer value.
        Settings.Default.ManageProjectId = int.Parse(textBoxManageProjectId.Text);
        Settings.Default.CustomFieldIndexOfTrackingId = int.Parse(textBoxCustomFieldIndexOfTrackingId.Text);

        Settings.Default.Save();
    }

    private void UpdateSettings()
    {
        SaveSettings();
        CtrlRedmine.ReloadManager();
    }

    private async Task UpdateViewAsync()
    {
        if (CtrlRedmine.RedmineSync is null) {
            return;
        }

        listViewTicket.BeginUpdate();

        labelError.Text = $"通信状態:Loading...";

        listViewTicket.Items.Clear();

        try {
            var issues = await CtrlRedmine.RedmineSync.GetIssuesAsync();
            var listViewItems = CreateTicketListView(issues);
            listViewTicket.Items.AddRange(listViewItems.ToArray());
            labelError.Text = $"通信状態:Online";
            labelReadUrl.Text = string.Empty;
        } catch (Exception ex) {
            var webEx = ex.InnerException as WebException;
            labelError.Text = $"通信状態: Invalid parameter";
            labelReadUrl.Text = $"{webEx?.Response?.ResponseUri}";
        }

        listViewTicket.EndUpdate();
    }

    ///////////////////////////////////////////////////////////////////////////
    // Listview Event handlers
    ///////////////////////////////////////////////////////////////////////////

    private void ListViewTicket_Click(object sender, EventArgs e)
    {
        var listView = (System.Windows.Forms.ListView)sender;
        var mousePos = listView.PointToClient(MousePosition);
        var info = listView.HitTest(mousePos);

        if (info.Item is ListViewItem item) {
            var row = item.Index;
            var col = item.SubItems.IndexOf(info.SubItem);
            var value = item.SubItems[col].Text;
            listViewItemActions[col](value);
        }
    }

    private void ListViewTicketId_Click(string value)
    {
        if (int.TryParse(value, out var issueId)) {
            CtrlRedmine.RedmineSync.ManagerRedmine.OpenIssue(issueId);
        }
    }

    private void ListViewTicketTitle_Click(string value)
    {
    }

    private void ListViewTicketTrackedId_Click(string value)
    {
        if (int.TryParse(value, out var issueId)) {
            CtrlRedmine.RedmineSync.TargetRedmine.OpenIssue(issueId);
        }
    }

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
        UpdateSettings();
        await UpdateViewAsync();
    }

    private void ButtonCopy_Click(object sender, EventArgs e) => Clipboard.SetText(labelReadUrl.Text);

    private void TextBoxManageUrl_TextChanged(object sender, EventArgs e)
        => textBoxManageUrl.Text = textBoxManageUrl.Text.Trim('/');

    private void TextBoxTargetUrl_TextChanged(object sender, EventArgs e)
        => textBoxTargetUrl.Text = textBoxTargetUrl.Text.Trim('/');

    private void TextBoxManageProjectId_TextChanged(object sender, EventArgs e)
        => ValidateIntValue(sender);

    private void TextBoxCustomFieldIndexOfTrackingId_TextChanged(object sender, EventArgs e)
        => ValidateIntValue(sender);

    private void TextBoxTargetProjectId_TextChanged(object sender, EventArgs e)
        => ValidateIntValue(sender);
}
