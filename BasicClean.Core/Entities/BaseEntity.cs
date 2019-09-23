using System;

namespace BasicClean.Core.Entities
{
   public class BaseEntity<IdType>
    {
        public IdType  Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
    
}