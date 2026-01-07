using System;
sealed class EmployeeMenu{
    private IEmployee empUtility;
    public void EmployeeChoice(){
        empUtility = new EmployeeUtilityImpl();
    }


}