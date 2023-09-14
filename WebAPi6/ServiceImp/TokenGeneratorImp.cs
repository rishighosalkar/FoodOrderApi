using Microsoft.Extensions.Options;
using JWT;
using JWT.Serializers;
using JWT.Algorithms;
using WebAPi6.TokenGenerator;
using WebAPi6.Services;

namespace WebAPi6.ServiceImp
{
    public class TokenGeneratorImp : ITokenGenerator
    {
        private readonly TokenParams _params;
        public TokenGeneratorImp(IOptions<TokenParams> options)
        {
            _params = options.Value;
        }
        public string GenerateToken(Dictionary<string, object> payload)
        {
            var secret = _params.IssuerSigningKey;

            payload.Add("iss", _params.ValidIssuer);
            payload.Add("aud", _params.ValidAudience);
            payload.Add("nbf", ConvertToUnixTimestamp(DateTime.Now));
            payload.Add("iat", ConvertToUnixTimestamp(DateTime.Now));
            payload.Add("exp", ConvertToUnixTimestamp(DateTime.Now.AddHours(1)));
            IJwtAlgorithm jwtAlgorithm = new HMACSHA256Algorithm();
            IJsonSerializer jsonSerializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder jwtEncoder = new JwtEncoder(jwtAlgorithm, jsonSerializer, urlEncoder);

            return jwtEncoder.Encode(payload, secret);
        }

        private static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
    }
}
