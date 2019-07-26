using System.Collections.Generic;
using System.Text;

namespace WPos.Domain {
    public class Brand : BaseEntity, IDropDown {

        public string Name { get; set; }

        public override bool HasErrors(out string errors) {
            var sb = new StringBuilder();
            if (string.IsNullOrEmpty(Name)) {
                sb.Append("Name cannot be empty");
            }

            errors = sb.ToString();
            return errors.Length > 0;
        }
    }
}