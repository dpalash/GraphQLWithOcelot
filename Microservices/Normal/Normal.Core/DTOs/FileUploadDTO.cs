using System;
using Newtonsoft.Json;

namespace Normal.Core.DTOs
{
    [Serializable]
    public class FileUploadDTO
    {
        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("fileBytes")]
        public byte[] FileBytes { get; set; }
    }
}
