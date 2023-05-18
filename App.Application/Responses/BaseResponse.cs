namespace App.Application.Responses;

public class BaseResponse<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; } = true;
    public string? Message { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
    public string? ErrorMessage { get; internal set; }
}
