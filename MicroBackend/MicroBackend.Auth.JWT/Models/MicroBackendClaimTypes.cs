using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MicroBackend.Auth.JWT.Models
{
    public static class MicroBackendClaimTypes
    {
        /// <summary>
        /// Default: <see cref="ClaimTypes.Name"/>
        /// </summary>
        public static string UserName { get; set; } ="name";

        /// <summary>
        /// Default: <see cref="ClaimTypes.NameIdentifier"/>
        /// </summary>
        public static string UserId { get; set; } = "nameIdentifier";

        /// <summary>
        /// Default: <see cref="ClaimTypes.Role"/>
        /// </summary>
        public static string Role { get; set; } = "role";

        /// <summary>
        /// Default: <see cref="ClaimTypes.Email"/>
        /// </summary>
        public static string Email { get; set; } = "email";

        /// <summary>
        /// Default: "email_verified".
        /// </summary>
        public static string EmailVerified { get; set; } = "email_verified";

        /// <summary>
        /// Default: "phone_number".
        /// </summary>
        public static string PhoneNumber { get; set; } = "phone_number";

        /// <summary>
        /// Default: "phone_number_verified".
        /// </summary>
        public static string PhoneNumberVerified { get; set; } = "phone_number_verified";
    }
   
}
