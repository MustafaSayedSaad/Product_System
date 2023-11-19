namespace Product_System.Services.IServices.Auth;

public interface IAuthService
{
    Task<AuthLoginUserVM> LoginUserAsync(AuthLoginUserVM model);
    //Task<Response<string>> LogOutUserAsync();
    //Task<Response<AuthUpdateUserRequest>> UpdateUserAsync(string id, AuthUpdateUserRequest model);
    //Task<Response<string>> ShowPasswordToSpecificUserAsync(string id);
    //Task<Response<AuthChangePassOfUserResponse>> ChangePasswordAsync(AuthChangePassOfUserRequest model);
    //Task<Response<AuthSetNewPasswordRequest>> SetNewPasswordToSpecificUserAsync(AuthSetNewPasswordRequest model);
    //Task<Response<string>> SetNewPasswordToSuperAdminAsync(string newPassword);
}
