using AtolOnline.V5.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AtolOnline.V5.Client;

public abstract class AtolRequest
{
    public AtolRequest(DateTime timestamp, string externalId, Service? service = null)
    {
        Timestamp = timestamp;
        ExternalId = externalId;
        Service = service;
    }

    /// <summary>
    /// Дата и время документа внешней системы в формате: «dd.mm.yyyy HH:MM:SS»
    /// </summary>
    [Required]
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; }


    /// <summary>
    /// Идентификатор документа внешней системы.
    /// </summary>
    [Required]
    [StringLength(maximumLength: 128)]
    [JsonProperty("external_id")]
    public string ExternalId { get; }
    
    
    /// <summary>
    /// Идентификатор документа внешней системы.
    /// </summary>
    [JsonProperty("service")]
    public Service? Service { get; set; }
}
