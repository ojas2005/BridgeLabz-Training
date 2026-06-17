class Program
{
    static void Main()
    {
        PlatformNetwork net=new PlatformNetwork();

        net.registerProfile(1,"alice",25);
        net.registerProfile(2,"bob",26);
        net.registerProfile(3,"charlie",24);
        net.registerProfile(4,"diana",27);
        net.linkProfiles(1,2);
        net.linkProfiles(1,3);
        net.linkProfiles(2,3);
        net.linkProfiles(2,4);
        net.displayAll();
        net.displayConnectionsOf(1);
        net.showCommonConnections(1,2);
        net.countConnections(2);
        net.findByAlias("alice");
        net.unlinkProfiles(1,3);

        net.displayConnectionsOf(1);
    }
}
