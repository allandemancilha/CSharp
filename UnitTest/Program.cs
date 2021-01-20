using System;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumResult = Add(5, 6);

            Console.WriteLine(sumResult);
            Console.WriteLine(IsOdd(sumResult));
        }

        // Add: O Método Recebe Dois Números Inteiros Como Parâmetro e Retorna o Valor da Soma
        public static int Add(int x, int y)
        {
            return x + y;
        }
        
        /* 
            IsOdd: O Método Recebe um Número Inteiro Como Parâmetro e Verifica se o Número é Ímpar, Ca-
            so o Número Seja Ímpar é Retornado true
        */
        public static bool IsOdd(int value)
        {
            return value % 2 == 1;
        }
    }
}
