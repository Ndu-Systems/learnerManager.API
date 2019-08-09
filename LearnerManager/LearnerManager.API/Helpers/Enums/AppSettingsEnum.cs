using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Helpers.Enums
{
    public enum AppSettingsEnum
    {
        [Description("sqlserverconnection")]
        Database = 1,
        [Description("AppSettings")]
        Security = 2,
        [Description("CorsPolicy")]
        Cors= 3,
        [Description("Twilio")]
        Twilio = 4,

    }
}
