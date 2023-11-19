namespace Product_System.Domain.ViewModels.Auth;

public class AuthLoginUserVM
{
    [Required]
    public string UserNameOrEmail { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; } = string.Empty;


}
