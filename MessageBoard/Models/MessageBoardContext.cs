using Microsoft.EntityFrameworkCore;
using System;

namespace MessageBoard.Models
{
  public class MessageBoardContext : DbContext
  {
    public MessageBoardContext(DbContextOptions<MessageBoardContext> options)
      : base(options)
      {

      }
    public DbSet<Board> Boards {get; set;}
    public DbSet<Thread> Threads {get; set;}
    public DbSet<Post> Posts {get; set;}
    public DbSet<User> Users {get; set;}

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Board>()
        .HasData(
          new MessageBoard { BoardId = 1, Title = "General" }
        );
      
      builder.Entity<Thread>()
        .HasData(
          new Thread { ThreadId = 1, Title = "1 ", CreationDate = DateTime.Now, ParentBoardId = 1, UserId = 1 }
        );

      builder.Entity<Post>()
        .HasData(
          new Post { PostId = 1, PostBody = "1", Title = "Title", UserId = 1, CreationDate = DateTime.Now, ParentThreadId = 1 }
        );
      
      builder.Entity<User>()
        .HasData(
          new User { UserId = 1, UserName = "Ana", CreationDate = DateTime.Now }
        );
    }
  }
}