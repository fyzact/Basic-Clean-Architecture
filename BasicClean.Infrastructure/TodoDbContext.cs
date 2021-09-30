using BasicClean.Core.Enitties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicClean.Infrastructure
{
   public  class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        { }
        public  DbSet<Todo> Todos  { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedData(builder);
            base.OnModelCreating(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            builder.Entity<Todo>().HasData(
                Todo.Create("Lorem Ipsum builder", "orem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse pharetra tristique lorem, et vehicula leo pharetra eget. Sed fringilla suscipit dapibus. Aliquam sagittis vel sem sit amet consequat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sit amet orci sem. In hac habitasse platea dictumst. Proin sapien mauris, aliquet id tellus auctor, condimentum condimentum elit. Suspendisse lobortis ornare neque, sed fermentum ex accumsan ac. Fusce vel nisi ipsum. Donec vestibulum maximus nisl non fermentum. Maecenas tempus quam faucibus viverra porttitor. Curabitur ac est sit amet elit convallis posuere eu id purus. Suspendisse potenti. Proin ac est ac tellus volutpat semper. Aenean eleifend elementum ultrices."),
                Todo.Create("Suspendisse potenti.", "Suspendisse potenti. Vestibulum vulputate tempor est. Nam feugiat ante metus, in bibendum nibh cursus vitae. Aenean tincidunt magna aliquam ante dictum, vel ultrices nibh vulputate. Nulla in consectetur felis. Nunc tincidunt, nunc sed viverra elementum, quam dolor varius diam, id porttitor justo turpis tincidunt sapien. Interdum et malesuada fames ac ante ipsum primis in faucibus. Vivamus aliquet ultricies magna, ut venenatis metus vehicula a. Quisque vel leo sit amet risus aliquet efficitur. Phasellus non ipsum lobortis, porta quam vel, laoreet lorem. Sed fringilla a ipsum sit amet cursus. Sed erat augue, hendrerit vel arcu ac, tristique viverra erat. Nulla aliquet rhoncus suscipit. Cras vitae metus luctus, efficitur nulla vulputate, venenatis neque."),
                Todo.Create("Cras nec aliquam felis", "Cras nec aliquam felis. Quisque consectetur odio quam, venenatis aliquam mauris pulvinar ac. Morbi tristique molestie interdum. Vivamus elementum pretium massa, a porta orci sagittis ac. Sed quis scelerisque turpis, id porttitor urna. Suspendisse mauris quam, euismod ac mi a, dignissim maximus ligula. Vivamus arcu nisl, accumsan ac aliquet ut, interdum ut sem. Ut condimentum facilisis nisl in commodo. Nam sodales arcu id metus consectetur, semper pretium lorem ultrices. Nulla libero enim, fermentum eu tortor a, maximus feugiat nunc. Aenean rhoncus augue ut nibh laoreet, ac tempus erat suscipit. Morbi nec sem posuere, efficitur leo in, accumsan sem. Nam vitae ante sed eros accumsan lobortis. Duis tristique est nec nisi tincidunt, ut mattis sapien pulvinar.")
                
                );
        }
    }
}
