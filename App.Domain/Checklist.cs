namespace App.Domain;
using App.Domain.Common;

public class Checklist: Base
{
    public string Title {get; set;} = null!;
    public string Description { get; set; } = null!;
    public int TaskId { get; set; }
    public bool status { get; set; }
}