# Threads com e sem seção crítica

Este projeto demonstra o uso de múltiplas threads em C#.

- ThreadsSemTrava: escrita sem controle (erro)
- ThreadsComTrava: escrita com lock (correto)

Cada thread escreve 500 linhas, totalizando 10.000 linhas.

Objetivo: demonstrar condição de corrida e uso de seção crítica.
