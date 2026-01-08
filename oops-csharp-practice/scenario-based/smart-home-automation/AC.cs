using System;
public class AC:Appliance,IControllable
{
  public int temperature;
  public string mode;
  public AC(string deviceName):base(deviceName)
  {
    temperature=20;
    mode="cool";
  }
  public void TurnOn()
  {
    isOn=true;
    Console.WriteLine($"{name} is turned ON in {mode} mode at {temperature}C");
  }
  public void TurnOff()
  {
    isOn=false;
    Console.WriteLine($"{name} is turned OFF");
  }
  public void SetTemperature(int temp)
  {
    temperature=temp;
    Console.WriteLine($"{name} temperature set to {temp}C");
  }
  public void SetMode(string m)
  {
    mode=m;
    Console.WriteLine($"{name} mode changed to {m}");
  }
}
