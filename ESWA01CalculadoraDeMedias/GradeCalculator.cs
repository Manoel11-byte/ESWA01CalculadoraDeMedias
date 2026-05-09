using System;
using OOPFoundation;

namespace ESWA01CalculadoraDeMedias
{
    public enum StudentStatus
    {
        EmAndamento,
        Aprovado,
        EmExame,
        Reprovado
    }

    public class SemestralResult
    {
        public double MediaSemestral { get; init; }
        public StudentStatus Status { get; init; }
    }

    public class FinalResult
    {
        public double MediaFinal { get; init; }
        public StudentStatus Status { get; init; }
    }

    // MEDIA SEMESTRAL = (4*NP1 + 4*NP2 + 2*PIM) / 10
    // MEDIA FINAL = (MS + EX) / 2
    public class GradeCalculator
    {
        private readonly NoteValidation _noteValidator = new();

        public SemestralResult CalculateSemestral(double np1, double np2, double pim)
        {
            ValidarNota(np1, nameof(np1));
            ValidarNota(np2, nameof(np2));
            ValidarNota(pim, nameof(pim));

            double ms = (4 * np1 + 4 * np2 + 2 * pim) / 10;
            ms = Math.Round(ms, 1, MidpointRounding.AwayFromZero);

            var status = ms >= 7.0 ? StudentStatus.Aprovado : StudentStatus.EmExame;
            return new SemestralResult { MediaSemestral = ms, Status = status };
        }

        public FinalResult CalculateFinal(double mediaSemestral, double exame)
        {
            ValidarNota(mediaSemestral, nameof(mediaSemestral));
            ValidarNota(exame, nameof(exame));

            double mf = (mediaSemestral + exame) / 2.0;
            mf = Math.Round(mf, 1, MidpointRounding.AwayFromZero);

            var status = mf >= 5.0 ? StudentStatus.Aprovado : StudentStatus.Reprovado;
            return new FinalResult { MediaFinal = mf, Status = status };
        }

        public string SanitizeInput(string input)
        {
            var text = new Text(SanitizationPattern.NOTE);
            return text.Sanitize(input);
        }

        public bool TryParseNote(string input, out double result)
        {
            var normalizado = input.Replace(',', '.');
            if (double.TryParse(normalizado,
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out result))
            {
                return _noteValidator.DoubleIsValid(result);
            }
            result = 0.0;
            return false;
        }

        private void ValidarNota(double valor, string param)
        {
            if (!_noteValidator.DoubleIsValid(valor))
                throw new ArgumentOutOfRangeException(param,
                    $"Nota fora do intervalo [0,0 ; 10,0]: {valor}");
        }
    }
}
