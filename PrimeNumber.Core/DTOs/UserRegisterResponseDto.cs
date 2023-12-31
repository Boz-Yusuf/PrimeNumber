﻿namespace PrimeNumber.Core.DTOs
{
    public class UserRegisterResponseDto
    {
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public List<string>? Errors { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
