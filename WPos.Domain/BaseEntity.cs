using System;
using System.Collections.Generic;
using System.Text;

namespace WPos.Domain {
    public abstract class BaseEntity {

        public bool IsNew { get { return Id == 0; } }
        public bool IsAssignable { get { return !IsNew && EntitySate == EntityState.Active; } }
        public bool IsActive { get => EntitySate == EntityState.Active; }
        public int Id { get; set; }
        public EntityState EntitySate { get; private set; }
        public DateTime CreatedAt { get;private set; }

        public BaseEntity() {
            if (IsNew) {
                CreatedAt = DateTime.Now;
            }
        }

        public abstract bool HasErrors(out string errors);

        public void SafeDelete() {
            EntitySate = EntityState.Delted;
        }

    }

    public enum EntityState {
        Active = 0,
        Delted = 1
    }
}
