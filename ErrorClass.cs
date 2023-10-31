using System.Resources;
using System.Globalization;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

public static class ErrorClass
{
    private static ResourceManager _resourceManager;

    static ErrorClass()
    {
        _resourceManager = new ResourceManager("NetCoreAPI.ErrorMessages", Assembly.GetExecutingAssembly());
    }

    public static List<IdentityError> TranslateErrors(this IdentityResult erroor)
    {
        var errorList = erroor.Errors.ToList();
        var customErrors = new List<IdentityError>();
        foreach (var error in errorList)
        {
            string errorMessage = _resourceManager.GetString(error.Code, CultureInfo.InvariantCulture);
            customErrors.Add(new IdentityError() { Code = error.Code, Description = errorMessage}); 
        }

        return customErrors;
    }
}
