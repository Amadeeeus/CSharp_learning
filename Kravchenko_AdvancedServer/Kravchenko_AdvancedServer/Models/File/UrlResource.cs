namespace Kravchenko_AdvancedServer.Models.File;

public class UrlResource<T>
{
    public string? Description { get; set; }
    public T? File { get; set; }
    public string? Filename { get; set; }
    public T? InputStream { get; set; }
    public bool Open {get; set; }
    public bool Readable {get; set; }
    public T? Uri {get; set; }
    public T? Url {get; set; }
}