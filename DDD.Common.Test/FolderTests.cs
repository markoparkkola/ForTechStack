using DDD.Common.FileSystem;
using NUnit.Framework;

namespace DDD.Common.Test;

[TestFixture]
public class FolderTests
{
    [TestCase(@"C:\foo\bar.txt", ExpectedResult = @"C:\")]
    [TestCase(@"C:\foo\", ExpectedResult = @"C:\")]
    [TestCase(@"\foo\", ExpectedResult = @"\")]
    [TestCase(@"foo\", ExpectedResult = @"")]
    public string TestRoots(string path)
    {
        var f = new Folder(path);
        return f.Root;
    }

    [TestCase(@"C:\foo\bar.txt", ExpectedResult = @"C:\foo\")]
    public string TestFolderWithoutFileName(string path)
    {
        var f = new Folder(path);
        return f.WithoutFileName.Path;
    }

    [TestCase(@"C:\foo", @"bar", ExpectedResult = @"C:\foo\bar")]
    public string TestFolderConcatenations(string path1, string path2)
    {
        return (new Folder(path1) + new Folder(path2)).Path;
    }

    [TestCase(@"C:\foo", @"bar.txt", ExpectedResult = @"C:\foo\bar.txt")]
    public string TestFolderFileNameConcatenations(string path1, string path2)
    {
        return (new Folder(path1) + new FileName(path2)).Path;
    }
}
