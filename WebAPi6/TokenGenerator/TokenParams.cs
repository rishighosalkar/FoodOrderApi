namespace WebAPi6.TokenGenerator
{
    public class TokenParams
    {
        public bool ValidateIssuerSignature { get; set; }
        public string IssuerSigningKey { get; set; }
        public bool ValidateIssuer { get; set; }
        public string ValidIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public string ValidAudience { get; set; }
        public bool RequireExpirationTime { get; set; }
        public bool ValidateLifetime { get; set; }
    }
}

/*"ValidateIssuerSignature": true,
    "IssuerSigningKey": "64A63153-11C1-5919-9133-KFAF99A9B456",
    "ValidateIssuer": true,
    "ValidIssuer": "https://localhost:7043/",
    "ValidateAudience": true,
    "ValidAudience": "https://localhost:7043/",
    "RequireExpirationTime": true,
    "ValidateLifetime": true*/
