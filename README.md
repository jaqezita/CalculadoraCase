## CalculadoraCase - Resolução do Desafio Técnico

Este repositório contém a solução para o *Case* de Desenvolvimento Júnior, focado na correção e implementação de funcionalidades em uma aplicação de calculadora C#, utilizando as estruturas de dados **Queue (Fila)** e **Stack (Pilha)**.

---

## Requisitos Atendidos


| Item | Requisito do Case | Solução Implementada |
| :--- | :--- | :--- |
| **1.** | Aplicação só processando o primeiro item. | Corrigido o fluxo do `while` para usar **`Dequeue()`** e a condição **`Count > 0`**, eliminando o *loop* infinito e garantindo o consumo total da Fila. |
| **2.** | Implemente a funcionalidade de divisão. | Adicionado o método `divisao` e implementado o tratamento de erro com **`throw new DivideByZeroException()`**. O `try-catch` no `Main` isola a falha, permitindo que as operações subsequentes continuem. |
| **3.** | Cálculo da penúltima operação incorreto. | Corrigido o problema de **Integer Overflow**. A classe `Operacoes` e os métodos de cálculo foram alterados para o tipo **`decimal`**, garantindo a precisão e a capacidade necessária para valores grandes (`2147483647 + 2 = 2147483649`). |
| **4.** | Imprimir a lista de operações restante. | Implementado o método `ImprimirFilaOperacoes` que utiliza a iteração (`foreach`) na `Queue` para inspecionar os elementos **sem removê-los**, demonstrando o estado atual da Fila após cada cálculo. |
| **5.** | Criar Pilha (Stack) de resultados. | Criada a estrutura **`Stack<decimal>`** para armazenar o resultado de cada cálculo com o método **`.Push()`**. A impressão final utiliza o método **`.Pop()`** em um *loop* `while` para demonstrar o princípio **LIFO** (Last-In, First-Out). |

---

## Estrutura 

### Tratamento de Exceções
A responsabilidade foi dividida:
1.  O método `divisao` **lança** a exceção (`throw`).
2.  O método `multiplicacao` **lança** a exceção (`throw`).
3.  O método `Main` **capta** a exceção (`try-catch`), isolando a falha e permitindo que o processamento do restante da Fila continue (`continue`).

### Estruturas de Dados
* **Queue (`filaOperacoes`):** Usada para a **entrada** das operações, garantindo o fluxo **FIFO** (First-In, First-Out).
* **Stack (`historicoResultados`):** Usada para o **armazenamento** dos resultados, imprimindo-os na ordem **LIFO** (Last-In, First-Out).

---

## Como Executar o Projeto

O projeto pode ser executado em qualquer IDE que suporte .NET (como VS Code com extensões C#).

1.  **Clone o repositório:**
    ```bash
    git clone https://github.com/jaqezita/CalculadoraCase.git
    ```
2.  **Navegue até o diretório:**
    ```bash
    cd CalculadoraCase
    cd Calculadora
    ```
3.  **Execute:**
    ```bash
    dotnet run
    ```

---

## Saída Esperada no Console

A saída demonstra a resolução do *overflow* e o fluxo de dados **FIFO** (processamento da fila) seguido pela inversão **LIFO** (impressão da pilha).

```bash
Operação processada:
2 + 3 = 5

Próximas operações na fila: 4
14 - 8
5 * 6
2147483647 + 2
18 / 3

...

Operação processada:
2147483647 + 2 = 2147483649 <-- Valor corrigido após alteração para o tipo decimal

...

Operação processada:
18 / 3 = 6

Nenhuma operação restante na fila.

===================================

Histórico de resultados:
6                    <-- Último a ser calculado, primeiro a sair (LIFO)
2147483649           
30
6
5                    <-- Primeiro a ser calculado, último a sair
```


---
### Testes Unitários

A solução contém um projeto dedicado (`Calculadora.Tests`) com testes **xUnit**.

1.  **Navegue até o diretório:**
    ```bash
    cd Calculadora.Tests
    ```

2.  **Execute os Testes:**
    ```bash
    dotnet test
    ```
    A saída deve indicar que **se os testes foram aprovados ou reprovados**.
