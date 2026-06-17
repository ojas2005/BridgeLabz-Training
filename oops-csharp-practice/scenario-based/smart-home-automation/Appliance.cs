using System;
public abstract class Appliance
{
  public string name;
  public bool isOn;
  public Appliance(string deviceName)
  {
    name=deviceName;
    isOn=false;
  }
  public string GetStatus()
  {
    return isOn?"On":"Off";
  }
}
