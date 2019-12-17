using System;

namespace Portal.Domain.Configurations {
    public static class DabaseConnectionConfiguration {
        public static string ConnectionString {
            get => Environment.GetEnvironmentVariable ("APP_DB_CONNECTION");
        }
    }
}