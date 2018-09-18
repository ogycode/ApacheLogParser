using System.Windows.Forms;

namespace ApacheLogParser
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        public string ShowSearchDialog(string[] colums)
        {
            foreach (var item in colums)
                cbComlumns.Items.Add(item);

            cbComlumns.SelectedIndex = 0;

            return (ShowDialog() == DialogResult.Yes) && (!string.IsNullOrWhiteSpace(tbSearch.Text)) ?
                $"[{cbComlumns.SelectedItem.ToString()}] like '%{tbSearch.Text}%'" : "";
        }
    }
}
