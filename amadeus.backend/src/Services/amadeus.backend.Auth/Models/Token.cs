namespace Login.API.Models
{
    public class Token
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId {  get; set; } = string.Empty;
        public DateTime TmStmp { get; set; }
        public string BodyToken {  get; set; } = string.Empty;
        public DateTime ExpirationTime { get; set; }
    }
}
