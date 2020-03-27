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
        public static readonly int NotAuthentication = 105;
        public static readonly int NotAuthorization = 106;
        public static readonly int NotDeleted = 107;
        public static readonly int Passive = 108;
        public static readonly int NotValidation = 109;
        public static readonly int NotCompleted = 110;
        public static readonly int UnknownError = 111;
        public static readonly int NotSend = 114;
        public static readonly int UnsupportedContentType = 117;
        public static readonly int FileNotUploaded = 118;
    }
}
