using FEBookStoreManagement.DTO;

namespace FEBookStoreManagement.Models.ResponseModels;

public class LoginResponse
{
    public LoginResponse(Login login)
    {
        Login = login;
    }

    public Login Login { get; set; }
}

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Login
{
    public Login(string token, UserDto userDto)
    {
        Token = token;
        UserDto = userDto;
    }

    public string Token { get; set; }
    public UserDto UserDto { get; set; }
}