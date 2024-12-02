namespace SchoolProject.Infrastructure.Resources
{
    public static class SharedResourcesKeys
    {
        public const string NotFound = nameof(NotFound);
        public const string Added = nameof(Added);
        public const string Deleted = nameof(Deleted);
        public const string NotEmpty = nameof(NotEmpty);
        public const string MaxLength = nameof(MaxLength);
        public const string AlreadyExists = nameof(AlreadyExists);
        public const string Name = nameof(Name);
        public const string Address = nameof(Address);
        public const string Phone = nameof(Phone);
        public const string Success = nameof(Success);
        public const string Unauthorized = nameof(Unauthorized);
        public const string Updated = nameof(Updated);
        public const string Unprocessable = nameof(Unprocessable);
        public const string UnAvailableDepartment = nameof(UnAvailableDepartment);
        public const string User = nameof(User);
        public const string MustEqual = nameof(MustEqual);
        public const string Password = nameof(Password);
        public const string ConfirmPassword = nameof(ConfirmPassword);
        public const string NameEn = nameof(NameEn);
        public const string NameAr = nameof(NameAr);
        public const string Email = nameof(Email);
        public const string FullName = nameof(FullName);
        public const string UserNameOrPasswordAreInCorrect = nameof(UserNameOrPasswordAreInCorrect);
        public const string AccessToken = nameof(AccessToken);
        public const string RefreshToken = nameof(RefreshToken);
        public const string UserLoggedIn = nameof(UserLoggedIn);
        public const string SomethingWrongWithTokens = nameof(SomethingWrongWithTokens);
        public const string ThisAccessTokenDoesNotMeetOurSecurityStandards = nameof(ThisAccessTokenDoesNotMeetOurSecurityStandards);
        public const string ThisRefreshTokenDoesNotExist = nameof(ThisRefreshTokenDoesNotExist);
        public const string ThisRefreshTokenWasRevoked = nameof(ThisRefreshTokenWasRevoked);
        public const string TheRefreshTokenIsValid = nameof(TheRefreshTokenIsValid);
        public const string ThereIsNoTokenToRead = nameof(ThereIsNoTokenToRead);
        public const string RoleName = nameof(RoleName);
        public const string ThereIsNoSuchRole = nameof(ThereIsNoSuchRole);
        public const string UsersExistWithThisRole = nameof(UsersExistWithThisRole);
        public const string Id = nameof(Id);

        #region validation properties not in file
        public const string PropertyValue = "{PropertyValue}";
        public const int NameMaxLength = 20;
        public const int userNameMaxLength = 100;
        #endregion
    }
}
