namespace SchoolProject.Data.AppMeatData
{
    public static class Routing
    {
        private const string singleRoute = "{id}";
        private const string root = "Api";
        private const string versionOne = "v1";

        public const string rootVersionOne = root + "/" + versionOne;

        public static class StudentRouting
        {
            private const string prefix = "Student";
            private const string studentVersionOneRoute = rootVersionOne + "/" + prefix + "/";

            public const string GetAll = studentVersionOneRoute + "GetAllStudents";
            public const string GetById = studentVersionOneRoute + singleRoute;
            public const string Create = studentVersionOneRoute + "Create";
            public const string Update = studentVersionOneRoute + "Update/" + singleRoute;
            public const string Delete = studentVersionOneRoute + "Delete/" + singleRoute;
            public const string GetPaginated = studentVersionOneRoute + "Paginated";
        }

        public static class DepartmentRouting
        {
            private const string prefix = "Department";
            private const string departmentVersionOneRoute = rootVersionOne + "/" + prefix + "/";
            public const string GetById = departmentVersionOneRoute + "Id";
        }

        public static class UserRouting
        {
            private const string Prefix = "Account";
            private const string AccountVersionOneRoute = rootVersionOne + "/" + Prefix + "/";
            public const string Register = AccountVersionOneRoute + "Register";
            public const string ResetPassword = AccountVersionOneRoute + "ResetPassword";
            public const string GetById = AccountVersionOneRoute + $"User/{singleRoute}";
            public const string GetAll = AccountVersionOneRoute + "Users";
            public const string Update = AccountVersionOneRoute + "Update/" + singleRoute;
            public const string Delete = AccountVersionOneRoute + "Delete/" + singleRoute;
            public const string ChangePassword = AccountVersionOneRoute + "ChangePassword/" + singleRoute;
            public const string ConfirmEmail = "/Api/User/ConfirmEmail";
        }

        public static class LoginRouting
        {
            private const string Prefix = "Login";
            private const string LoginVersionOneRoute = rootVersionOne + "/" + Prefix + "/";
            public const string Login = LoginVersionOneRoute + "Login";
            public const string RefreshToken = LoginVersionOneRoute + "RefreshToken";
            public const string CheckUserTokenValidity = LoginVersionOneRoute + "CheckUserTokenValidity";
        }

        public static class AuthorizationRouting
        {
            private const string role = "Authorization/Role";
            private const string claim = "Authorization/Claim";
            private const string AuthorizationRoleVersionOneRoute = rootVersionOne + "/" + role + "/";
            private const string AuthorizationClaimVersionOneRoute = rootVersionOne + "/" + claim + "/";
            public const string CreateRole = AuthorizationRoleVersionOneRoute + "CreateRole";
            public const string UpdateRole = AuthorizationRoleVersionOneRoute + "UpdateRole" + singleRoute;
            public const string DeleteRole = AuthorizationRoleVersionOneRoute + "DeleteRole" + singleRoute;
            public const string GetRole = AuthorizationRoleVersionOneRoute + "GetRoleById" + "/" + singleRoute;
            public const string GetRoles = AuthorizationRoleVersionOneRoute + "GetRoles";
            public const string GetUserWithRolesChecker = AuthorizationRoleVersionOneRoute + "GetUserWithRolesChecker" + "/" + singleRoute;
            public const string UpdateUserRoles = AuthorizationRoleVersionOneRoute + "UpdateUserRoles" + "/" + singleRoute;
            public const string ManageUserClaims = AuthorizationClaimVersionOneRoute + "GetClaimsChecked/" + singleRoute;
            public const string UpdateUserClaims = AuthorizationClaimVersionOneRoute + "UpdateUserClaims/" + singleRoute;
        }

        public static class EmailRouting
        {
            private const string Prefix = "Email";
            private const string LoginVersionOneRoute = rootVersionOne + "/" + Prefix + "/";
            public const string SendEmail = LoginVersionOneRoute + "SendEmail";
        }
    }
}
