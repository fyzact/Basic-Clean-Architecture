using BasicClean.Core.ValueObjects;
using System;

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
                throw new ArgumentException($"{nameof(title)} cannot be null or empty");

            if (string.IsNullOrEmpty(content))
                throw new ArgumentException($"{nameof(content)} cannot be null or empty");

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

        public Todo ChangeTitle(string title)
        {
            Title = title;
            return this;
        }

        public Todo ChangeContent(string content)
        {
            Content = content;
            return this;

        }
    }
}
