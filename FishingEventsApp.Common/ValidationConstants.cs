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
