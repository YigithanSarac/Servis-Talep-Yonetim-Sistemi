namespace ServisTalep.Api.Models;

public class ServiceRequest
{
    public int Id {get;set;}
    public string CustomerName {get;set;} = string.Empty;
    public string DeviceName {get;set;} = string.Empty;
    public string Description {get;set;} = string.Empty;
    public string Status {get;set;} = string.Empty;
    public DateTime CreatedDate {get;set;}
}