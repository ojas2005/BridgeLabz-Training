using System.Collections.Generic;

public class ProfileNode
{
    public int uid;
    public string alias;
    public int yob;
    public List<int> connections;
    public ProfileNode nextProfile;

    public ProfileNode(int uid,string alias,int yob)
    {
        this.uid=uid;
        this.alias=alias;
        this.yob=yob;
        this.connections=new List<int>();
        this.nextProfile=null;
    }
}
