namespace Portal.Domain.Dtos.Request
{
    public class UserLoginRequest
    {
        /// <summary>
        /// Email
        /// </summary>
        /// <value></value>
        public string Email { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        /// <value></value>
        public string Password { get; set; }

    }
}