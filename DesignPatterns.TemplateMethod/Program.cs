namespace DesignPatterns.TemplateMethod;

public abstract class BreadMaker
{
    protected abstract void Bake();
    protected abstract void MixIngredients();
        
    protected void Slice() => Console.WriteLine("Slicing the bread!");

    public void Make()
    {
        MixIngredients();
        Bake();
        Slice();
    }
}

public class GrainBread : BreadMaker
{
    protected override void Bake() => Console.WriteLine("Baking the Grain Bread. (25 minutes)");
    protected override void MixIngredients() => Console.WriteLine("Gathering Ingredients for Grain Bread.");
}

public class WholeWheatBread : BreadMaker
{
    protected override void Bake() => Console.WriteLine("Baking the Whole Wheat Bread. (15 minutes)");
    protected override void MixIngredients() => Console.WriteLine("Gathering Ingredients for Whole Wheat Bread.");
}

class App
{
    static void Main()
    {
        BreadMaker wholeWheat = new WholeWheatBread();
        wholeWheat.Make();

        Console.WriteLine();

        BreadMaker grain = new GrainBread();
        grain.Make();
    }
}