using System;

public interface IFlyBehavior
{
    void Fly();
}
public class FlyWithWings : IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("I'm flying with wings!");
    }
}
public class FlyNoWay : IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("I can't fly.");
    }
}
public interface IQuackBehavior
{
    void Quack();
}

public class NormalQuack : IQuackBehavior
{
    public void Quack()
    {
        Console.WriteLine("Quack!");
    }
}

public class Squeak : IQuackBehavior
{
    public void Quack()
    {
        Console.WriteLine("Squeak!");
    }
}
public abstract class Duck
{
    public IFlyBehavior flyBehavior;
   public  IQuackBehavior quackBehavior;
    public void PerformFly()
    {
        flyBehavior.Fly();
    }

    public void PerformQuack()
    {
        quackBehavior.Quack();
    }
    public void SetFlyBehavior(IFlyBehavior behavior)
    {
        flyBehavior = behavior;
    }

    public void SetQuackBehavior(IQuackBehavior behavior)
    {
        quackBehavior = behavior;
    }
    public void Swim()
    {
        Console.WriteLine("All ducks can swim.");
    }

    public abstract void Display ();
}

public class MallardDuck : Duck
{
    public MallardDuck()
    {
        flyBehavior = new FlyWithWings();
        quackBehavior = new NormalQuack();
    }

    public override void Display()
    {
        Console.WriteLine("I am a Mallard Duck.");
    }
}
public class program
{
    public static void Main(string[] args)
    {
        Duck mallard = new MallardDuck();
        mallard.Display();
        mallard.PerformFly();
        mallard.PerformQuack();
        // Change behavior at runtime
        mallard.SetFlyBehavior(new FlyNoWay());
        mallard.SetQuackBehavior(new Squeak());
        Console.WriteLine("After changing behaviors:");
        mallard.PerformFly();
        mallard.PerformQuack();
    }
}
