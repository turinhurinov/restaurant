using Microsoft.Extensions.Configuration;
using Restaurant.Framework.Abtract;
using Restaurant.Model;
using System;

namespace Restaurant.Framework.Services
{
    public class Settings : ISettings
    {
        #region ctor

        readonly IConfiguration configuration;

        public Settings(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #endregion

        #region setting readers

        string GetAppSettingValueAsString(ConfigKey key)
        {
            return GetConfigValue(key);
        }

        int GetAppSettingValueAsInt(ConfigKey key)
        {
            var value = GetConfigValue(key);
            return Convert.ToInt32(value);
        }

        bool GetAppSettingValueAsBool(ConfigKey key)
        {
            var value = GetConfigValue(key);
            return Convert.ToBoolean(value);
        }

        string GetConfigValue(ConfigKey key)
        {
            return configuration.GetSection(SectionNames.AppSettings)[key.ToString()];
        }

        #endregion

        #region settings
        public string SmtpAddress => GetAppSettingValueAsString(ConfigKey.SmtpAddress);
        public string SmtpUsername => GetAppSettingValueAsString(ConfigKey.SmtpUsername);
        public string SmtpPassword => GetAppSettingValueAsString(ConfigKey.SmtpPassword);
        public int SmtpPortNumber => GetAppSettingValueAsInt(ConfigKey.SmtpPortNumber);
        public bool SmtpEnableSSL => GetAppSettingValueAsBool(ConfigKey.SmtpEnableSSL);
        public string SupportEmailAddress => GetAppSettingValueAsString(ConfigKey.SupportEmailAddress);
        public string DefaultMailSenderName => GetAppSettingValueAsString(ConfigKey.DefaultMailSenderName);
        #endregion
    }

    public static class SectionNames
    {
        public static string AppSettings => nameof(AppSettings);
    }
}