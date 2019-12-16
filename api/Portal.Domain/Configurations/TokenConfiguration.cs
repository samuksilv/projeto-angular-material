using System;

namespace Portal.Domain.Configurations {
    public static class TokenConfiguration {

        public static string Audience {
            get =>
                Environment.GetEnvironmentVariable ("APP_TOKEN_AUDIENCE");
        }

        public static string Issuer {
            get =>
                Environment.GetEnvironmentVariable ("APP_TOKEN_ISSUER");
        }

        public static int ExpireTimeInSeconds {
            get =>
                Convert.ToInt32 (Environment.GetEnvironmentVariable ("APP_TOKEN_EXPIRETIME_SEC"));
        }
    }
}