namespace ProductsTracker;

using System.Windows.Forms;

using static System.Windows.Forms.ListViewItem;

/// <summary>
/// Helper API for FormRedmine.
/// </summary>
public static partial class FormRedmineHelpers
{
    /// <summary>
    /// Generate new Listview subitems.
    /// </summary>
    /// <param name="textArray">text array that set to subItems.</param>
    /// <returns>ListViewSubItem array.</returns>
    public static ListViewSubItem[] NewSubItems(string[] textArray)
    {
        var ret = new List<ListViewSubItem>();

        foreach (var item in textArray) {
            ret.Add(new () { Text = item });
        }

        return [.. ret];
    }

    /// <summary>
    /// Validate that the Textbox.Text is an integer value.
    /// </summary>
    /// <param name="textbox">target Textbox.</param>
    public static void ValidateIntValue(this TextBox textbox)
    {
        if (!int.TryParse(textbox.Text, out _)) {
            textbox.Text = "0";
        }
    }

    /// <summary>
    /// Get listview cell on the selected position.
    /// </summary>
    /// <param name="listView">target listview.</param>
    /// <param name="mousePosition">mouse position.</param>
    /// <returns>cell on the mouse position.</returns>
    public static Cell GetCell(this ListView listView, Point mousePosition)
    {
        var info = listView.HitTest(mousePosition);
        Cell ret = new ();

        if (info.Item is ListViewItem item) {
            ret.Row = item.Index;
            ret.Col = item.SubItems.IndexOf(info.SubItem);
            ret.Value = item.SubItems[ret.Col].Text;
        }

        return ret;
    }
}