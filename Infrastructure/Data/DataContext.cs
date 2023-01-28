using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Infrastructure.Context;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<UserTodo>()
            .HasKey(bc => new { bc.UserId, bc.TodoId });
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Todo> Todos { get; set; }
    public DbSet<UserTodo>UserTodos{get;set;}
}
