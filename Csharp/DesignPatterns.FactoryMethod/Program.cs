
IScreen screen = CreatorFactory.ScreenCreator(ScreenType.Web);
screen.Draw();

interface IScreen
{
    void Draw();
}

enum ScreenType
{
    Windows = 1,
    Web = 2
}

class WebScreen : IScreen
{
    public void Draw() => Console.WriteLine("Web page is drawing");
}

class WindowsScreen : IScreen
{
    public void Draw() => Console.WriteLine("Windows drawing");
}

class CreatorFactory
{
    public static IScreen ScreenCreator(ScreenType screenType)
    {
        switch (screenType)
        {
            case ScreenType.Web: return new WebScreen();
            case ScreenType.Windows: return new WindowsScreen();
            default: throw new ArgumentException();
        }
    }
}