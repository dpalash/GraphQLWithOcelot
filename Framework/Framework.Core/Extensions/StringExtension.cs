using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using CSharpFunctionalExtensions;
using Framework.Core.Settings.Json;
using Framework.Core.Utility;
using Newtonsoft.Json;

namespace Framework.Core.Extensions
{
    public static class StringExtension
    {
        public static bool IsNullOrWhiteSpace(this string data)
        {
            return string.IsNullOrWhiteSpace(data) || (!string.IsNullOrWhiteSpace(data) && data.ToLower() == "null");
        }

        public static byte[] GetBytes(this string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }

        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static Result<string> SerializeToXml<T>(this T value)
        {
            var result = string.Empty;

            return TryCatchExtension.ExecuteAndHandleError(
                () =>
                {
                    if (value == null)
                    {
                        return Result.Failure<string>("Object is empty!");
                    }

                    var xmlSerializer = new XmlSerializer(typeof(T));
                    var stringWriter = new StringWriter();
                    using var writer = XmlWriter.Create(stringWriter);
                    xmlSerializer.Serialize(writer, value);
                    return Result.Success(stringWriter.ToString());
                },
                exception => new TryCatchExtensionResult<Result<string>>
                {
                    DefaultResult = string.Empty,
                    RethrowException = false
                });
        }

        public static Result<string> SerializeToJson<T>(this T value)
        {
            return TryCatchExtension.ExecuteAndHandleError(
                () =>
                {
                    if (value == null)
                    {
                        return Result.Failure<string>("Object is empty!");
                    }

                    return Result.Success(JsonConvert.SerializeObject(value, JsonSerializerSettingsHelper.GetJsonSerializerSettings()));
                },
                exception => new TryCatchExtensionResult<Result<string>>
                {
                    DefaultResult = string.Empty,
                    RethrowException = false
                });
        }

        public static T DeserializeObject<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value, JsonSerializerSettingsHelper.GetJsonSerializerSettings());
        }

        public static string TrimEnd(this string source, string value)
        {
            if (!source.EndsWith(value))
                return source;

            return source.Remove(source.LastIndexOf(value, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
