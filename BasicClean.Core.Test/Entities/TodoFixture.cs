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
        public void TodoId_ShouldNotBeNull_WhenCreated()
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
    }
}
