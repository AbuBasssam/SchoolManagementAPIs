namespace DomainLayer.Helper_Classes
{
    public class RefreshToken
    {
        public string Username { get; set; }
        public string Value { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
