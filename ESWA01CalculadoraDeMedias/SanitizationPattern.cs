namespace OOPFoundation
{
    public class SanitizationPattern
    {
        public static readonly string CNPJ  = @"a-zA-Z0-9";
        public static readonly string CPF   = @"0-9";
        public static readonly string ISBN  = @"0-9";
        public static readonly string ISSN  = @"0-9Xx";
        public static readonly string PHONE = @"0-9";
        public static readonly string RG    = @"0-9Xx";
        public static readonly string NOTE  = @"0-9,";
    }
}
