using DDD.Common.FileSystem;
using NUnit.Framework;

namespace DDD.Common.Test;

[TestFixture]
public class FileNameTests
{
    [TestCase("foobar.txt", ExpectedResult = ".txt")]
    [TestCase("foobar", ExpectedResult = "")]
    public string? TestExtensions(string path)
    {
        var fn = new FileName(path);
        return fn.Extension;
    }

    [TestCase(@"C:\test\foobar.txt", ExpectedResult = "foobar.txt")]
    [TestCase(@"C:\test\foobar", ExpectedResult = "foobar")]
    public string TestNames(string path)
    {
        var fn = new FileName(path);
        return fn.Name;
    }

    [TestCase(@"C:\test\foobar.txt", ExpectedResult = "foobar")]
    [TestCase(@"C:\test\foobar", ExpectedResult = "foobar")]
    public string TestNamesWithoutExtension(string path)
    {
        var fn = new FileName(path);
        return fn.NameWithoutExtension;
    }

    [TestCase(@"C:\test\foobar.txt", ExpectedResult = true)]
    [TestCase(@"foobar", ExpectedResult = false)]
    public bool TestHasFolders(string path)
    {
        var fn = new FileName(path);
        return fn.HasFolder;
    }

    [TestCase(@"C:\test\foobar.txt", ExpectedResult = @"C:\test")]
    [TestCase(@"C:\test\", ExpectedResult = @"C:\test")]
    [TestCase(@"C:\test", ExpectedResult = @"C:")]
    [TestCase(@"foobar", ExpectedResult = @"")]
    public string? TestFolders(string path)
    {
        var fn = new FileName(path);
        return fn.Folder.Path;
    }
}
