using Microsoft.Extensions.Configuration;

namespace DataAccess.Implementations {
    public class DataAcessConfigSettings {
        public InternalStorageConfig? InternalStorage { get; set; }

        public bool IsValid { get; private set; }
        public List<string> ErrorMessages { get; } = new List<string>();

        public DataAcessConfigSettings(IConfiguration configuration) {
            configuration.GetSection("DataAccessor").Bind(this);

            _Validate();

            if(!IsValid)
               throw new ConfigurationErrorException(string.Join("|", ErrorMessages));

            return;
        }

        private void _Validate() {
            if (InternalStorage?.ConnectionString is null)
                ErrorMessages.Add("InternalStorage:ConnectionString is missing.");

            IsValid = ErrorMessages.Count == 0;
        }
    }

    public class ConfigurationErrorException : Exception {
               public ConfigurationErrorException(string message) : base(message) { }
    }

    public class InternalStorageConfig {
        public string? ConnectionString { get; set; }
    }
}
