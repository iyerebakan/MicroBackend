﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Utilities.Security.Token
{
    public class TokenInfo
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}
