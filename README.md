# ESWA01 — Calculadora de Médias

Projeto da disciplina ESWA+POO, Equipe 01.

## Estrutura

```
ESWA01CalculadoraDeMedias/   ← biblioteca de cálculo (.dll)
CalculadoraDeMedias01/       ← app Windows Forms
ESWA01CalculadoraDeMedias.Tests/  ← testes xUnit
OOPFoundation/               ← classes base e interfaces
Documentacao/                ← User Stories
```

## Como rodar

Abrir o `.sln` no Visual Studio 2022, definir `CalculadoraDeMedias01` como projeto de inicialização e pressionar F5.

Os arquivos da pasta `OOPFoundation/` precisam ser adicionados como "Existing Items" no projeto `ESWA01CalculadoraDeMedias`.

## Testes

```bash
dotnet test
```

## Fórmulas

| Cálculo | Fórmula |
|---------|---------|
| Média Semestral | (4×NP1 + 4×NP2 + 2×PIM) / 10 |
| Média Final | (MS + EX) / 2 |

| Condição | Status | Cor |
|----------|--------|-----|
| MS ≥ 7,0 | Aprovado | Verde |
| MS < 7,0 | Em Exame | Laranja |
| MF ≥ 5,0 | Aprovado | Verde |
| MF < 5,0 | Reprovado | Vermelho |
