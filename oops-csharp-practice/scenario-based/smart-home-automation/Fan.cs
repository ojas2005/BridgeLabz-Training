using System;
public class Fan:Appliance,IControllable
{
  public int speed;
  public Fan(string deviceName):base(deviceName)
  {
    speed=0;
  }
  public void TurnOn()
  {
    isOn=true;
    speed=50;
    Console.WriteLine($"{name} is turned ON at {speed}% speed");
  }
  public void TurnOff()
  {
    isOn=false;
    speed=0;
    Console.WriteLine($"{name} is turned OFF");
  }
  public void SetSpeed(int spd)
  {
    speed=spd;
    Console.WriteLine($"{name} speed set to {speed}%");
  }
}
