using System.Linq;

namespace MY_MVC_APPLICATION.Controllers
{
	public class AccountController : Infrastructure.BaseController
	{
		public AccountController() : base()
		{
		}

		[Microsoft.AspNetCore.Mvc.HttpGet]
		public Microsoft.AspNetCore.Mvc.IActionResult Login(ViewModels.Account.LoginViewModel viewModel)
		{
			// References:
			// https://jwt.io
			// https://www.nuget.org/packages/System.IdentityModel.Tokens.Jwt/

			// Create Jwt Security Token Handler Object
			var jwtSecurityTokenHandler =
				new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

			// **************************************************
			// Symmetric key must be atleast 128 bits long
			string strSymmetricKey = "This is the Symmetric Key";

			var symmetricSecurityKey =
				new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey
				(System.Text.Encoding.ASCII.GetBytes(strSymmetricKey));

			var signingCredentials =
				new Microsoft.IdentityModel.Tokens.SigningCredentials
				(key: symmetricSecurityKey,
				algorithm: Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);
			// **************************************************

			// Creating Token Description part
			var securityTokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
			{
				Subject =
					new System.Security.Claims.ClaimsIdentity(new System.Security.Claims.Claim[]
					{
						new System.Security.Claims.Claim("Username", "[Any Name]"),
						new System.Security.Claims.Claim("RoleName", "[Any Role]"),
						//new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, "[Any Name]"),
						//new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, "[Any Role]"),
					}),

				Issuer = "[Token Issuer Name]",
				Audience = "http://www.IranianExperts.com",

				// define lifetime of the token
				Expires = System.DateTime.Now.AddMinutes(5),

				SigningCredentials = signingCredentials,
			};

			// Create Token
			var securityToken =
				jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

			// convert Token to string
			string strTokenString =
				jwtSecurityTokenHandler.WriteToken(securityToken);

			var result = new
			{
				Token = strTokenString,
			};

			VerifyToken(strTokenString);

			//VerifyToken("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IltBbnkgTmFtZV0iLCJyb2xlIjoiW0FueSBSb2xlXSIsIm5iZiI6MTQ5MzU1MzAxOSwiZXhwIjoxNDkzNTUzMzE2LCJpYXQiOjE0OTM1NTMwMTksImlzcyI6IltUb2tlbiBJc3N1ZXIgTmFtZV0iLCJhdWQiOiJodHRwOi8vd3d3LklyYW5pYW5FeHBlcnRzLmNvbSJ9.zLgzHAUxoCsNLhC-nLkYyMhckD-uNop5JRM_m-PGz5o");
			// **************************************************

			return (Json(data: result,
				serializerSettings: Infrastructure.JsonSerializerSettings.Instance));
		}

		private bool VerifyToken(string token)
		{
			var jwtSecurityTokenHandler =
				new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

			// **************************************************
			// Symmetric key must be atleast 128 bits long
			string strSymmetricKey = "This is the Symmetric Key";

			var symmetricSecurityKey =
				new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey
				(System.Text.Encoding.ASCII.GetBytes(strSymmetricKey));
			// **************************************************

			// validation parameters, JWtValidator requires this object to validate the token.
			var validationParameters =
				new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
				{
					ValidateLifetime = true,
					RequireExpirationTime = true,

					ValidateIssuer = true,
					ValidIssuer = "[Token Issuer Name]",

					ValidateAudience = true,
					ValidAudience = "http://www.IranianExperts.com",

					ValidateIssuerSigningKey = true,
					IssuerSigningKey = symmetricSecurityKey,
				};

			Microsoft.IdentityModel.Tokens.SecurityToken validatedSecurityToken = null;
			System.IdentityModel.Tokens.Jwt.JwtSecurityToken validatedJwtSecurityToken = null;

			try
			{
				// If token is valid, it will output the validated token
				// that contains the JWT information otherwise it will throw an exception
				var principal =
					jwtSecurityTokenHandler.ValidateToken
					(token: token, validationParameters: validationParameters, validatedToken: out validatedSecurityToken);

				validatedJwtSecurityToken =
					validatedSecurityToken as System.IdentityModel.Tokens.Jwt.JwtSecurityToken;

				if (validatedJwtSecurityToken == null)
				{
					return (false);
				}

				string strType = "Username";

				var varName =
					validatedJwtSecurityToken.Claims
					.Where(current => string.Compare(current.Type, strType, true) == 0)
					.FirstOrDefault();

				string X = varName.Value;
			}
			catch (System.Exception ex)
			{
				return (false);
			}

			return (true);
		}
	}
}
