using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LearnerManager.API.Helpers.Enums
{
    public enum SmsEnum
    {
        [Description("Sms Sent successsully!")]
        SuccessMessage = 200,
        [Description("An error occured please contact admin!")]
        ErrorMessage = 401,
    }
}
