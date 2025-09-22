using Microsoft.Extensions.Configuration;

namespace DataAccess.Implementations {
    public class DataAcessConfigSettings {
        public InternalStorageConfig? InternalStorage { get; set; }

        public bool IsValid { get; private set; }
        public List<string> ErrorMessages { get; } = new List<string>();

        public DataAcessConfigSettings(IConfiguration configuration) {
            configuration.GetSection("DataAccessor").Bind(this);

            _Validate();
        }

        private void _Validate() {
            if (InternalStorage?.ConnectionString is null) {
                ErrorMessages.Add("InternalStorage:ConnectionString is missing.");
            }

            IsValid = ErrorMessages.Count == 0;
        }
    }

    public class InternalStorageConfig {
        public string? ConnectionString { get; set; }
    }
}
