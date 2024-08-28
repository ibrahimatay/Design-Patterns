
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

static class CreatorFactory
{
    public static IScreen ScreenCreator(ScreenType screenType) => screenType switch
    {
        ScreenType.Web => new WebScreen(),
        ScreenType.Windows => new WindowsScreen(),
        _ => throw new ArgumentException()
    };
}