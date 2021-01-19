using Xunit;
// UniTest: Namespace
using UnitTest;

public class TestClass
{
    // Fact: O Atributo Declara um Método de Teste Que é Executado Pelo Executor de Teste.
    [Fact]
    public void PassingAddTest()
    {
        Assert.Equal(4 , Program.Add(2,2));
    }
}