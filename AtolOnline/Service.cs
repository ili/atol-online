﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AtolOnline.Unofficial;

public class Service
{
    /// <summary>
    /// URL, на который необходимо ответить после обработки документа.
    /// </summary>
    [StringLength(maximumLength: 256)]
    [JsonProperty("callback_url")]
    public string? CallbackUrl { get; set; }
}