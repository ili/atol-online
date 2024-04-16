﻿using Newtonsoft.Json;

namespace AtolOnline.Unofficial;

public class OperationResponse : ResponseBase
{
    [JsonConstructor]
    public OperationResponse(string uuid, Error? error, string? status, DateTime timestamp)
        : base(error, status, timestamp)
    {
        Uuid = uuid;
    }

    public string Uuid { get; }
}