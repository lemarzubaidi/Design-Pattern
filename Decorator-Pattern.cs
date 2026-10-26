using System;
//Delegation: the obj of the decorator class is passed to the constructor of the decorator class and the decorator class delegates the work to the obj of the decorator class
// obj call obj to done the mission
public abstract class Beverage
{
    public abstract string GetDescription();
    public abstract decimal Cost();
}
/// <summary>
/// IS-A relationship == Inheritance 
/// </summary>
public abstract class CondimentDecorator : Beverage
{
    // help us to go forward and backward in the decorator chain Has-A relationship == Composition
    protected Beverage beverage;
    //to store the path
    public CondimentDecorator(Beverage beverage)
    {
        this.beverage = beverage;
    }
}


public class DarkRoast : Beverage
{
    public override string GetDescription()
    {
        return "Dark Roast Coffee";
    }
    public override decimal Cost()
    {
        return 0.99m;
    }
}
public class Espresso : Beverage
{
    public override string GetDescription()
    {
        return "Espresso Coffee";
    }
    public override decimal Cost()
    {
        return 1.99m;
    }
}
public class HouseBlend : Beverage
{
    public override string GetDescription()
    {
        return "House Blend Coffee";
    }
    public override decimal Cost()
    {
        return 0.89m;
    }
}
public class Decaf : Beverage
{
    public override string GetDescription()
    {
        return "Decaf Coffee";
    }
    public override decimal Cost()
    {
        return 1.05m;
    }
}
public class  Mocha: CondimentDecorator
{
    //base(beverage) mean: condimentdecorator class constructor will be called and store in it
    public Mocha(Beverage beverage):base(beverage)
    {
    }
   public override string GetDescription()
    {
        return beverage.GetDescription() + ", Mocha";
    }
    public override decimal Cost()
    {
        return beverage.Cost() + 0.20m;
    }
}
public class Whip : CondimentDecorator
{
    public Whip(Beverage beverage) : base(beverage)
    {
    }
    public override string GetDescription()
    {
        return beverage.GetDescription() + ", Whip";
    }
    public override decimal Cost()
    {
        return beverage.Cost() + 0.10m;
    }
}
public class Milk : CondimentDecorator
{
    public Milk(Beverage beverage) : base(beverage)
    {
    }
    public override string GetDescription()
    {
        return beverage.GetDescription() + ", Milk";
    }
    public override decimal Cost()
    {
        return beverage.Cost() + 0.10m;
    }
}
public class Soy : CondimentDecorator
{
    //when we make the obj we call the constructor of the condimentdecorator class and pass the obj of the beverage class to it to store it
    public Soy(Beverage beverage) : base(beverage)
    {
    }
    public override string GetDescription()
    {
        return beverage.GetDescription() + ", Soy";
    }
    //beverage .Cost() will call the cost method of the beverage class and add 0.15 to it and return it
    //beverage indicates to another obj that condimentdecorator class has save it
    public override decimal Cost()
    {
        return beverage.Cost() + 0.15m;
    }
}
    public class program
{
    public static void Main(string[] args)
    {
        //multiple decorators 
        Beverage coffee = new HouseBlend();
        coffee = new Mocha(coffee);
        coffee = new Whip(coffee);
        coffee = new Soy(coffee);
        Console.WriteLine(coffee.GetDescription() + " $" + coffee.Cost());
    }
}