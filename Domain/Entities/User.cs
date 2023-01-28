namespace Domain.Entities;
 using System.ComponentModel.DataAnnotations;
public class User{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name name should not be empty")]
    public  string Name { get; set; }

     [Required(ErrorMessage = "MobileNumber name should not be empty")]
    public int MobileNumber { get; set; }
    public string Email { get; set; }
     [Required(ErrorMessage = "Password name should not be empty")]
    public string Password{get;set;}    
    public List<UserTodo>UserTodos{get;set;}
}