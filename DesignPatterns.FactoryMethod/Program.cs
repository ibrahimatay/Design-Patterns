namespace DesignPatterns.FactoryMethod;

interface IScreen 
{
    void Draw();
}

enum ScreenType 
{
    Windows, Web
}

static class CreatorFactory 
{
    public static IScreen ScreenCreator(ScreenType screenType)  =>
        screenType switch
        {
            ScreenType.Web => new WebScreen(),
            ScreenType.Windows => new WindowsScreen(),
            _ => throw new InvalidOperationException($"Unknown screen type: {screenType}")
        };
}

class WebScreen : IScreen 
{
    public void Draw() => Console.WriteLine("Web page is drawing");
}

class WindowsScreen : IScreen 
{
    public void Draw() => Console.WriteLine("Windows page is drawing");
}

class App
{
    public static void Main(string[] args)
    {
        IScreen screen = CreatorFactory.ScreenCreator(ScreenType.Web);
        screen.Draw();
    }
}