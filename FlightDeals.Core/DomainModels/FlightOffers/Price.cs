namespace FlightDeals.Core.DomainModels.FlightOffers

{
    public class Price
    {
        /// <summary>
        /// Total amount paid by the client
        /// </summary>       
        public float Total { get; set; }

        /// <summary>
        ///  Amount without taxes
        /// </summary>      
        public float Base { get; set; }

        public string Currency { get; set; }

    }
}
