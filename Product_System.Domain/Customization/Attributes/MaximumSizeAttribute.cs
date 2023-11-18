﻿namespace Product_System.Domain.Customization.Attributes;

public class MaximumSizeAttribute(int maxFileSize) : ValidationAttribute
{
    private readonly int _maxFileSize = maxFileSize;

    protected override ValidationResult? IsValid
        (object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;

        if (file is not null)
            if (file.Length > _maxFileSize)
                return new ValidationResult($"Maximum allowed size is {_maxFileSize} bytes");

        return ValidationResult.Success;
    }
}