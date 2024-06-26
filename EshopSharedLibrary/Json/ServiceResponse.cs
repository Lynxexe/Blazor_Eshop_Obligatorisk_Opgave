﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopSharedLibrary.Json
{
    public class ServiceResponse // Ubrugt fra før vi fandt ud af SSR.
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public ServiceResponse(bool success, string? message)
        {
            Success = success;
            Message = message;
        }
        public ServiceResponse() { }
    }
}
