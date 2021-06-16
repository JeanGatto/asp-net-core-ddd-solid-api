using GraphQL.Query.Builder;
using System.Collections.Generic;

namespace SGP.SharedTests.GraphQL
{
    public class GraphQLRequest : Dictionary<string, object>
    {
        private const string OperationNameKey = "operationName";
        private const string QueryKey = "query";
        private const string VariablesKey = "variables";

        public GraphQLRequest(IQuery query) => Query = "{" + query.Build() + "}";

        public GraphQLRequest()
        {
        }

        public string OperationName
        {
            get => TryGetValue(OperationNameKey, out object value) ? (string)value : null;
            set => this[OperationNameKey] = value;
        }

        public string Query
        {
            get => TryGetValue(QueryKey, out object value) ? (string)value : null;
            set => this[QueryKey] = value;
        }

        public object Variables
        {
            get => TryGetValue(VariablesKey, out object value) ? value : null;
            set => this[VariablesKey] = value;
        }
    }
}
