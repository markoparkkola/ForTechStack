using System.Text;

namespace DDD.Common.FileSystem;

public record FileName
{
    public FileName(string path)
    {
        Path = path;
        HasExtension = System.IO.Path.HasExtension(path);
        HasFolder = path.Contains(System.IO.Path.DirectorySeparatorChar) || path.Contains(System.IO.Path.AltDirectorySeparatorChar);
    }

    public string Path { get; }
    public bool HasExtension { get; }
    public bool HasFolder { get; }
    public string Name => System.IO.Path.GetFileName(Path);
    public string Extension => System.IO.Path.GetExtension(Path);
    public string NameWithoutExtension => HasExtension ? TrimExtension(Name, Extension) : Name;
    public Folder Folder => HasFolder ? GetFolder() : Folder.Empty;

    public bool MatchExtension(string ext, bool caseInsensitive = false) =>
        caseInsensitive ? Extension?.ToLower() == ext : Extension == ext;

    private Folder GetFolder()
    {
        var index1 = Path.LastIndexOf(System.IO.Path.DirectorySeparatorChar);
        var index2 = Path.LastIndexOf(System.IO.Path.AltDirectorySeparatorChar);
        var index = Math.Max(index1, index2);

        var path = index == -1 ? string.Empty : Path.Substring(0, index);
        return new Folder(path);
    }

    public static string TrimExtension(string name, string? extension = null)
    {
        extension ??= System.IO.Path.GetExtension(name);
        return name.Substring(0, name.Length - extension.Length);
    }
}
