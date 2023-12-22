File file1 = new("File 1");
File file2 = new("File 2");
File file3 = new("File 3");

Folder folder1 = new("Folder 1");
folder1.Add(file1);
folder1.Add(file2);
folder1.Add(file3);

Folder folder2 = new("Folder 2");
File file4 = new("File 4");
File file5 = new("File 5");

folder2.Add(file4);
folder2.Add(file5);

folder1.Add(folder2);
folder1.DoubleClick();

interface IPlaceHolder
{
    void DoubleClick();
}

class Folder : IPlaceHolder
{
    readonly String _name;
    private readonly List<IPlaceHolder> _files = new();

    public Folder(String name) => this._name = name;

    public void Add(IPlaceHolder file) => _files.Add(file);

    public void DoubleClick()
    {
        Console.WriteLine($"{_name} folder is Opened");
        _files.ForEach(Console.WriteLine);
    }
}

class File : IPlaceHolder
{
    readonly String _name;

    public File(String name) => this._name = name;

    public void DoubleClick() => Console.WriteLine($"{_name} file is opened in a program");
}