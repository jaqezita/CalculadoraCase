## CalculadoraCase - Resolução do Desafio Técnico

Este repositório contém a solução completa para o *Case* de Desenvolvimento Júnior, focado na correção e implementação de funcionalidades em uma aplicação de calculadora C#, utilizando as estruturas de dados **Queue (Fila)** e **Stack (Pilha)**.

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
2.  O método `Main` **capta** a exceção (`try-catch`), isolando a falha e permitindo que o processamento do restante da Fila continue (`continue`).

### Estruturas de Dados
* **Queue (`filaOperacoes`):** Usada para a **entrada** das operações, garantindo o fluxo **FIFO** (First-In, First-Out).
* **Stack (`historicoResultados`):** Usada para o **armazenamento** dos resultados, imprimindo-os na ordem **LIFO** (Last-In, First-Out).

---

## Como Executar o Projeto

O projeto pode ser executado em qualquer IDE que suporte .NET (como VS Code com extensões C#).

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/SEU_USUARIO/CalculadoraCase.git](https://github.com/SEU_USUARIO/CalculadoraCase.git)
    ```
2.  **Navegue até o diretório:**
    ```bash
    cd CalculadoraCase
    ```
3.  **Execute:**
    ```bash
    dotnet run
    ```