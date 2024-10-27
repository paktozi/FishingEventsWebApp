using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingEventsApp.Common
{
    public static class ValidationConstants
    {
        public const string LengthErrorMessage = "Value {0} must between {2} and {1} characters long!";
        public const string RequiredErrorMessage = "Value {0} is Required!";
        public const string DateFormat = "dd-MM-yyyy";
        public const int FishingEventNameMinLength = 5;
        public const int FishingEventNameMaxLength = 50;

        public const int FishingEventDescriptionMinLength = 5;
        public const int FishingEventDescriptionMaxLength = 250;

        public const int LocationNameMinLength = 3;
        public const int LocationNameMaxLength = 50;



    }
}
