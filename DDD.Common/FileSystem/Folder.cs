
namespace DDD.Common.FileSystem;

public record Folder(string Path)
{
    public string Root => System.IO.Path.GetPathRoot(Path) ?? string.Empty;
    public Folder WithoutFileName => new Folder(GetPath(Path));

    private static string GetPath(string path)
    {
        var index1 = path.LastIndexOf(System.IO.Path.DirectorySeparatorChar);
        var index2 = path.LastIndexOf(System.IO.Path.AltDirectorySeparatorChar);
        var index = Math.Max(index1, index2);

        return index == -1 ? path : path.Substring(0, index + 1);
    }

    public static Folder Empty => new Folder(string.Empty);

    public static Folder operator +(Folder a, Folder b) =>
        new Folder(System.IO.Path.Combine(a.Path, b.Path));

    public static FileName operator +(Folder a, FileName b) =>
        new FileName(System.IO.Path.Combine(a.Path, b.Name));
}
