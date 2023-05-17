namespace App.Domain;
using App.Domain.Common;

public class Checklist: Base
{
    public string Title {get; set;}
    public string Description { get; set; }
    public int TaskId { get; set; }
    public bool status { get; set; }
}