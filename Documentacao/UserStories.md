# User Stories — Calculadora de Médias
**Projeto:** ESWA01CalculadoraDeMedias  
**Equipe:** 01

---

## US01 — Inserir notas
**Como** usuário,  
**Quero** digitar as notas NP1, NP2 e PIM,  
**Para que** o sistema calcule a média semestral.

**Critérios de Aceitação:**
- Campos aceitam apenas dígitos e vírgula
- Valores devem estar no intervalo [0,0 ; 10,0]
- Mensagem de erro exibida para entradas inválidas

---

## US02 — Calcular Média Semestral
**Como** usuário,  
**Quero** clicar em "Semestral" após preencher as notas,  
**Para que** o sistema exiba a média semestral e o status.

**Critérios de Aceitação:**
- MS = (4×NP1 + 4×NP2 + 2×PIM) / 10
- Arredondamento AwayFromZero, 1 casa decimal
- MS ≥ 7,0 → "Aprovado" (verde)
- MS < 7,0 → "Em Exame" (laranja), seção Final habilitada

---

## US03 — Calcular Média Final
**Como** usuário em exame,  
**Quero** inserir a nota do Exame e clicar em "Final",  
**Para que** o sistema informe se fui aprovado ou reprovado.

**Critérios de Aceitação:**
- Seção Final só fica disponível quando status = Em Exame
- MF = (MS + EX) / 2
- MF ≥ 5,0 → "Aprovado" (verde)
- MF < 5,0 → "Reprovado" (vermelho)

---

## US04 — Limpar campos
**Como** usuário,  
**Quero** limpar os campos,  
**Para que** eu possa calcular as médias de outro aluno.

**Critérios de Aceitação:**
- "Limpar" (Semestral): zera tudo, status = "Em Andamento", desabilita seção Final
- "Limpar" (Final): limpa só o Exame e a Média Final, cor do status = preto

---

## US05 — Testes e qualidade
**Como** desenvolvedor,  
**Quero** que o sistema tenha testes unitários,  
**Para que** o código seja confiável e fácil de manter.

**Critérios de Aceitação:**
- Testes xUnit cobrindo validações, cálculos de MS e MF, status e sanitização
- Todos os testes passam no `dotnet test`
- Biblioteca disponível como .dll no NuGet
