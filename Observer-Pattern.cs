using System;
using System.Collections.Generic;
//Observer Pattern &&Loosely Coupled Observer Pattern
//public interface IObserver 
//{
//     Push model :assign the data to the observers and remove the Get Functions from the subject
//    void update(float Temp,float Hum,float Pressure);

//}
//observer interface
public interface IObserver
{
    //Pull Model:not assigning the data to the observers but the observers will get the data from the subject
    void update();
   
}
//subject interface
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

// we do a display interface because theres a displays like weatherLogger Dont have to update so we cant force all the displays to have an update function
public interface IDisplayElement
{
    void display();
}
//concrete subject class    
public class WeatherData : ISubject
{
    // to assign the observers to the list of observers we can assgin a different classes obj from the IObserver interface to the list of observers because of the interface so we can have different types of observers in the list of observers
    private List<IObserver> observers=new List<IObserver>();
    private float temperature;
    private float humidity;
    private float pressure;

    public void RegisterObserver(IObserver observer)

    {
        if (!observers.Contains(observer))
            observers.Add(observer);
    }
    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }
    
    public void MeasurementsChanged()
    {
        NotifyObservers();
    }
    //pull  model for the observers to get the data from the subject
    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        MeasurementsChanged();
    }
    public float GetTemperature()
    {
        return temperature;
    }
    public float GetHumidity()
    {
        return humidity;
    }
    public float GetPressure()
    {
        return pressure;
    }
    public void NotifyObservers()
    {
        foreach (IObserver observer in observers.ToArray())
        {
            observer.update();
        }
    }
}
//concrete observer class
public class CurrentConditionsDisplay : IObserver, IDisplayElement
{
    //DIP principle by interface 
    //    private ISubject subject;
    //    public CurrentConditionsDisplay(ISubject subject)
    //    {
    //        this.subject = subject;
    //        subject.RegisterObserver(this);
    //    }
    // here obj from class so no DIP principle
    private WeatherData weatherData;
    public CurrentConditionsDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
          }
    public void update()
    {
        display();
    }
    public void display()
    {
        Console.WriteLine("Current conditions: " + "Temperature: "+weatherData.GetTemperature()+ " Humidity: "+weatherData.GetHumidity() + " Pressure: "+weatherData.GetPressure());
    }


}
public class StatisticsDisplay : IObserver, IDisplayElement
{
    private WeatherData weatherData;
    public StatisticsDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
    }
    public void update()
    {
        display();
    }
    public void display()
    {
        Console.WriteLine("Statistics Display:");

        Console.WriteLine(
            $"Received temperature: {weatherData.GetTemperature()}");

        Console.WriteLine();
    }
}
public class ForcastDisplay : IObserver, IDisplayElement
{
    private WeatherData weatherData;
    public ForcastDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
    }
    public void update()
    {
        display();
    }
    public void display()
    {
        Console.WriteLine("Forecast Display:");

        if (weatherData.GetPressure() > 1010)
        {
            Console.WriteLine("Weather looks good.");
        }
        else
        {
            Console.WriteLine("Possible bad weather.");
        }

        Console.WriteLine();
    }
}

public class program
{
    public static void Main(string[] args)
    {
        WeatherData weatherData = new WeatherData();
        CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);
        StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);
        ForcastDisplay forecastDisplay = new ForcastDisplay(weatherData);
        weatherData.RegisterObserver(currentDisplay);
        weatherData.RegisterObserver(statisticsDisplay);
        weatherData.RegisterObserver(forecastDisplay);
        Console.WriteLine("First Weather Update");
        weatherData.SetMeasurements(80, 65, 30.4f);
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Second Weather Update");
        weatherData.SetMeasurements(82, 70, 29.2f);
      
        weatherData.RemoveObserver(statisticsDisplay);
        Console.WriteLine("---------------------------------");
        Console.WriteLine(" After Removing Statistics Display from observers.");
        Console.WriteLine("Third Weather Update");
        weatherData.SetMeasurements(78, 90, 29.2f);
    }
}


