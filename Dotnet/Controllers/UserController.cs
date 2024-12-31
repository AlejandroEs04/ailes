using Dotnet.Data;
using Dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Dotnet.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class UserController(IConfiguration config) : ControllerBase
{
    private readonly DataContextDapper _dapper = new(config);

    [HttpGet("")]
    public IEnumerable<User> GetUsers()
    {
        string query = @"
            SELECT
                U.id,
                U.name + ' ' + U.lastName AS fullName, 
                U.phoneNumber, 
                U.email, 
                U.birthdate, 
                R.name AS Rol, 
                U.rolId, 
                U.company,
                U.street, 
                U.extNumber, 
                U.intNumber, 
                U.neighborhood, 
                U.[state], 
                U.city, 
                U.country
            FROM [User] AS U
            LEFT JOIN [Rol] AS R ON R.id = U.rolId";

        IEnumerable<User> users = _dapper.Query<User>(query);
        return users;
    }

    [HttpPost("")]
    public IActionResult CreateUser(UserCreateDto newUser)
    {
        try
        {
            string queryExistsEmail = "SELECT email, phoneNumber FROM [User] WHERE email = @Email OR phoneNumber = @PhoneNumber";
            var user = _dapper.QuerySingle<User>(queryExistsEmail, new { newUser.Email, newUser.PhoneNumber });

            if(user != null) 
            {
                Console.WriteLine("Existe usuario");
            }

            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return Ok();
    } 
}