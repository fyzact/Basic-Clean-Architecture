using System;
using System.Collections.Generic;
using System.Text;

namespace BasicClean.Core.Enitties
{
    public abstract class BaseEntity<Tkey>
    {

        public Tkey Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
