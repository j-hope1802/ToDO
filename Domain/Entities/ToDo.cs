namespace Domain.Entities;
public class Todo{
    public int Id{get;set;}
    public int UserId{get;set;}
    public string Titile { get; set; }
    public string Description { get; set; }
    public string DeadLIne{get;set;}
    public DateTime  Create { get; set; }
    public string Update { get; set; }
    public User Users{get;set;}
    public int CategoryId{get;set;}
    public Category Category{get;set;}
    public List<UserTodo>UserTodos{get;set;}
    public List<Comment>Comments{get;set;}

}