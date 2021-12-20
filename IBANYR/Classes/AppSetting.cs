using System.Configuration;

namespace IBANYR
{
    class AppSetting
    {
        #region Private fields
        Configuration config;
        string defaultConnStringName;
        #endregion
        #region Constructors
        public AppSetting()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            defaultConnStringName = "IBANYR.Properties.Settings.IBANYRConnectionString";
        }
        #endregion
        #region Functions and methods
        public string GetConnectionString()
        {
            return config.ConnectionStrings.ConnectionStrings[defaultConnStringName].ConnectionString;
        }
        public void SaveConnectionString(string value)
        {
            config.ConnectionStrings.ConnectionStrings[defaultConnStringName].ConnectionString = Password.Encrypt(value);
            config.ConnectionStrings.ConnectionStrings[defaultConnStringName].ProviderName = "System.Data.SqlClient";
            config.Save(ConfigurationSaveMode.Modified);
        }
        #endregion
    }
}
