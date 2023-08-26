namespace PrimeNumber.Core.DTOs
{
    public class UserRegisterResponse
    {
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
