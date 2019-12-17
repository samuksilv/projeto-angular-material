using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Portal.Domain.Configurations {
    public class SigningConfiguration {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfiguration () {
            using (var provider = new RSACryptoServiceProvider (4096)) {
                Key = new RsaSecurityKey (provider.ExportParameters (true));
            }

            SigningCredentials = new SigningCredentials (Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }

}