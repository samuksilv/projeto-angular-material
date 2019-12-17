using Portal.Domain.Models;
using Portal.Infra.Database.Contants.Schemas;
using Portal.Infra.Database.Contants.Tables;

namespace Portal.Infra.Database.Constants.Queries {
    public class UserQueriesConstants {

        public static readonly string GetUserByEmail = $@"
            SELECT * FROM {SchemasConstants.DboSchema}.{TableConstants.UserTable}
            WHERE  { nameof(User.Email) } = @Email";

        
        public static readonly string GetUserByEmailAndPassword = $@"
            SELECT * FROM {SchemasConstants.DboSchema}.{TableConstants.UserTable}
            WHERE  { nameof(User.Email) } = @Email 
            AND {nameof(User.Password)} = @Password";

        public static readonly string GetUserById = $@"
            SELECT TOP 1 * FROM {SchemasConstants.DboSchema}.{TableConstants.UserTable}
            WHERE  { nameof(User.Id)} = @Id";

    }
}