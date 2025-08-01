using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AdminDashboard.API.Utils;

public static class ControllerUtils
{
    public static IDictionary<string, IEnumerable<string>> DefineIdentityErrors (this IEnumerable<IdentityError> errors)
    {
        var resultErrors = new Dictionary<string, IEnumerable<string>>();

        foreach (var error in errors)
        {
            var code = error.Code.ToLower();

            if (code.Contains("email"))
                AddError(resultErrors, "email", error.Description);
            else if (code.Contains("username"))
                AddError(resultErrors, "username", error.Description);
            else if (code.Contains("password"))
                AddError(resultErrors, "password", error.Description);
            else if (code.Contains("passcode"))
                AddError(resultErrors, "passcode", error.Description);
            else if (code.Contains("token"))
                AddError(resultErrors, "token", error.Description);
            else if (code.Contains("role"))
                AddError(resultErrors, "role", error.Description);
            else if (code.Contains("recoverycode"))
                AddError(resultErrors, "recoverycode", error.Description);
            else
                AddError(resultErrors, "general", error.Description);
        }

        return resultErrors;
    }

    public static IDictionary<string, IEnumerable<string>> DefineUnauthorizedErrorDictionary ()
    {
        var resultDictionary = new Dictionary<string, IEnumerable<string>>();
        resultDictionary["general"] = new string[] { "Unauthorized." };
        return resultDictionary;
    }

    public static IDictionary<string, IList<string>> DefineModelStateErrorDictionary(this ModelStateDictionary modelState)
    {
        var result = new Dictionary<string, IList<string>>();

        foreach (var modelStateEntry in modelState)
        {
            var key = modelStateEntry.Key.ToLower();
            var errors = modelStateEntry.Value.Errors;

            if (errors != null && errors.Count > 0)
            {
                foreach (var error in errors)
                {
                    var errorMessage = error.ErrorMessage;

                    if (!result.ContainsKey(key))
                        result[key] = new List<string>();

                    result[key].Add(errorMessage);
                }
            }
        }
        return result;
    }

    private static void AddError(Dictionary<string, IEnumerable<string>> errors, string key, string error)
    {
        if (!errors.ContainsKey(key))
            errors[key] = new List<string>();

        errors[key].ToList().Add(error);
    }
}
