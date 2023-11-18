namespace Product_System.Domain.Constants;

public static class SD
{
    public static class GoRootPath
    {
        public const string ProductImagesPath = "/wwwroot/Images/Product/";
    }
    public static class ReadRootPath
    {
        public const string ProductImagesPath = "Images/Product/";
    }

    public static class FileSettings
    {
        public const string RequiredExtensions = ".jpg,.jpeg,.png";
        public const int MaxFileSizeInMB = 1;
        public const int MaxFileSizeInBytes = MaxFileSizeInMB * 1024 * 1024;
    }
    public static class Modules
    {
        public const string Auth = "Auth";
        public const string Sales = "Sales";

    }
    public static class Admin
    {
        public const string Id = "b74ddd14-6340-4840-95c2-db12554843e5basb1";
        public const string RoleId = "fab4fac1-c546-41de-aebc-a14da68957ab1";
        public static string Password = "David1234";
    }

    public static class Shared
    {
        public const string Thiqa = "Thiqa";
        public const string ProductSystemConnection = "ProductSystemConnection";
        public const string JwtSettings = "JwtSettings";
        public const string AccessToken = "access_token";
        public const string CorsPolicy = "CorsPolicy";
        public const string Development = "Development";
        public const string Production = "Production";
        public const string Local = "Local";
        public const string Notify = "/notify";
        public static string[] Cultures = ["en-US", "ar-EG"];
        public const string Resources = "Resources";
    }
    public static class ApiRoutes
    {
        public class ProductCategory
        {
            public const string ListOfProductsCategories = "ListOfProductsCategories";
        }
        public class Product
        {
            public const string ListOfServices = "ListOfServices/{servicesCategoryId}";
            public const string GetAllServices = "GetAllServices";
            public const string GetLastThreeServices = "GetLastThreeServices";
            public const string CreateService = "CreateService";
            public const string UpdateServices = "UpdateServices/{id}";
            public const string GetServicesById = "GetServicesById/{id}";
            public const string DeleteService = "DeleteService/{id}";
            public const string ChangeActiveOrNot = "ChangeActiveOrNotService/{id}";
        }

        public class User
        {
            public const string GetAllUsers = "GetAllUsers";
            public const string AddUser = "AddUser";
            public const string LoginUser = "LoginUser";
            public const string LogOutUser = "LogOutUser";
            public const string LoginUser1 = "LoginUser1";
            public const string ChangeActiveOrNot = "ChangeActiveOrNotUser/{id}";
            public const string UpdateUser = "UpdateUser/{id}";
            public const string ShowPasswordToSpecificUser = "ShowPasswordToSpecificUser/{id}";
            public const string ChangePassword = "ChangePassword";
            public const string DeleteUser = "DeleteUser/{id}";
            public const string SetNewPasswordToSpecificUser = "SetNewPasswordToSpecificUser";
            public const string SetNewPasswordToSuperAdmin = "SetNewPasswordToSuperAdmin/{newPassword}";
        }

        public class Perm
        {
            public const string GetAllRoles = "GetAllRoles";
            public const string CreateRole = "CreateRole";
            public const string UpdateRole = "UpdateRole/{id}";
            public const string DeleteRoleById = "DeleteRoleById/{id}";

            public const string GetEachUserWithHisRoles = "GetEachUserWithHisRoles";
            public const string ManageUserRoles = "ManageUserRoles/{userId}";
            public const string UpdateUserRoles = "UpdateUserRoles";

            public const string GetAllPermissionsByCategoryName = "GetAllPermissionsByCategoryName";
            public const string ManageRolePermissions = "ManageRolePermissions/{roleId}";
            public const string UpdateRolePermissions = "UpdateRolePermissions";
            public const string UpdateRolePermissions1 = "UpdateRolePermissions1";
        }
    }

    public static class Localization
    {
    }


    public class Annotations
    {
        public const string ConfirmationPassword = "Confirmation password";
        public const string DepartmentName = "Department";
        public const string ConfirmationPasswordNotMatch = "Password and confirmation password must match.";
        public const string AttachmentsNotes = "Attachments notes.";

        public const string AttachmentsType = "Attachments type.";
        public const string FieldIsRequired = "The {0} is required";
        public const string BirthDate = "Birth date.";

        public const string NationalID = "National ID";
        public const string FieldIsEqual = "The {0} field length must be equal 14.";
        public const string ProfilePhoto = "Profile photo.";
        public const string Files = "Personal files.";
        public const string CourseMatrial = "Course matrial.";
        public const string CourseMatrialType = "Course matrial type.";
        public const string Password = "Password";
        public const string Code = "Code";
        public const string Company = "Company";
        public const string Job = "Job";
        public const string Gender = "Gender";
        public const string Region = "Region";
        public const string MaritalStatus = "MaritalStatus";
        public const string MilitaryStatus = "MilitaryStatus";

        public const string NameInArabic = "Name in Arabic";
        public const string NameInEnglish = "Name in English";
        public const string PersonalEmail = "Personal Email";
        public const string PhoneNumber = "Phone number";
        public const string HireDate = "Hire date";
        public const string Task = "Task";
        public const string UserName = "User name";
        public const string UserNameOrEmail = "User name or email";
        public const string CourseAsset = "Course asset";
        public const string CourseAssetDescription = "Course asset description";//
        public const string CourseAssetType = "Course asset type";
        public const string CourseAssetTypeDescription = "Course asset type description";

        public const string CourseDate = "Course date";
        public const string CourseType = "Course type";
        public const string CourseDescription = "Course description";

        public const string StartDate = "Start date";
        public const string EndDate = "End date";
        public const string RememberMe = "Remember me?";
    }
}
