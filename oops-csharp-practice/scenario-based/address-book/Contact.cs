using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Contact
{
    private string givenName;
    private string surname;
    private string streetAddress;
    private string municipality;
    private string province;
    private string postalCode;
    private string mobileNum;
    private string emailAddr;
    public Contact(string givenName,string surname,string streetAddress,string municipality,string province,string postalCode,string mobileNum,string emailAddr)
    {
        this.givenName=givenName;
        this.surname=surname;
        this.streetAddress=streetAddress;
        this.municipality=municipality;
        this.province=province;
        this.postalCode=postalCode;
        this.mobileNum=mobileNum;
        this.emailAddr=emailAddr;
    }
    public string GetGivenName(){return givenName;}
    public string GetSurname(){return surname;}
    public string GetStreetAddress(){return streetAddress;}
    public string GetMunicipality(){return municipality;}
    public string GetProvince(){return province;}
    public string GetPostalCode(){return postalCode;}
    public string GetMobileNum(){return mobileNum;}
    public string GetEmailAddr(){return emailAddr;}
    public override string ToString()
    {
        return $"name: {givenName} {surname} \naddress: {streetAddress}, {municipality}, {province} - {postalCode}\nmobile: {mobileNum}\nemail: {emailAddr}";
    }
}

