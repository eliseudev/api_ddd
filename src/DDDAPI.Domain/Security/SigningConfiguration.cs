using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace DDDAPI.Domain.Security
{
    public class SigningConfiguration
    {
        public SecurityKey Key { get; set; }

        public SigningCredentials SigningCredentials { get; set; }

        public SigningConfiguration()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
