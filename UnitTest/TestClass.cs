using Xunit;
using UnitTest;

public class TestClass
{
    
    [Fact]
    public void PassingAddTest()
    {
        Assert.Equal(4 , Program.Add(2,2));
    }
}