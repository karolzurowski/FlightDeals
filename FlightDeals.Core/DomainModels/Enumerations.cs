using System.ComponentModel;

namespace FlightDeals.Core.DomainModels
{
    public enum TravelClass
    {
        [Description("Economy")]
        ECONOMY,
        [Description("Premium economy")]
        PREMIUM_ECONOMY,
        [Description("Business")]
        BUSINESS,
        [Description("First")]
        FIRST,
        [Description("Unknown")]
        UNKNOWN
    }


    public enum TravelerType
    {
        [Description("Adult")]
        ADULT,
        [Description("Child")]
        CHILD,
        [Description("Senior")]
        SENIOR,
        [Description("Young")]
        YOUNG,
        [Description("Held infant")]
        HELD_INFANT,
        [Description("Seated infant")]
        SEATED_INFANT,
        [Description("Student")]
        STUDENT,
        [Description("Unknown")]
        UNKNOWN
    }
}
