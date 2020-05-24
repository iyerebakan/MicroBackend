using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Auth.Application.Constants
{
    public static class UserAPI
    {
        public static readonly string GETUSERROLES = "http://localhost:5000/api/user-service/user/getUserRoles";
        public static readonly string USEREXISTS = "http://localhost:5000/api/user-service/user/userExists";
        public static readonly string EMAILCONFIRMED = "http://localhost:5000/api/user-service/user/isEmailConfirmed";
        public static readonly string CHECKPASSWORD = "http://localhost:5000/api/user-service/user/checkPassword";
        public static readonly string CREATEUSER = "http://localhost:5000/api/user-service/user/createUser";
        public static readonly string LOGINPROVIDER = "http://localhost:5000/api/user-service/user/loginProvider";

    }
}
