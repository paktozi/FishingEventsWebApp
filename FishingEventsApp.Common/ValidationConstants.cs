using System.ComponentModel.DataAnnotations;

namespace FishingEventsApp.Common
{
    public static class ValidationConstants
    {
        public const string LengthErrorMessage = "Value {0} must between {2} and {1} characters long!";
        public const string RequiredErrorMessage = "Value {0} is Required!";
        public const string DateFormat = "dd-MM-yyyy";
        public const string DateErrorMessage = "Date must be in the format dd-MM-yyyy";

        //  [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-\d{4} (0[0-9]|1[0-9]|2[0-3]):([0-5][0-9])$",
        //  ErrorMessage = "Date and time must be in the format dd-MM-yyyy HH:mm")]

        public const int FishingEventNameMinLength = 5;
        public const int FishingEventNameMaxLength = 50;
        public const int FishingEventDescriptionMinLength = 5;
        public const int FishingEventDescriptionMaxLength = 250;

        public const int LocationNameMinLength = 3;
        public const int LocationNameMaxLength = 50;
        public const int LocationAltitudeMinLength = 1;
        public const int LocationAltitudeMaxLength = 10;
        public const int LocationFishingTypeMinLength = 3;
        public const int LocationFishingTypeMaxLength = 50;

        public const int FishCaughtSpeciesMinLength = 3;
        public const int FishCaughtSpeciesMaxLength = 50;
        public const double FishCaughtWeightMinRange = 0;
        public const double FishCaughtWeightMaxRange = 600;
        public const double FishCaughtLengthMinRange = 0;
        public const double FishCaughtLengthMaxRange = 5;

        public const int ParticipantNameMinLength = 2;
        public const int ParticipantNameMaxLength = 50;
    }
}
