using BasicClean.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicClean.Core.Enitties
{
    public class Todo : BaseEntity<Guid>
    {
        private Todo()
        {

        }
        public string Title { get; set; }
        public string Content { get; set; }
        public TodoState State { get; set; }
        public static Todo Create(string title, string content)
        {
            var todo = new Todo
            {
                Title = title,
                Content = content,
                State = TodoState.Created,
                CreationDate=DateTime.Now,
                IsDeleted=false,
                Id=Guid.NewGuid()
            };

            return todo;
        }
    }
}
