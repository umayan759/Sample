using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Common.Model
{
    /// <summary>
    /// データモデル
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DataModel
    {
        /// <summary>
        /// データ
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; } = string.Empty;
    }
}
