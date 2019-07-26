using System;
using System.Collections.Generic;
using System.Text;

namespace WPos.Domain
{
public    class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public override bool HasErrors(out string errors)
        {
            var sb = new StringBuilder();
            Name.NullCheck("Supplier Name", ref sb);
            Company.NullCheck("Company", ref sb);
            Phone.NullCheck("Phone", ref sb);
            errors = sb.ToString();
            return errors.Length > 0;
        }
    }
}
