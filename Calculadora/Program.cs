using System;
using System.Collections;
using System.Collections.Generic;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Operacoes> filaOperacoes = new Queue<Operacoes>();
            filaOperacoes.Enqueue(new Operacoes { valorA = 2, valorB = 3, operador = '+' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 14, valorB = 8, operador = '-' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 5, valorB = 6, operador = '*' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 2147483647, valorB = 2, operador = '+' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 18, valorB = 3, operador = '/' }); //Implemente o calculo de divisao

            Calculadora calculadora = new Calculadora();

            
            while (filaOperacoes.Count > 0) // Condição ajustada para garantir que o loop finalize quando a fila estiver vazia.
            {
                // Implementar tratamento de exceção para divisão por zero
                try
                {
                    Operacoes operacao = filaOperacoes.Dequeue(); // Metódo corrigido para que os elementos seja retirados da fila após processamento.
                    calculadora.calcular(operacao);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Operação processada:");
                    Console.ResetColor();
                    Console.WriteLine("{0} {1} {2} = {3}\n", operacao.valorA, operacao.operador, operacao.valorB, operacao.resultado);
                    //Imprimir a lista de operações a ser processada após do cálculo
                    if (filaOperacoes.Count > 0)
                        ImprimirFilaOperacoes(filaOperacoes);
                    else
                        Console.WriteLine("Nenhuma operação restante na fila.\n");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

            }
        }
        private static void ImprimirFilaOperacoes(Queue<Operacoes> fila)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Próximas operações na fila: {0}", fila.Count);
            Console.ResetColor(); 
            foreach (var operacao in fila)
            {
                Console.WriteLine("{0} {1} {2}", operacao.valorA, operacao.operador, operacao.valorB);
            }
            Console.WriteLine("\n--------------------------------\n");
        }       
    }
}
