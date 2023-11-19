namespace Product_System.Services.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ILogger<AuthService> _logger;
    private readonly IHttpContextAccessor _accessor;

    public AuthService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager, ILogger<AuthService> logger,
                       IHttpContextAccessor accessor, SignInManager<ApplicationUser> signInManager,
                       RoleManager<ApplicationRole> roleManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
        _logger = logger;
        _accessor = accessor;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    //#region Authentication

    public async Task<AuthLoginUserVM> LoginUserAsync(AuthLoginUserVM model)
    {

        var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(x => x.UserName == model.UserNameOrEmail || x.Email == model.UserNameOrEmail);

        if (user is null)
            return null!;

        var test = await _signInManager.PasswordSignInAsync(user.UserName!, model.Password, true, false);
        if (!test.Succeeded)
            return null!;

        return model;
    }

    //public async Task<Response<AuthUpdateUserRequest>> UpdateUserAsync(string id, AuthUpdateUserRequest model)
    //{
    //    if (id == null || model.Id != id)
    //    {
    //        string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
    //            _sharLocalizer[Localization.User], id);

    //        return new Response<AuthUpdateUserRequest>()
    //        {
    //            Data = model,
    //            Error = resultMsg,
    //            Message = resultMsg
    //        };
    //    }
    //    string err = _sharLocalizer[Localization.Error];

    //    var obj = _mapper.Map<AuthUpdateUserRequest, ApplicationUser>(model, (await _userManager.FindByIdAsync(id))!);
    //    obj.UpdateDate = new DateTime().NowEg();
    //    obj.UpdateBy = _accessor!.HttpContext == null ? string.Empty : _accessor!.HttpContext!.User.GetUserId();

    //    bool isSucceeded = (await _userManager.UpdateAsync(obj)).Succeeded;

    //    return new Response<AuthUpdateUserRequest>()
    //    {
    //        IsSuccess = isSucceeded,
    //        Data = model,
    //        Message = isSucceeded ? _sharLocalizer[Localization.Updated] : _sharLocalizer[err]
    //    };
    //}

    //public async Task<Response<string>> ShowPasswordToSpecificUserAsync(string id)
    //{
    //    var user = await _userManager.FindByIdAsync(id);

    //    if (user is null)
    //    {
    //        string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
    //            _sharLocalizer[Localization.User], id);

    //        return new Response<string>()
    //        {
    //            Data = id,
    //            Error = resultMsg,
    //            Message = resultMsg
    //        };
    //    }

    //    string err = _sharLocalizer[Localization.Error];

    //    return new Response<string>()
    //    {
    //        IsSuccess = true,
    //        Data = user.VisiblePassword
    //    };
    //}

    //public async Task<Response<AuthChangePassOfUserResponse>> ChangePasswordAsync(AuthChangePassOfUserRequest model)
    //{
    //    string err = _sharLocalizer[Localization.Error];

    //    var mappedResponse = _mapper.Map<AuthChangePassOfUserResponse>(model);

    //    if (model.CurrentPassword == model.NewPassword)
    //    {
    //        string resultMsg = _sharLocalizer[Localization.CurrentAndNewPasswordIsTheSame];

    //        return new Response<AuthChangePassOfUserResponse>()
    //        {
    //            Data = mappedResponse,
    //            Error = resultMsg,
    //            Message = resultMsg
    //        };
    //    }

    //    string userId = _accessor!.HttpContext == null ? string.Empty : _accessor!.HttpContext!.User.GetUserId();
    //    var user = await _userManager.FindByIdAsync(userId);

    //    if (user is null)
    //    {
    //        string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
    //            _sharLocalizer[Localization.User], userId);

    //        return new Response<AuthChangePassOfUserResponse>()
    //        {
    //            Data = mappedResponse,
    //            Error = resultMsg,
    //            Message = resultMsg
    //        };
    //    }

    //    var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

    //    if (!result.Succeeded)
    //    {
    //        string resultMsg = _sharLocalizer[Localization.CurrentPasswordIsIncorrect];

    //        return new Response<AuthChangePassOfUserResponse>()
    //        {
    //            Data = mappedResponse,
    //            Error = resultMsg,
    //            Message = resultMsg
    //        };
    //    }

    //    if (!user.IsActive)
    //    {
    //        string resultMsg = string.Format(_sharLocalizer[Localization.NotActive],
    //            _sharLocalizer[Localization.User], user.UserName);

    //        return new Response<AuthChangePassOfUserResponse>()
    //        {
    //            Data = mappedResponse,
    //            Error = resultMsg,
    //            Message = resultMsg
    //        };
    //    }

    //    return new Response<AuthChangePassOfUserResponse>()
    //    {
    //        Message = string.Format(_sharLocalizer[Localization.Updated]),
    //        IsSuccess = true,
    //        Data = mappedResponse
    //    };
    //}

    //public async Task<Response<AuthSetNewPasswordRequest>> SetNewPasswordToSpecificUserAsync(AuthSetNewPasswordRequest model)
    //{
    //    string err = _sharLocalizer[Localization.Error];

    //    using var transaction = _unitOfWork.BeginTransaction();

    //    var user = await _userManager.FindByIdAsync(model.UserId);

    //    if (user is null)
    //    {
    //        string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
    //            _sharLocalizer[Localization.User], model.UserId);

    //        return new Response<AuthSetNewPasswordRequest>()
    //        {
    //            Data = model,
    //            Error = resultMsg,
    //            Message = resultMsg
    //        };
    //    }

    //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
    //    var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

    //    user.VisiblePassword = model.NewPassword;
    //    _unitOfWork.Users.Update(user);
    //    await _unitOfWork.CompleteAsync();

    //    if (!result.Succeeded)
    //    {
    //        string resultMsg = _sharLocalizer[Localization.CurrentPasswordIsIncorrect];

    //        return new Response<AuthSetNewPasswordRequest>()
    //        {
    //            Data = model,
    //            Error = resultMsg,
    //            Message = resultMsg
    //        };
    //    }
    //    transaction.Commit();
    //    return new Response<AuthSetNewPasswordRequest>()
    //    {
    //        Message = string.Format(_sharLocalizer[Localization.Updated]),
    //        IsSuccess = true,
    //        Data = model
    //    };
    //}

    //public async Task<Response<string>> SetNewPasswordToSuperAdminAsync(string newPassword)
    //{
    //    string err = _sharLocalizer[Localization.Error];

    //    using var transaction = _unitOfWork.BeginTransaction();

    //    var user = await _userManager.FindByIdAsync(SuperAdmin.Id);

    //    if (user is null)
    //    {
    //        string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
    //            _sharLocalizer[Localization.User], SuperAdmin.Id);

    //        return new Response<string>()
    //        {
    //            Data = newPassword,
    //            Error = resultMsg,
    //            Message = resultMsg
    //        };
    //    }


    //    var result = await _userManager.ChangePasswordAsync(user, SuperAdmin.Password, newPassword);


    //    //var token = await _userManager.GeneratePasswordResetTokenAsync(user);
    //    //var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

    //    user.VisiblePassword = SuperAdmin.Password = newPassword;

    //    _unitOfWork.Users.Update(user);
    //    await _unitOfWork.CompleteAsync();

    //    if (!result.Succeeded)
    //    {
    //        string resultMsg = _sharLocalizer[Localization.CurrentPasswordIsIncorrect];

    //        return new Response<string>()
    //        {
    //            Data = newPassword,
    //            Error = resultMsg,
    //            Message = resultMsg
    //        };
    //    }
    //    transaction.Commit();
    //    return new Response<string>()
    //    {
    //        Message = string.Format(_sharLocalizer[Localization.Updated]),
    //        IsSuccess = true,
    //        Data = newPassword
    //    };

    //}

    //public async Task<Response<string>> LogOutUserAsync()
    //{
    //    string userId = GetUserId();
    //    var lsitOfObjects = await _unitOfWork.UserDevices.GetAllAsync(x => x.UserId == userId);

    //    if (!lsitOfObjects.Any())
    //    {
    //        string resultMsg = string.Format(_sharLocalizer[Localization.CannotBeFound],
    //            _sharLocalizer[Localization.User], userId);

    //        return new Response<string>()
    //        {
    //            Data = string.Empty,
    //            Error = resultMsg,
    //            Message = resultMsg
    //        };
    //    }
    //    string err = _sharLocalizer[Localization.Error];
    //    try
    //    {
    //        _unitOfWork.UserDevices.RemoveRange(lsitOfObjects);

    //        bool result = await _unitOfWork.CompleteAsync() > 0;

    //        if (!result)
    //            return new Response<string>()
    //            {
    //                IsSuccess = false,
    //                Data = userId,
    //                Error = err,
    //                Message = err
    //            };
    //        return new Response<string>()
    //        {
    //            IsSuccess = true,
    //            Data = userId,
    //            Message = _sharLocalizer[Localization.Deleted]
    //        };
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, err);

    //        return new Response<string>()
    //        {
    //            Error = err,
    //            Message = ex.Message + (ex.InnerException == null ? string.Empty : ex.InnerException.Message)
    //        };
    //    }
    //}

    //private string GetUserId() =>
    //    _accessor!.HttpContext == null ? string.Empty : _accessor!.HttpContext!.User.GetUserId();
    //private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
    //{
    //    var roleClaims = new List<Claim>();

    //    var roles = (await _userManager.GetRolesAsync(user)).ToList();

    //    foreach (var role in roles)
    //    {
    //        var dd = await _roleManager.FindByNameAsync(role);

    //        var ddd = _roleManager.GetClaimsAsync(dd!).Result;
    //        roleClaims.AddRange(ddd);
    //    }
    //    for (int i = 0; i < roles.Count; i++)
    //        roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));

    //    var claims = new[]
    //    {
    //        new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
    //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    //        new Claim(RolesClaims.UserId, user.Id)
    //    }
    //    .Union(roleClaims);
    //    //.Union(await _userManager.GetClaimsAsync(user));

    //    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey));
    //    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

    //    return new JwtSecurityToken(
    //        issuer: _jwt.Issuer,
    //        claims: claims,
    //        expires: DateTime.UtcNow.AddHours(2).Add(_jwt.TokenLifetime),
    //        signingCredentials: signingCredentials);
    //}

    //#endregion
}
