using HotChocolate.Language;
using HotChocolate.Types;

namespace DNATestingSystem.GraphQLAPIServices.TienDM.GraphQLs
{
    public class TimeOnlyType : ScalarType<TimeOnly, StringValueNode>
    {
        public TimeOnlyType() : base("TimeOnly")
        {
        }

        public override IValueNode ParseResult(object? resultValue)
        {
            return resultValue switch
            {
                TimeOnly timeOnly => new StringValueNode(timeOnly.ToString("HH:mm:ss")),
                string s => new StringValueNode(s),
                null => NullValueNode.Default,
                _ => throw new SerializationException(
                    $"Cannot serialize {resultValue.GetType()} to TimeOnly.",
                    this)
            };
        }

        protected override TimeOnly ParseLiteral(StringValueNode valueSyntax)
        {
            if (TimeOnly.TryParse(valueSyntax.Value, out var timeOnly))
            {
                return timeOnly;
            }

            throw new SerializationException(
                $"Cannot parse '{valueSyntax.Value}' to TimeOnly.",
                this);
        }

        protected override StringValueNode ParseValue(TimeOnly runtimeValue)
        {
            return new StringValueNode(runtimeValue.ToString("HH:mm:ss"));
        }

        public override bool TrySerialize(object? runtimeValue, out object? resultValue)
        {
            switch (runtimeValue)
            {
                case null:
                    resultValue = null;
                    return true;
                case TimeOnly timeOnly:
                    resultValue = timeOnly.ToString("HH:mm:ss");
                    return true;
                case string str when TimeOnly.TryParse(str, out var parsed):
                    resultValue = parsed.ToString("HH:mm:ss");
                    return true;
                default:
                    resultValue = null;
                    return false;
            }
        }

        public override bool TryDeserialize(object? resultValue, out object? runtimeValue)
        {
            switch (resultValue)
            {
                case null:
                    runtimeValue = null;
                    return true;
                case string str when TimeOnly.TryParse(str, out var timeOnly):
                    runtimeValue = timeOnly;
                    return true;
                case TimeOnly timeOnly:
                    runtimeValue = timeOnly;
                    return true;
                default:
                    runtimeValue = null;
                    return false;
            }
        }
    }
}
