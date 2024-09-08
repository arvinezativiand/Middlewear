using System.ComponentModel.DataAnnotations;

namespace Middlewear.DB.Entity;

public class User
{
    public int Id { get; set; }
    public string? Path { get; set; }
    public string? Host { get; set; }
    public string? Body { get; set; }
    public bool IsHttps { get; set; }
}
