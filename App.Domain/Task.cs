namespace App.Domain;
using App.Domain.Common;

public class Task: Base
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool status { get; set; }
}