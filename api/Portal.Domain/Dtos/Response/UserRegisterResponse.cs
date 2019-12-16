using System;
using Portal.Domain.Models;

namespace Portal.Domain.Dtos.Response {
    public class UserRegisterResponse {

        /// <summary>
        /// Id do usuário
        /// </summary>
        /// <value></value>
        public Guid Id { get; set; }

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
        /// Data de criação
        /// </summary>
        /// <value></value>
        public DateTime? CreatedAt { get; set; }

        public static explicit operator UserRegisterResponse (User model) {
            return new UserRegisterResponse {
                Id = model.Id,
                BirthDate = model.BirthDate,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                CreatedAt = model.CreatedAt,
            };
        }
    }
}