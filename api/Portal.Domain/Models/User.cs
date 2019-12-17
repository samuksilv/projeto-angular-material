using System;
using Portal.Domain.Dtos.Request;

namespace Portal.Domain.Models
{
    public class User: BaseModel
    {
        /// <summary>
        /// Primeiro Nome
        /// </summary>
        /// <value></value>
        public string FirstName { get; set; }

        /// <summary>
        /// Ultimo nome
        /// </summary>
        /// <value></value>
        public string LastName { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        /// <value></value>
        public string Email { get; set; }

        /// <summary>
        /// Data de nascimento
        /// </summary>
        /// <value></value>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        /// <value></value>
        public string Password { get; set; }

        public static explicit operator User(UserRegisterRequest request)
        {
            return new User{
                Email= request.Email,
                FirstName= request.FirstName,
                LastName= request.LastName,
                Password= request.Password,
                BirthDate= request.BirthDate,               
            };
        }
    }
}