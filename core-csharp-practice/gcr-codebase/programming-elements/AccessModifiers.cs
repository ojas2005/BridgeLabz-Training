using System;
class AccessModifiers{
    public int publicNum = 43;
    private int privateNum = 10;
    protected int protectedNum = 12;
    internal int internalNum = 18;
    protected internal int protectedInternalNum = 20;
    private protected int privateProtectedNum = 25;
    public void ShowPvt()
    {
        Console.WriteLine(privateNum);
    }
    static void Main()
    {
        AccessModifiers obj = new AccessModifiers();
        Console.WriteLine(obj.publicNum);
        Console.WriteLine(obj.internalNum);
        Console.WriteLine(obj.protectedInternalNum);
        obj.ShowPvt;
    }
}