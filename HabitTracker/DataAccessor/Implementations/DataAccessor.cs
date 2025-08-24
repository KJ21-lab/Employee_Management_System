using DataAccess.Interfaces;

using Microsoft.Extensions.Configuration;

namespace DataAccess.Implementations {
    public class DataAccessor(IConfiguration configuration) : IDataAccessor {
        public IInternalStorageCaller InternalStorageCaller() => new InternalStorageCaller(configToUse());

        private DataAcessConfigSettings configToUse() {
            DataAcessConfigSettings config = new(configuration);

            return config.IsValid
                ? config
                : throw new ConfigurationErrorException(
                    string.Join("|", config.ErrorMessages));
        }
    }

    public class ConfigurationErrorException : Exception {
        public ConfigurationErrorException(string message) : base(message) { }
    }
}
