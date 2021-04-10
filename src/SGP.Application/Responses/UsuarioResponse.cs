﻿using SGP.Application.Responses.Common;
using System;

namespace SGP.Application.Responses
{
    public class UsuarioResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}