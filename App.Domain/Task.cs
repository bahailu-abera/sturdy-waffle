namespace App.Domain;
using App.Domain.Common;

public class Task: Base
{
    public string Title;
    public string Description;
    public int UserId;
    public DateTime StartDate;
    public DateTime EndDate;
    public bool status;
}