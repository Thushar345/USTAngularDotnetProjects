namespace WebApiTest2
{
    public class JwtSettings
    {
        public string SecretCode { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryMinutes { get; set; }
    }
}
