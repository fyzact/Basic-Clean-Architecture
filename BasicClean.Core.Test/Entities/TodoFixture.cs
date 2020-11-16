using BasicClean.Core.Enitties;
using BasicClean.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BasicClean.Core.Test.Entities
{
    public class TodoFixture
    {
        [Fact]
        public void TodoId_ShouldNotBeEmpty_WhenCreated()
        {
            Todo todo = Todo.Create("title", "content");
            Assert.NotEqual(Guid.Empty, todo.Id);
        }

        [Fact]
        public void TodoState_ShouldBeCreated_WhenCreated()
        {
            Todo todo = Todo.Create("title", "content");
            Assert.Equal(TodoState.Created, todo.State);
        }

        [Fact]
        public void TodoTitle_ShouldBeNull_WhenCreated()
        {
            string title;
            ArgumentException argument = Assert.Throws<ArgumentException>(()=> { Todo.Create(title, "content"); });
            Assert.Equal($"{nameof(title)} cannot be null or empty", argument.Message);
        }

        [Fact]
        public void TodoTitle_ShouldBeemty_WhenCreated()
        {
            string title=string.Empty;
            ArgumentException argument = Assert.Throws<ArgumentException>(() => { Todo.Create(title, "content"); });
            Assert.Equal($"{nameof(title)} cannot be null or empty", argument.Message);
        }
    }
}
