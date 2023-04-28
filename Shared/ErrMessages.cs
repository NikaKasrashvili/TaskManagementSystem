namespace Shared;

/// <summary>
/// Struct of custom error messages.
/// </summary>
public ref struct ErrMessages
{
    #region general
    public const string Empty = "required";
    public const string Exists = "already_exists";
    public const string NotFound = "Not_found";
    public const string InvalidId = "Invalid_ID";
    public const string IdEmpty = "Invalid_ID";
    public const string InvalidPassword = "Invalid_Password";
    public const string BadRequest = "Bad_request";
    public const string FileEmpty = "File_Empty";
    #endregion

    #region user
    public const string UserIdEmpty = "User Id is required";
    public const string EmailEmpty = "Email is required";
    public const string UsernameEmpty = "Username is required";
    public const string FirstNameEmpty = "First name is required";
    public const string LastNameNameEmpty = "Last name is required";
    public const string PasswordEmpty = "Password is required";
    public const string PasswordMinChar = "password must be min 6 char long";
    public const string PhoneNumberEmpty = "Phone number is required";
    public const string PhoneNumberMaxChar = "phone_numnber_max_48_char_length";
    public const string FirstNameMaxChar = "First_Name_max_48_char_length";
    public const string LastNameMaxChar = "Last_Name_max_48_char_length";
    public const string InvalidUserId = "Invalid_user_id";

    #endregion

    #region task
    public const string TitleMaxLength = "title_max_length_248_characters";
    public const string SmallDescrMaxLength = "title_max_length_248_characters";

    #endregion

    #region Role
    public const string RoleNameEmpty = "Role name is required";
    public const string RoleIdEmpty = "Role id is required";
    public const string InvalidRoleId = "Invalid_role_id";
    public const string ClaimEmpty = "Claim is empty";
    public const string ClaimInvalidPattern = "Claim invalid pattern";
    #endregion
}

