using System;
public class Light:Appliance,IControllable
{
  public int brightness;
  public Light(string deviceName):base(deviceName)
  {
    brightness=100;
  }
  public void TurnOn()
  {
    isOn=true;
    Console.WriteLine($"{name} is turned ON at {brightness}% brightness");
  }
  public void TurnOff()
  {
    isOn=false;
    Console.WriteLine($"{name} is turned OFF");
  }
  public void SetBrightness(int level)
  {
    brightness=level;
    Console.WriteLine($"{name} brightness set to {level}%");
  }
}
