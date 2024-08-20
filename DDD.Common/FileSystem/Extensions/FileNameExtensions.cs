using System.Text;

namespace DDD.Common.FileSystem.Extensions;

public static class FileNameExtensions
{
    public static StreamReader OpenRead(
        this FileName fileName,
        Encoding? encoding = null,
        bool? detectEncodingFromByteOrderMarks = null,
        FileStreamOptions? options = null) =>
        new(
            fileName.Path,
            encoding ?? Encoding.Default,
            detectEncodingFromByteOrderMarks ?? false,
            options ?? new FileStreamOptions()
        );

    public static StreamWriter OpenWrite(
        this FileName fileName,
        Encoding? encoding = null,
        FileStreamOptions? option = null) =>
        new(
            fileName.Path,
            encoding ?? Encoding.Default,
            option ?? new FileStreamOptions()
        );

    public static StreamWriter OpenWrite(
        this FileName fileName,
        bool append,
        Encoding? encoding = null) =>
        new(
            fileName.Path,
            append,
            encoding ?? Encoding.Default
        );

    public static void Delete(this FileName fileName) => File.Delete(fileName.Path);

    public static bool Exists(this FileName fileName) => File.Exists(fileName.Path);
}
