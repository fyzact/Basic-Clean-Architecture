using BasicClean.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicClean.Core.Dtos
{
  public  class TodoItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public TodoState State { get; set; }
    }
}
