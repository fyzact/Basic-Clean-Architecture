using System;

namespace BasicClean.Core.Entities
{
   public class TodoItem:BaseEntity<Guid>
    {
       public string  Title { get; set; }
       public string  Description { get; set; }
    }
    
}