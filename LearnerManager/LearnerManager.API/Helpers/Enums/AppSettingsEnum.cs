using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Helpers.Enums
{
    public enum AppSettingsEnum
    {
        [Description("Data")]
        Data = 0,
        [Description("ConnectionString")]
        Database = 1,
        [Description("AppSettings")]
        AppSettings = 2,
        [Description("CorsPolicy")]
        Cors= 3,
        [Description("Twilio")]
        Twilio = 4,
        [Description("BulkSms")]
        BulkSms = 5
    }

    public enum BulkSMSEnum
    {
        [Description("Username")]
        Username = 1,
        [Description("Password")]
        Password = 1,
        [Description("URI")]
        Uri = 1,
    }
}
