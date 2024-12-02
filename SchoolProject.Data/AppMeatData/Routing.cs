namespace SchoolProject.Data.AppMeatData
{
    public static class Routing
    {
        public const string singleRoute = "{id}";
        public const string root = "Api";
        public const string versionOne = "v1";

        public const string rootVersionOne = root + "/" + versionOne;

        public static class StudentRouting
        {
            public const string prefix = "Student";
            public const string studentVersionOneRoute = rootVersionOne + "/" + prefix + "/";

            public const string GetAll = studentVersionOneRoute + "GetAllStudents";
            public const string GetById = studentVersionOneRoute + singleRoute;
            public const string Create = studentVersionOneRoute + "Create";
            public const string Update = studentVersionOneRoute + "Update/" + singleRoute;
            public const string Delete = studentVersionOneRoute + "Delete/" + singleRoute;
            public const string GetPaginated = studentVersionOneRoute + "Paginated";
        }

        public static class DepartmentRouting
        {
            public const string prefix = "Department";
            public const string departmentVersionOneRoute = rootVersionOne + "/" + prefix + "/";
            public const string GetById = departmentVersionOneRoute + "Id";
        }

        public static class UserRouting
        {
            public const string Prefix = "Account";
            public const string AccountVersionOneRoute = rootVersionOne + "/" + Prefix + "/";
            public const string Register = AccountVersionOneRoute + "Register";
            public const string GetById = AccountVersionOneRoute + $"User/{singleRoute}";
            public const string GetAll = AccountVersionOneRoute + "Users";
            public const string Update = AccountVersionOneRoute + "Update/" + singleRoute;
            public const string Delete = AccountVersionOneRoute + "Delete/" + singleRoute;
            public const string ChangePassword = AccountVersionOneRoute + "ChangePassword/" + singleRoute;
        }

        public static class LoginRouting
        {
            public const string Prefix = "Login";
            public const string LoginVersionOneRoute = rootVersionOne + "/" + Prefix + "/";
            public const string Login = LoginVersionOneRoute + "Login";
            public const string RefreshToken = LoginVersionOneRoute + "RefreshToken";
            public const string CheckUserTokenValidity = LoginVersionOneRoute + "CheckUserTokenValidity";
        }

        public static class AuthorizationRouting
        {
            public const string role = "Authorization/Role";
            public const string claim = "Authorization/Claim";
            public const string AuthorizationRoleVersionOneRoute = rootVersionOne + "/" + role + "/";
            public const string AuthorizationClaimVersionOneRoute = rootVersionOne + "/" + claim + "/";
            public const string CreateRole = AuthorizationRoleVersionOneRoute + "CreateRole";
            public const string UpdateRole = AuthorizationRoleVersionOneRoute + "UpdateRole" + singleRoute;
            public const string DeleteRole = AuthorizationRoleVersionOneRoute + "DeleteRole" + singleRoute;
            public const string GetRole = AuthorizationRoleVersionOneRoute + "GetRoleById" + "/" + singleRoute;
            public const string GetRoles = AuthorizationRoleVersionOneRoute + "GetRoles";
            public const string GetUserWithRolesChecker = AuthorizationRoleVersionOneRoute + "GetUserWithRolesChecker" + "/" + singleRoute;
            public const string UpdateUserRoles = AuthorizationRoleVersionOneRoute + "UpdateUserRoles" + "/" + singleRoute;
            public const string ManageUserClaims = AuthorizationClaimVersionOneRoute + "GetClaimsChecked/" + singleRoute;
        }
    }
}
