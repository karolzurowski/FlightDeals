using System;
using System.ComponentModel;
using DomainTravelerType = FlightDeals.Core.DomainModels.TravelerType;
using ServiceTravelerType = FlightDeals.Core.ApiModels.TravelerType;
using SomainTravelClass = FlightDeals.Core.DomainModels.TravelClass;
using ServiceTravelClass = FlightDeals.Core.ApiModels.TravelClass;
using Api = FlightDeals.Core.ApiModels.FlightOffers;
using Domain = FlightDeals.Core.DomainModels.FlightOffers;
using System.Text;

namespace FlightDeals.Core.Extensions
{
    //public static class EnumExtensions
    //{
    //    public static string ToDescriptionString(this Enum val)
    //    {
    //        DescriptionAttribute[] attributes = (DescriptionAttribute[])val
    //           .GetType()
    //           .GetField(val.ToString())
    //           .GetCustomAttributes(typeof(DescriptionAttribute), false);
    //        return attributes.Length > 0 ? attributes[0].Description : string.Empty;
    //    }


    //    public static DomainTravelerType ToDomainTravelerType(this ServiceTravelerType travelerType)
    //    {
    //        switch (travelerType)
    //        {

    //            case ServiceTravelerType.ADULT:
    //                return DomainTravelerType.ADULT;
    //            case ServiceTravelerType.CHILD:
    //                return DomainTravelerType.CHILD;
    //            case ServiceTravelerType.SENIOR:
    //                return DomainTravelerType.SENIOR;
    //            case ServiceTravelerType.YOUNG:
    //                return DomainTravelerType.YOUNG;
    //            case ServiceTravelerType.HELD_INFANT:
    //                return DomainTravelerType.HELD_INFANT;
    //            case ServiceTravelerType.SEATED_INFANT:
    //                return DomainTravelerType.SEATED_INFANT;
    //            case ServiceTravelerType.STUDENT:
    //                return DomainTravelerType.STUDENT;
    //            default:
    //                return DomainTravelerType.UNKNOWN;
    //        }
    //    }

    //    public static ServiceTravelerType ToServiceTravelerType(this DomainTravelerType travelerType)
    //    {
    //        switch (travelerType)
    //        {

    //            case DomainTravelerType.ADULT:
    //                return ServiceTravelerType.ADULT;
    //            case DomainTravelerType.CHILD:
    //                return ServiceTravelerType.CHILD;
    //            case DomainTravelerType.SENIOR:
    //                return ServiceTravelerType.SENIOR;
    //            case DomainTravelerType.YOUNG:
    //                return ServiceTravelerType.YOUNG;
    //            case DomainTravelerType.HELD_INFANT:
    //                return ServiceTravelerType.HELD_INFANT;
    //            case DomainTravelerType.SEATED_INFANT:
    //                return ServiceTravelerType.SEATED_INFANT;
    //            case DomainTravelerType.STUDENT:
    //                return ServiceTravelerType.STUDENT;
    //            default:
    //                return ServiceTravelerType.ADULT;
    //        }
    //    }

    //    public static SomainTravelClass ToDomainTravelClass(this ServiceTravelClass travelerType)
    //    {
    //        switch (travelerType)
    //        {

    //            case ServiceTravelClass.ECONOMY:
    //                return SomainTravelClass.ECONOMY;
    //            case ServiceTravelClass.PREMIUM_ECONOMY:
    //                return SomainTravelClass.PREMIUM_ECONOMY;
    //            case ServiceTravelClass.BUSINESS:
    //                return SomainTravelClass.BUSINESS;
    //            case ServiceTravelClass.FIRST:
    //                return SomainTravelClass.FIRST;
    //            default:
    //                return SomainTravelClass.UNKNOWN;
    //        }
    //    }

    //    public static ServiceTravelClass ToServiceTravelClass(this SomainTravelClass travelerType)
    //    {
    //        switch (travelerType)
    //        {

    //            case SomainTravelClass.ECONOMY:
    //                return ServiceTravelClass.ECONOMY;
    //            case SomainTravelClass.PREMIUM_ECONOMY:
    //                return ServiceTravelClass.PREMIUM_ECONOMY;
    //            case SomainTravelClass.BUSINESS:
    //                return ServiceTravelClass.BUSINESS;
    //            case SomainTravelClass.FIRST:
    //                return ServiceTravelClass.FIRST;
    //            default:
    //                return ServiceTravelClass.ECONOMY;
    //        }
    //    }

    //    public  static Domain.Price ToDomainPrice(this Api.Price price)
    //    {
    //        return new Domain.Price(price.Total, price.Base, price.Currency);
    //    }
    //}
}
