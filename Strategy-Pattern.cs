using System;
//Strategy Pattern : that we divide the behavior into small classes 
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
class FlyRocketPowered : IFlyBehavior
{
    public void Fly()
{
   Console.WriteLine("Flying with a rocket!");
}}
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
    private IFlyBehavior flyBehavior;
   private  IQuackBehavior quackBehavior;
     protected Duck(IFlyBehavior Fly,IQuackBehavior Quack)
 {
     flyBehavior = Fly;
     quackBehavior = Quack;
 }
    public void PerformFly()
    {
        flyBehavior.Fly();
    }

    public void PerformQuack()
    {
        quackBehavior.Quack();
    }
    //ONE of the benefit in Strategy pattern that we can change te behavior in Run time
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
    public MallardDuck():base(new FlyWithWings(), new NormalQuack())
    {
    }

    public override void Display()
    {
        Console.WriteLine("I am a Mallard Duck.");
    }
}
public class ModelDuck: Duck
{
    public ModelDuck():base(new FlyNoWay(), new NormalQuack())
    {
        
    }
    public override void Display() {
        Console.WriteLine("I am A Model Duck!");
    } 
}
public class program
{
    public static void Main(string[] args)
    {
        //Obj Type Duck but the rael one is MallardDuck
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
         Console.WriteLine("---------------------------------------");
  Duck model = new ModelDuck();

  model.Display();
         
  // Change behavior at runtime
  model.SetFlyBehavior(new FlyRocketPowered());

  model.PerformFly();
    }
}
