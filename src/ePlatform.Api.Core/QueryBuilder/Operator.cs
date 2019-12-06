namespace ePlatform.Api.Core
{
    public class Operator
    {
        public static Operator Equal = new Operator("eşittir");
        public static Operator NotEqual = new Operator("eşit değildir");
        public static Operator LessThan = new Operator("küçüktür");
        public static Operator LessThanOrEqual = new Operator("küçük ve eşittir");
        public static Operator GreaterThan = new Operator("büyüktür");
        public static Operator GreaterThanOrEqual = new Operator("büyük ve eşittir");
        public static Operator Contains = new Operator("içeren");
        public static Operator StartsWith = new Operator("ile başlayan");
        public static Operator DoesNotContains = new Operator("içermeyen");
        public static Operator DoesNotStartsWith = new Operator("ile başlamayan");

        public string Operation { get; private set; }

        private Operator(string operation)
        {
            Operation = operation;
        }

        public override string ToString()
        {
            return Operation;
        }
    }
}
