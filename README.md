# Plugin Demo em C# com xUnit

Este exemplo demonstra como criar uma solução simples com plugin em C# e testar os comportamentos com xUnit.

## Objetivo

Mostrar a ideia de extensibilidade de software, onde novos comportamentos podem ser adicionados por módulos independentes chamados plugins.

## Estrutura do projeto

```text
plugin-csharp-demo/
├── PluginDemo.Core/
│   └── Class1.cs
├── PluginDemo.Tests/
│   └── UnitTest1.cs
├── PluginDemo.sln
└── README.md
```

## Conceito

A interface `IPlugin` define a regra comum para qualquer plugin.

Os plugins implementam:

- um nome;
- uma operação de processamento;
- uma saída textual.

## Plugins criados

### CsvPlugin
Processa uma entrada em formato CSV e retorna informações como:

- colunas;
- quantidade de linhas.

### CalculatorPlugin
Recebe uma sequência de números separados por vírgula e retorna a soma total.

## Como testar

No terminal, execute:

```powershell
cd "c:\Users\LeonardoJoseCordeiro\Desktop\exercicios aula de ia\plugin-csharp-demo"
dotnet test --nologo
```

## Resultado esperado

Os testes devem passar com sucesso.

## Observação

Este projeto é um exemplo didático, criado para mostrar modularização, extensão de comportamento e testes automatizados.
