using Xunit;
using Calculadora;
using System;
using System.Collections.Generic;

public class CalculadoraCoreTests
{
    private readonly Calculadora.Calculadora _calc = new Calculadora.Calculadora();

    // 1. Testes de Soma
    [Fact]
    public void Teste_Soma_DoisNumerosPositivos()
    {
        Operacoes op = new Operacoes { valorA = 2M, valorB = 3M, operador = '+' };
        _calc.calcular(op);
        
        Assert.Equal(5M, op.resultado);
    }

    [Fact]
    public void Teste_Soma_NumerosNegativos()
    {
        Operacoes op = new Operacoes { valorA = -5M, valorB = -3M, operador = '+' };
        _calc.calcular(op);

        Assert.Equal(-8M, op.resultado);
    }

    // 2. Teste de Overflow
    [Fact]
    public void Teste_Soma_NumeroGrande_OverflowCorrigido()
    {
        Operacoes op = new Operacoes { valorA = 2147483647M, valorB = 2M, operador = '+' }; 
        decimal expected = 2147483649M;

        _calc.calcular(op);

        Assert.Equal(expected, op.resultado);
    }

    // 3. Testes de Subtração
    [Fact]
    public void Teste_Subtracao_ResultadoPositivo()
    {
        Operacoes op = new Operacoes { valorA = 14M, valorB = 8M, operador = '-' };
        _calc.calcular(op);

        Assert.Equal(6M, op.resultado);
    }
    
    [Fact]
    public void Teste_Subtracao_ResultadoNegativo()
    {
        Operacoes op = new Operacoes { valorA = 5M, valorB = 10M, operador = '-' };
        _calc.calcular(op);

        Assert.Equal(-5M, op.resultado);
    }

    // 4. Testes de Multiplicação
    [Fact]
    public void Teste_Multiplicacao_DoisNumerosPositivos()
    {
        Operacoes op = new Operacoes { valorA = 5M, valorB = 6M, operador = '*' };
        _calc.calcular(op);

        Assert.Equal(30M, op.resultado);
    }

    [Fact]
    public void Teste_Multiplicacao_ComZero()
    {
        Operacoes op = new Operacoes { valorA = 100M, valorB = 0M, operador = '*' };
        _calc.calcular(op);

        Assert.Equal(0M, op.resultado);
    }

    // 5. Testes de Divisão (Incluindo Casos de Borda do Item 2)
    [Fact]
    public void Teste_Divisao_SemResto()
    {
        Operacoes op = new Operacoes { valorA = 18M, valorB = 3M, operador = '/' };
        _calc.calcular(op);

        Assert.Equal(6M, op.resultado);
    }

    [Fact]
    public void Teste_Divisao_ComCasasDecimais()
    {
        Operacoes op = new Operacoes { valorA = 10M, valorB = 3M, operador = '/' };
        _calc.calcular(op);

        decimal expected = 10.0M / 3.0M;
        Assert.Equal(expected, op.resultado);
    }
    
    [Fact]
    public void Teste_Divisao_PorZero_DeveLancarExcecao()
    {
        Operacoes op = new Operacoes { valorA = 10M, valorB = 0M, operador = '/' };

        Assert.Throws<DivideByZeroException>(() => _calc.calcular(op));
    }

    // 6. Testes de Operador/Retorno
    [Fact]
    public void Teste_OperadorInvalido_DeveRetornarZero()
    {
        Operacoes op = new Operacoes { valorA = 5M, valorB = 3M, operador = '%' };
        _calc.calcular(op);

        Assert.Equal(0M, op.resultado);
    }

    [Fact]
    public void Teste_Calcular_DeveRetornarObjetoOperacao()
    {
        Operacoes op = new Operacoes { valorA = 7M, valorB = 2M, operador = '+' };

        Operacoes resultado = _calc.calcular(op);

        Assert.Same(op, resultado);
        Assert.Equal(9M, resultado.resultado);
    }
}