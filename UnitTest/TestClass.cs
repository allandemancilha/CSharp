using Xunit;
// UniTest: Namespace
using UnitTest;

public class TestClass
{
    /* 
        Theory: Uma Teoria Executa o Mesmo Teste Utilizando Uma Série de Parâmetros Definidos, Quando 
        Algum Parâmetro Não Passa no Teste, a Teoria é Considerada Falha.
    */
    [Theory]
    // InlineData: Utilizado Para Definir os Dados Que Serão Utilizados Como Parâmetro Pela Teoria
    [InlineData(5)]
    [InlineData(11)]
    [InlineData(19)]
    public void MyFirstTheory(int value)
    {
        Assert.True(Program.IsOdd(value));
    }

    // Fact: O Atributo Declara um Método de Teste Que é Executado Pelo Executor de Teste.
    [Fact]
    public void PassingAddTest()
    {
        Assert.Equal(4 , Program.Add(2,2));
    }

    [Fact]
    public void FallingAddTest()
    {
        Assert.NotEqual(5, Program.Add(2, 2));
    }
}