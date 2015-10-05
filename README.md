# MatchPatternSQL
C# Listar padrões não aceitáves em procs de SQL

Objetivo do programa:
O programa fará uma uma varredura nas proceures (*.sql) e irá procurar por padrões de SQL não recomendados.
Por exemplo: Listar quais procedures fazem select com *, ou update sem where, etc...
Solução:
Para isso, será utilizada a classe Regex para fazer o Match com base nos padrões que serão definidos posteriormente.

Próximos passos:
1 - Abrir os arquivos *.sql
2 - Preparar o arquivos para fazer o match
3 - Fazer o Match, listar os que deram erro e somar um no contador...
