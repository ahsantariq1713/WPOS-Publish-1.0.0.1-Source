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
    public partial class DropDownSettingsView : Form
    {

        private List<Brand> brands;
        private List<Category> categories;
        private List<Unit> units;

        private readonly Form owner;
        private WaitWin wait;
        public Item Entity { get; private set; }
        public Adapter Adapter { get; }


        public DropDownSettingsView(Adapter adapter, Form owner = null)
        {
            Adapter = adapter;
            this.owner = owner;

            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            wait = new WaitWin("Loading View");
            wait.Show(this);
            LoadComponents();
        }

        private async void LoadComponents()
        {
            
            //brands = (await Adapter.Retrive<Brand>())?.ToList();
            //BindBrands();


            InvalidateForm();
            Display();

        }

        private void Display()
        {
            wait.Close();
            if (this.owner == null) return;
            this.ShowDialog(owner);
        }

        public void InvalidateForm()
        {
           
        }

        /////////////////////////////////////////////////////////////////////////////
        ///Events
        /////////////////////////////////////////////////////////////////////////////


        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.IsBusy()) return;
            ValidateChildren();
            btnSave.MarkBusy(out Image image, out Color color);
            var found =
                (await Adapter.Retrive<Item>())?.ToList()
                .FindAll(x => XString.Equal(x.Code, Entity.Code))
                .Except(new Item[] { Entity })?.ToList();

            //found?.ForEach(x => Message.Info(x.Code));
            if (found != null && found.Count > 0) Message.Error("An item already exists with same item code.");
            else await Adapter.Save(Entity);
            btnSave.MarkFree(image, color);
            InvalidateForm();
        }

     

        private void Panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
