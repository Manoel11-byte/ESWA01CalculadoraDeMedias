using System;
using ESWA01CalculadoraDeMedias;
using OOPFoundation;
using Xunit;

namespace ESWA01CalculadoraDeMedias.Tests
{
    // Testes de validação de notas
    public class NoteValidationTests
    {
        private readonly NoteValidation _v = new();

        [Theory]
        [InlineData(0.0)]
        [InlineData(5.0)]
        [InlineData(7.5)]
        [InlineData(10.0)]
        public void NotasValidas_DeveRetornarTrue(double nota)
            => Assert.True(_v.DoubleIsValid(nota));

        [Theory]
        [InlineData(-0.1)]
        [InlineData(10.1)]
        [InlineData(-1.0)]
        public void NotasInvalidas_DeveRetornarFalse(double nota)
            => Assert.False(_v.DoubleIsValid(nota));
    }

    // Testes de validação de pesos
    public class WeightValidationTests
    {
        private readonly WeightValidation _v = new();

        [Theory]
        [InlineData(0.0)]
        [InlineData(0.5)]
        [InlineData(1.0)]
        public void PesosValidos_DeveRetornarTrue(double peso)
            => Assert.True(_v.DoubleIsValid(peso));

        [Theory]
        [InlineData(-0.1)]
        [InlineData(1.1)]
        public void PesosInvalidos_DeveRetornarFalse(double peso)
            => Assert.False(_v.DoubleIsValid(peso));

        [Fact]
        public void SomaDePesos_DeveSerUm()
        {
            double p1 = 4.0 / 10.0;
            double p2 = 4.0 / 10.0;
            double p3 = 2.0 / 10.0;
            Assert.Equal(1.0, p1 + p2 + p3);
        }
    }

    // Testes de cálculo da média semestral
    public class MediaSemestralTests
    {
        private readonly GradeCalculator _calc = new();

        [Theory]
        [InlineData(10.0, 10.0, 10.0, 10.0)]
        [InlineData(0.0,  0.0,  0.0,  0.0)]
        [InlineData(7.0,  7.0,  7.0,  7.0)]
        [InlineData(8.0,  6.0,  7.0,  7.0)]
        [InlineData(5.0,  5.0,  5.0,  5.0)]
        [InlineData(6.0,  6.0,  7.5,  6.3)]
        public void CalculoCorreto(double np1, double np2, double pim, double esperado)
        {
            var r = _calc.CalculateSemestral(np1, np2, pim);
            Assert.Equal(esperado, r.MediaSemestral);
        }

        [Theory]
        [InlineData(7.0,  7.0,  7.0)]
        [InlineData(10.0, 10.0, 10.0)]
        [InlineData(8.0,  8.0,  8.0)]
        public void MediaAcimaDe7_StatusAprovado(double np1, double np2, double pim)
        {
            var r = _calc.CalculateSemestral(np1, np2, pim);
            Assert.Equal(StudentStatus.Aprovado, r.Status);
        }

        [Theory]
        [InlineData(0.0, 0.0, 0.0)]
        [InlineData(5.0, 5.0, 5.0)]
        [InlineData(6.9, 6.9, 6.9)]
        public void MediaAbaixoDe7_StatusEmExame(double np1, double np2, double pim)
        {
            var r = _calc.CalculateSemestral(np1, np2, pim);
            Assert.Equal(StudentStatus.EmExame, r.Status);
        }

        [Fact]
        public void NotaInvalida_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => _calc.CalculateSemestral(11.0, 5.0, 5.0));
        }
    }

    // Testes de cálculo da média final
    public class MediaFinalTests
    {
        private readonly GradeCalculator _calc = new();

        [Theory]
        [InlineData(6.0, 6.0, 6.0)]
        [InlineData(6.0, 4.0, 5.0)]
        [InlineData(4.0, 6.0, 5.0)]
        [InlineData(0.0, 0.0, 0.0)]
        [InlineData(10.0, 10.0, 10.0)]
        [InlineData(6.5, 5.5, 6.0)]
        public void CalculoCorreto(double ms, double ex, double esperado)
        {
            var r = _calc.CalculateFinal(ms, ex);
            Assert.Equal(esperado, r.MediaFinal);
        }

        [Theory]
        [InlineData(5.0, 5.0)]
        [InlineData(6.0, 6.0)]
        [InlineData(10.0, 10.0)]
        public void MediaAcimaDe5_StatusAprovado(double ms, double ex)
        {
            var r = _calc.CalculateFinal(ms, ex);
            Assert.Equal(StudentStatus.Aprovado, r.Status);
        }

        [Theory]
        [InlineData(0.0, 0.0)]
        [InlineData(4.0, 4.0)]
        [InlineData(4.9, 4.9)]
        public void MediaAbaixoDe5_StatusReprovado(double ms, double ex)
        {
            var r = _calc.CalculateFinal(ms, ex);
            Assert.Equal(StudentStatus.Reprovado, r.Status);
        }

        [Fact]
        public void NotaInvalida_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => _calc.CalculateFinal(5.0, 11.0));
        }
    }

    // Testes de arredondamento AwayFromZero
    public class ArredondamentoTests
    {
        private readonly GradeCalculator _calc = new();

        [Theory]
        [InlineData(6.9,  6.9,  6.9,  6.9)]
        [InlineData(6.5,  7.5,  6.0,  6.8)]
        [InlineData(7.0,  7.0,  6.25, 6.9)]
        public void Semestral_ArredondamentoAwayFromZero(
            double np1, double np2, double pim, double esperado)
        {
            var r = _calc.CalculateSemestral(np1, np2, pim);
            Assert.Equal(esperado, r.MediaSemestral);
        }

        [Fact]
        public void Final_ArredondamentoAwayFromZero()
        {
            var r = _calc.CalculateFinal(6.0, 5.0);
            Assert.Equal(5.5, r.MediaFinal);
        }
    }

    // Testes de sanitização
    public class SanitizacaoTests
    {
        private readonly GradeCalculator _calc = new();

        [Theory]
        [InlineData("7,5",   "7,5")]
        [InlineData("7.5",   "75")]
        [InlineData("abc7",  "7")]
        [InlineData("10,0!", "10,0")]
        public void RemoveCaracteresInvalidos(string entrada, string esperado)
            => Assert.Equal(esperado, _calc.SanitizeInput(entrada));
    }
}
