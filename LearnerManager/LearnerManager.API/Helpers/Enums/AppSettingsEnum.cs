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

    }
}
