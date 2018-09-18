using System;
using System.Windows.Forms;

namespace ApacheLogParser
{
    public partial class Filtering : Form
    {
        //column from selcted table
        string[] colums;

        public Filtering()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Add row with option for filtering
        /// </summary>
        /// <param name="addButton">True - adding button if first row</param>
        void AddRow(bool addButton = false)
        {
            Panel p = new Panel();
            p.Width = 540;
            p.Height = 25;
            p.Dock = DockStyle.Bottom;

            //AND OR
            ComboBox c = new ComboBox();
            c.Items.AddRange(new[] { "OR", "AND" });
            c.Width = 45;
            c.SelectedIndex = 1;

            //PRED
            ComboBox cb = new ComboBox();
            cb.Items.AddRange(new[] { "=", "<>", ">", "<", ">=", "<=" });
            cb.Width = 45;
            cb.SelectedIndex = 0;

            //COLUMNS
            ComboBox cbc = new ComboBox();
            cbc.Items.AddRange(colums);
            cbc.Width = 120;
            cbc.SelectedIndex = 0;

            //KEY TEXT
            TextBox tb = new TextBox();
            tb.Width = 260;

            //BUTTON REMOVE
            Button btn = new Button();
            btn.Image = Properties.Resources.minus;
            btn.Width = 28;
            btn.Height = 20;
            btn.Click += BtnRemoveClick;

            p.Controls.Add(c);
            p.Controls.Add(cb);
            p.Controls.Add(cbc);
            p.Controls.Add(tb);

            if (!addButton)
                p.Controls.Add(btn);

            cb.Left = 50;
            cbc.Left = 100;
            tb.Left = 225;
            btn.Left = 490;

            panel.Controls.Add(p);
        }
        /// <summary>
        /// Building resulting filtering string 
        /// </summary>
        /// <returns>String that include all options for filtering</returns>
        string GetWhereString()
        {
            string result = "";

            foreach (var item in panel.Controls)
            {
                var p = item as Panel;

                string add_or = !string.IsNullOrWhiteSpace(result) ? (p.Controls[0] as ComboBox).SelectedItem.ToString().ToLower() : "";
                string pred = (p.Controls[1] as ComboBox).SelectedItem.ToString();
                string columnName = (p.Controls[2] as ComboBox).SelectedItem.ToString();
                string text = (p.Controls[3] as TextBox).Text;

                if (!string.IsNullOrWhiteSpace(text)) 
                    result += $"{add_or} [{columnName}]{pred}'{text}' ";
            }

            return result;
        }

        private void BtnRemoveClick(object sender, EventArgs e)
        {
            panel.Controls.Remove((sender as Control).Parent);
        }
        public string ShowSearchDialog(string[] colums)
        {
            this.colums = colums;

            AddRow(true);

            return ShowDialog() == DialogResult.Yes ? GetWhereString() : "";
        }
        private void btnAddClick(object sender, EventArgs e) => AddRow();
    }
}
