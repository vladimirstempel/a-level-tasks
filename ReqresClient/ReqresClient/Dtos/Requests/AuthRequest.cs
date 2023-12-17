using Newtonsoft.Json;

namespace ReqresClient.Dtos.Requests;

public class AuthRequest
{
    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; }
    [JsonProperty(PropertyName = "password")]
    public string Password { get; set; }
}