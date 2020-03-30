using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Services.Constants
{
    public static class GlobalErrors
    {
        public static readonly int NotFound = 101;
        public static readonly int MaximumRequestLimit = 102;
        public static readonly int InvalidRequest = 103;
        public static readonly int NotAuthentication = 104;
        public static readonly int NotAuthorization = 105;
        public static readonly int NotDeleted = 106;
        public static readonly int Passive = 107;
        public static readonly int NotValidation = 108;
        public static readonly int NotCompleted = 109;
        public static readonly int UnknownError = 110;
        public static readonly int NotSend = 111;
        public static readonly int UnsupportedContentType = 112;
        public static readonly int FileNotUploaded = 113;
        public static readonly int EmailIsNotVerified = 114;
    }
}
