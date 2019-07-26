using System;
using System.Collections.Generic;
using System.Text;

namespace WPos.Domain
{
    public class Policy : BaseEntity
    {
        public PolicyType PolicyType { get; set; }
        public string Type { get => PolicyType?.Name; }
        public string Statement { get; set; }

        public override bool HasErrors(out string errors)
        {
            errors = null;
            return false;
        }
    }

    public class PolicyType : BaseEntity
    {
        public string Name { get; set; }

        public override bool HasErrors(out string errors)
        {
            errors = null;
            return false;
        }
    }
}
