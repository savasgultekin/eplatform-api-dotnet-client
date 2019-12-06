using Newtonsoft.Json;

namespace ePlatform.Api.Core
{
    public class QueryFilter
    {
        [JsonProperty("category")]
        public string Category { get; private set; }

        [JsonProperty("operator")]
        public string Operator { get; private set; }

        [JsonProperty("value")]
        public object Value { get; private set; }

        public QueryFilter()
        {

        }

        public QueryFilter(string category, Operator @operator, object value)
        {
            Category = category;
            Operator = @operator.ToString();
            Value = value;
        }
    }
}
