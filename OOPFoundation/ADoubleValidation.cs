namespace OOPFoundation
{
    public abstract class ADoubleValidation : IDoubleValidation
    {
        protected double LowerLimit { get; set; }
        protected double UpperLimit { get; set; }

        protected ADoubleValidation(double lowerLimit, double upperLimit)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }

        public bool DoubleIsValid(double doubleToValidate)
        {
            return doubleToValidate >= LowerLimit && doubleToValidate <= UpperLimit;
        }
    }
}
