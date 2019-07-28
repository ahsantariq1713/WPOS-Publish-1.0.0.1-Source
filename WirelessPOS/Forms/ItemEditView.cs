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
    public partial class ItemEditView : Form
    {

        private List<Brand> brands;
        private List<Category> categories;
        private List<Unit> units;

        private readonly Form owner;
        private WaitWin wait;
        public Item Entity { get; private set; }
        public Adapter Adapter { get; }


        public ItemEditView(Adapter adapter, int id, Form owner = null)
        {
            Adapter = adapter;
            this.owner = owner;

            InitializeComponent();
            InitializeForm(id);
        }

        private void InitializeForm(int id)
        {
            wait = new WaitWin("Loading View");
            wait.Show(this);
            LoadComponents(id);
           
        }

        private async void LoadComponents(int id)
        {
            if (id == 0) Entity = new Item();
            else
            {
                Entity  = await Adapter.Retrive<Item>(id);
                if (Entity == null)
                {
                    wait.Close();
                    Message.Stop("No item found to show.");
                    this.Dispose();
                    return;
                }

                await Adapter.LoadRelatedData(Entity);
            }

            BindEntity();

            brands = (await Adapter.Retrive<Brand>())?.ToList();
            BindBrands();

            categories = (await Adapter.Retrive<Category>())?.ToList();
            BindCategories();

            units = (await Adapter.Retrive<Unit>())?.ToList();
            BindUnits();

            InvalidateForm();
            Display();

        }

        public void BindEntity()
        {
            itemBindingSource.Clear();
            itemBindingSource.Add(Entity);
        }
        private void BindBrands()
        {
            brandBindingSource.Clear();
            brands?.ToList().ForEach(x =>
            {
                brandBindingSource.Add(x);
            });
        }

        private void BindCategories()
        {
            categoryBindingSource.Clear();
            categories?.ToList().ForEach(x =>
            {
                categoryBindingSource.Add(x);
            });
        }

        private void BindUnits()
        {
            unitBindingSource.Clear();
            units?.ToList().ForEach(x =>
            {
                unitBindingSource.Add(x);
            });
        }

        private void Display()
        {
            wait.Close();
            if (this.owner == null) return;
            this.ShowDialog(owner);
        }

        public void InvalidateForm()
        {
            if (Entity.IsNew)
            {
                lblTitle.Text = "          New Item";
                btnDelete.Enabled = false;
            }
            else
            {
                lblTitle.Text = "          Edit Item";
                btnDelete.Enabled = true;
            }
        }

        /////////////////////////////////////////////////////////////////////////////
        ///Events
        /////////////////////////////////////////////////////////////////////////////


        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (Entity.HasErrors(out string errors))
            {
                Message.Error("Please fix the following errors to continue:\n" + errors);
                return;
            }
            if (btnSave.IsBusy()) return;
            ValidateChildren();
            btnSave.MarkBusy(out Image image, out Color color);
            var found =
                (await Adapter.Retrive<Item>())?.ToList()
                .FindAll(x => XString.Equal(x.Code, Entity.Code))
                .Except(new Item[] { Entity })?.ToList();

            if (found != null && found.Count > 0) Message.Error("An item already exists with same item code.");
            else
            {
               int change = await Adapter.Save(Entity);
                if (change>0)
                {
                    DialogResult = DialogResult.OK;
                }
            }
            btnSave.MarkFree(image, color);
            InvalidateForm();
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Message.Question("Are you sure you want to delete this item?") == DialogResult.No)
            {
                return;
            }

            if (btnDelete.IsBusy()) return;
            btnDelete.MarkBusy(out Image image, out Color color);
            int changes = await Adapter.Remove(Entity);
            btnDelete.MarkFree(image, color);
            if (changes <= 0) return;
            DialogResult = DialogResult.OK;
        }

        private void DdlBrand_TextChanged(object sender, EventArgs e)
        {
            var text = ddlBrand.Text;
            if (text.IsNull())
            {
                btnAddBrand.Enabled = false;
                return;
            }
            var found = brands?.Find(x => XString.Equal(x.Name, text));
            if (found != null) btnAddBrand.Enabled = false;
            else btnAddBrand.Enabled = true;
        }

        private async void BtnAddBrand_Click(object sender, EventArgs e)
        {
            if (btnAddBrand.IsBusy()) return;
            btnAddBrand.MarkBusy(out Image image, out Color color);
            var brand = new Brand { Name = ddlBrand.Text };
            int changes = await Adapter.Save(brand);
            btnAddBrand.MarkFree(image, color);
            if (changes <= 0) return;
            brands.Add(brand);
            brandBindingSource.Add(brand);
            ddlBrand.SelectedItem = brand;
            btnAddBrand.Enabled = false;
        }

        private void DdlCategory_TextChanged(object sender, EventArgs e)
        {
            var text = ddlCategory.Text;
            if (text.IsNull())
            {
                btnAddCategory.Enabled = false;
                return;
            }
            var found = categories?.Find(x => XString.Equal(x.Name, text));
            if (found != null) btnAddCategory.Enabled = false;
            else btnAddCategory.Enabled = true;
        }

        private async void BtnAddCategory_Click(object sender, EventArgs e)
        {
            if (btnAddCategory.IsBusy()) return;
            btnAddCategory.MarkBusy(out Image image, out Color color);
            var category = new Category { Name = ddlCategory.Text };
            int changes = await Adapter.Save(category);
            btnAddCategory.MarkFree(image, color);
            if (changes <= 0) return;
            categories.Add(category);
            categoryBindingSource.Add(category);
            ddlCategory.SelectedItem = category;
            btnAddCategory.Enabled = false;
        }

        private void DdlUnit_TextChanged(object sender, EventArgs e)
        {
            var text = ddlUnit.Text;
            if (text.IsNull())
            {
                btnAddUnit.Enabled = false;
                return;
            }
            var found = units?.Find(x => XString.Equal(x.Name, text));
            if (found != null) btnAddUnit.Enabled = false;
            else btnAddUnit.Enabled = true;
        }

        private async void BtnAddUnit_Click(object sender, EventArgs e)
        {
            if (btnAddUnit.IsBusy()) return;
            btnAddUnit.MarkBusy(out Image image, out Color color);
            var unit = new Unit { Name = ddlUnit.Text };
            int changes = await Adapter.Save(unit);
            btnAddUnit.MarkFree(image, color);
            if (changes <= 0) return;
            units.Add(unit);
            unitBindingSource.Add(unit);
            ddlUnit.SelectedItem = unit;
            btnAddUnit.Enabled = false;
        }

   
    }
}
