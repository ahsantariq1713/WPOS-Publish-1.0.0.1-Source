using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPos.DataContext;
using WPos.Domain;

namespace WirelessPOS
{
    public partial class SearchView<T> : Form
    {
        private readonly IEnumerable<T> entites;
        private readonly Form owner;
        private WaitWin wait;
        public int SelectedEntityId { get; private set; }

        public SearchView(string entityName, IEnumerable<T> entites, IEnumerable<DGColumn> columns, Form owner = null)
        {
            this.entites = entites;
            this.owner = owner;

            InitializeComponent();
            InvalidateForm(entityName);
            InitializeForm(entites, columns);
        }

        public void InvalidateForm(string entityName)
        {
            lblTitle.Text = "          " + entityName + " Search Result";
        }

        private void InitializeForm(IEnumerable<T> entites, IEnumerable<DGColumn> columns)
        {
            wait = new WaitWin("Loading View");
            wait.Show();
            LoadComponents(entites, columns);
            Display();
        }

        private void Display()
        {
            wait.Close();
            wait.Dispose();
            if (owner == null) return;
            this.ShowDialog(owner);
        }

        private void LoadComponents(IEnumerable<T> entites, IEnumerable<DGColumn> columns)
        {
            grid.DataSource = typeof(IEnumerable<T>);
            grid.DataSource = entites;
            grid.ClearSelection();
            foreach (DataGridViewColumn gridColumn in grid.Columns)
            {
                var column = columns.ToList().Find(x => x.Column == gridColumn.Name);
                if (column != null)
                {
                    gridColumn.DisplayIndex = column.DisplayIndex;
                    gridColumn.Width = column.Width;
                    gridColumn.Visible = true;
                    gridColumn.HeaderText = gridColumn.Name.ToLabel();
                }
                else
                {
                    gridColumn.Visible = false;
                }
            }

        }

        /////////////////////////////////////////////////////////////////////////////
        ///Events
        /////////////////////////////////////////////////////////////////////////////
        private void Grid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SelectEntity();
            }
        }

        private void SelectEntity()
        {
            if (grid.SelectedRows.Count > 0 && grid.SelectedRows[0].Index != -1)
            {
                var idString = grid.SelectedRows[0].Cells["Id"].Value.ToString();
                SelectedEntityId = int.TryParse(idString, out int id) ? id : 0;
                if (SelectedEntityId != 0)
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void Grid_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectEntity();
            }
        }
    }
}
