using System.Collections.Generic;

namespace Framework.Constants
{
    public static partial class Constants
    {
        public struct HttpRequestHeader
        {
            public struct ApiVersion
            {
                public static string DefaultHeader => "pro-api-version";
                public const string DefaultVersion = "1.0";

                public static Dictionary<string, string> ApiVersion11 => new Dictionary<string, string>
                {
                    {
                        DefaultHeader, "1.1"
                    }
                };
            }
        }
    }
}
