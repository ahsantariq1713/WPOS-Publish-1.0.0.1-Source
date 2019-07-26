using System;
using System.Text;

namespace WPos.Domain {


    public class Item : BaseEntity , IItem{
        
        public string Code { get; set; }
        public string Name { get; set; }
        public string Brand { get => ItemBrand?.Name; }
        public string Category { get => ItemCategory?.Name; }
        public string Unit { get => ItemUnit?.Name; }
        public Brand ItemBrand { get; set; }
        public Category ItemCategory { get; set; }
        public Unit ItemUnit { get; set; }
        public bool HasUID { get; set; }
        public string Notes { get; set; }
        public override bool HasErrors(out string errors) {
            var sb = new StringBuilder();
            Code.NullCheck("Code",ref sb);
            Name.NullCheck("Name", ref sb);
            ItemCategory.NullCheck("Category", ref sb);
            errors = sb.ToString();
            return errors.Length > 0;
        }
    }
}
