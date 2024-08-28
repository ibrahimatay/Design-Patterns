

// https://github.com/dotnet/corefx/blob/b8b81a66738bb10ef0790023598396861d92b2c4/src/Common/src/CoreLib/System/Lazy.cs
// https://learn.microsoft.com/en-us/dotnet/api/system.lazy-1?view=net-8.0

/*
 LazyThreadSafetyMode
	.None
	.PublicationOnly
	.ExecutionAndPublication
 */

var lazyString = new Lazy<string>(() =>
{
    // Here you can do some complex processing and then return a value.
    Console.Write("Inside lazy loader");
    return "Lazy loading!";
}, LazyThreadSafetyMode.PublicationOnly);

for (int i = 0; i <= 5; i++)
{
    Console.WriteLine();
    Console.WriteLine($"Index:{i}");
    Thread.Sleep(1000);
    Console.Write("Is value created: ");
    Console.WriteLine(lazyString.IsValueCreated);

    Console.Write("Value: ");
    Console.WriteLine(lazyString.Value);

    Console.Write("Value again: ");
    Console.WriteLine(lazyString.Value);

    Console.Write("Is value created: ");
    Console.WriteLine(lazyString.IsValueCreated);
}



Console.WriteLine("Press any key to continue ...");
Console.ReadLine();