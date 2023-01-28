namespace Domain.Dtos;
public class GetToDoDto{
       public int Id{get;set;}
    public int UserId{get;set;}
    public string Titile { get; set; }
    public string Description { get; set; }
    public string DeadLIne{get;set;}
    public DateTime  Create { get; set; }
    public string Update { get; set; }
    public int CategoryId{get;set;}
}