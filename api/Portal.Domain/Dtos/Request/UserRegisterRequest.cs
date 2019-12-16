using System;

namespace Portal.Domain.Dtos.Request {
    public class UserRegisterRequest {

        /// <summary>
        /// email
        /// </summary>
        /// <value></value>
        public string Email { get; set; }

        /// <summary>
        /// primeiro nome
        /// </summary>
        /// <value></value>
        public string FirstName { get; set; }

        /// <summary>
        /// segundo nome
        /// </summary>
        /// <value></value>
        public string LastName { get; set; }

        /// <summary>
        /// senha
        /// </summary>
        /// <value></value>
        public string Password { get; set; }

        /// <summary>
        /// confirmação da senha
        /// </summary>
        /// <value></value>
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Data de nascimento
        /// </summary>
        /// <value></value>
        public DateTime BirthDate { get; set; }

    }
}