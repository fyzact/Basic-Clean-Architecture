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
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException($"{nameof(title)} cannot not be null or empty");

            var todo = new Todo
            {
                Id = Guid.NewGuid(),
                Title = title,
                Content = content,
                State = TodoState.Created,
                CreationDate=DateTime.Now,
                IsDeleted=false,
               
            };

            return todo;
        }
    }
}
