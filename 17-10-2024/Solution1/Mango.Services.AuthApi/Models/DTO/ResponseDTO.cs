﻿using Microsoft.Identity.Client;

namespace Mango.Services.AuthApi.Models.DTO
{
    public class ResponseDTO
    {
        public object? Result { get; set; }
        public bool? IsSuccess { get; set; }
        public string Message { get; set; }
        
    }
}
