namespace Login.API.Helpers
{
    public static class TokenHelper
    {
        public static string GenerateToken(ApplicationUser user, AppSettings appSettings)
        {
            string secretKey = appSettings.Secret;

            // Create a security key based on the secret key
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));

            // Define the signing credentials using the security key and algorithm
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Define the claims for the token (you can customize this as needed)
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!)
            };

            // Define token descriptor with claims, expiration time, and signing credentials
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(30), // Token expiration time (e.g., 1 hour from now)
                SigningCredentials = credentials
            };

            // Create a token handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // Generate the JWT token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Convert token to a string
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
