using System.Collections.Generic;

public class PlatformNetwork
{
    private ProfileNode root;

    public PlatformNetwork()
    {
        root=null;
    }

    public void registerProfile(int uid,string alias,int yob)
    {
        ProfileNode profile=new ProfileNode(uid,alias,yob);
        if(root==null)
        {
            root=profile;
            Console.WriteLine("profile registered");
            return;
        }
        ProfileNode ptr=root;
        while(ptr.nextProfile!=null)
            ptr=ptr.nextProfile;
        ptr.nextProfile=profile;
        Console.WriteLine("profile registered to network");
    }

    public void linkProfiles(int uid1,int uid2)
    {
        ProfileNode prof1=locateProfile(uid1);
        ProfileNode prof2=locateProfile(uid2);
        if(prof1==null||prof2==null)
        {
            Console.WriteLine("one or both profiles not found");
            return;
        }
        if(!prof1.connections.Contains(uid2))
            prof1.connections.Add(uid2);
        if(!prof2.connections.Contains(uid1))
            prof2.connections.Add(uid1);

        Console.WriteLine("connection established");
    }

    public void unlinkProfiles(int uid1,int uid2)
    {
        ProfileNode prof1=locateProfile(uid1);
        ProfileNode prof2=locateProfile(uid2);
        if(prof1==null||prof2==null)
        {
            Console.WriteLine("one or both profiles not found");
            return;
        }
        prof1.connections.Remove(uid2);
        prof2.connections.Remove(uid1);
        Console.WriteLine("connection removed");
    }

    public void showCommonConnections(int uid1,int uid2)
    {
        ProfileNode prof1=locateProfile(uid1);
        ProfileNode prof2=locateProfile(uid2);
        if(prof1==null||prof2==null)
        {
            Console.WriteLine("one or both profiles not found");
            return;
        }
        List<int> shared=new List<int>();
        foreach(int cid in prof1.connections)
        {
            if(prof2.connections.Contains(cid))
                shared.Add(cid);
        }
        if(shared.Count==0)
        {
            Console.WriteLine("no common connections");
            return;
        }
        Console.WriteLine("common connections:");
        foreach(int id in shared)
            Console.WriteLine("  "+id);
    }

    public void displayConnectionsOf(int uid)
    {
        ProfileNode profile=locateProfile(uid);
        if(profile==null)
        {
            Console.WriteLine("profile not found");
            return;
        }
        if(profile.connections.Count==0)
        {
            Console.WriteLine("no connections");
            return;
        }
        Console.WriteLine($"\nconnections of {profile.alias}");
        foreach(int cid in profile.connections)
        {
            ProfileNode conn=locateProfile(cid);
            if(conn!=null)
                Console.WriteLine($"id:{conn.uid} alias: {conn.alias} yob: {conn.yob}");
        }
        Console.WriteLine();
    }

    public void findByAlias(string alias)
    {
        ProfileNode ptr=root;
        while(ptr!=null)
        {
            if(ptr.alias.ToLower()==alias.ToLower())
            {
                Console.WriteLine($"id: {ptr.uid} alias:{ptr.alias} yob: {ptr.yob} connections: {ptr.connections.Count}");
                return;
            }
            ptr=ptr.nextProfile;
        }
        Console.WriteLine("profile not found");
    }

    public void findById(int uid)
    {
        ProfileNode profile=locateProfile(uid);
        if(profile==null)
        {
            Console.WriteLine("profile not found");
            return;
        }
        Console.WriteLine($"id: {profile.uid} alias:{profile.alias} yob: {profile.yob} connections: {profile.connections.Count}");
    }

    public void countConnections(int uid)
    {
        ProfileNode profile=locateProfile(uid);
        if(profile==null)
        {
            Console.WriteLine("profile not found");
            return;
        }
        Console.WriteLine($"{profile.alias} has {profile.connections.Count} connections");
    }

    private ProfileNode locateProfile(int uid)
    {
        ProfileNode ptr=root;
        while(ptr!=null)
        {
            if(ptr.uid==uid)
                return ptr;
            ptr=ptr.nextProfile;
        }
        return null;
    }

    public void displayAll()
    {
        if(root==null)
        {
            Console.WriteLine("no profiles");
            return;
        }
        ProfileNode ptr=root;
        Console.WriteLine("all profiles");
        while(ptr!=null)
        {
            Console.WriteLine($"id: {ptr.uid} alias: {ptr.alias} yob: {ptr.yob} connections: {ptr.connections.Count}");
            ptr=ptr.nextProfile;
        }
        Console.WriteLine();
    }
}
