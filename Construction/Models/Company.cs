namespace Construction.Models
{
  public class Company
  {
    public int Id {get; set;}
    public string CompanyName {get; set;}
    public string Industry {get; set;}
    public int Employees {get; set;}
    // public string CreatorId {get; set;}

    public class CompanyJobViewModel : Company
    {
      public int JobId {get; set;}
    }

  }
}