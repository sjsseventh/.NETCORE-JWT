using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace APIAcessoDados.Modelos
{
    public class Login
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public Login()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
