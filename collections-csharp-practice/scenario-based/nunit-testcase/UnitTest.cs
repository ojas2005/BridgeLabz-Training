using NUnit.Framework;

[TestFixture]
public class UnitTest
{
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        Program account = new Program(100);
        account.Deposit(50);
        Assert.AreEqual(150, account.Balance);
    }

    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        Program account = new Program(100);
        Assert.Throws<ArgumentException>(() => account.Deposit(-50));
    }

    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        Program account = new Program(100);
        account.Withdraw(30);
        Assert.AreEqual(70, account.Balance);
    }

    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        Program account = new Program(100);
        Assert.Throws<InvalidOperationException>(() => account.Withdraw(150));
    }
}
