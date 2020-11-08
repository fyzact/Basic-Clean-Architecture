using BasicClean.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicClean.Core.Enitties
{
   public class Todo:BaseEntity<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public TodoState State { get; set; }
    }
}
