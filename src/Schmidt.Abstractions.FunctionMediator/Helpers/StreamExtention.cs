using System;
using System.Collections.Generic;
using System.Text;

namespace Schmidt.Abstractions.FunctionMediator.Helpers
{
    internal static class ReadStream<T>
    {
        public static T ReadRawStream(System.IO.Stream contentStream, string contentType)
        {
            try
            {

                T returnObject;
                using (System.IO.MemoryStream streamWrite = new System.IO.MemoryStream())
                {
                    contentStream.CopyTo(streamWrite);
                    if (streamWrite.Length <= 0)
                        throw new Exception($"Request body is 0 bytes. Expected {typeof(T).FullName}");

                    streamWrite.Seek(0, System.IO.SeekOrigin.Begin);

                    if (contentType.Contains("application/json"))
                    {
                        var bytes = streamWrite.ToArray();
                        string s = Encoding.UTF8.GetString(bytes);
                        returnObject = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(s);
                    }
                    else if (contentType.Contains("application/bson"))
                    {
                        using (Newtonsoft.Json.Bson.BsonDataReader breader = new Newtonsoft.Json.Bson.BsonDataReader(streamWrite))
                        {
                            Newtonsoft.Json.JsonSerializer jsonSerializer = new Newtonsoft.Json.JsonSerializer();
                            returnObject = jsonSerializer.Deserialize<T>(breader);
                        }
                    }
                    else if (contentType.Contains("text/plain"))
                    {
                        var bytes = streamWrite.ToArray();
                        string s = Encoding.UTF8.GetString(bytes);
                        returnObject = (T)Convert.ChangeType(s, typeof(T));
                    }
                    else
                    {
                        throw new Exception($"Unsupported content type {contentType}");
                    }
                }

                var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                bool res = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(
                    returnObject,
                    new System.ComponentModel.DataAnnotations.ValidationContext(returnObject),
                    validationResults,
                    validateAllProperties: true);

                if (!res)
                {
                    throw new Exception();
                }

                return returnObject;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    return default(T);
                }

                return default(T);
            }
        }
    }
}