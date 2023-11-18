namespace Product_System.Domain.ViewModels;

public class SelectListForExcLog
{
    public string Message { get; set; } = string.Empty;
    public string Error { get; set; } = string.Empty;

    public override string ToString() => 
        JsonConvert.SerializeObject(this);
}

