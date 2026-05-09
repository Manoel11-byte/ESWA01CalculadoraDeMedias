using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace OOPFoundation
{
    public abstract class AText : ISanitization, ITextValidation
    {
        private string _text;
        private string _validPattern;

        protected AText()
        {
            _text = string.Empty;
            _validPattern = string.Empty;
        }

        protected AText(string validPattern)
        {
            _text = string.Empty;
            _validPattern = validPattern;
        }

        public string GetText() => _text;

        protected void SetText(string text) => _text = text;

        protected void SetValidPattern(string pattern) => _validPattern = pattern;

        public string Sanitize(string textToSanitize)
        {
            if (string.IsNullOrEmpty(_validPattern))
                return textToSanitize;

            return Regex.Replace(textToSanitize, $"[^{_validPattern}]", string.Empty);
        }

        public bool TextIsValid(string textToValidate)
        {
            if (string.IsNullOrEmpty(_validPattern))
                return !string.IsNullOrEmpty(textToValidate);

            return Regex.IsMatch(textToValidate, $"^[{_validPattern}]+$");
        }

        public string ObtainHashedText() => Hash();

        private string Hash()
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(_text));
            return Encode(bytes);
        }

        private string Encode(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
    }
}
