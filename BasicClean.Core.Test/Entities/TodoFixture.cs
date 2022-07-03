using BasicClean.Core.Enitties;
using BasicClean.Core.ValueObjects;
using System;
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

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TodoTitle_ShouldNotBeNullOrEmppty_WhenCreated(string title)
        {
            ArgumentException argument = Assert.Throws<ArgumentException>(()=> { Todo.Create(title,"content"); });
            Assert.Equal($"{nameof(title)} cannot be null or empty", argument.Message);
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TodoContent_ShouldNotBeNull_WhenCreated(string content)
        {
            ArgumentException argument = Assert.Throws<ArgumentException>(() => { Todo.Create("title", content); });
            Assert.Equal($"{nameof(content)} cannot be null or empty", argument.Message);
        }
    }
}
