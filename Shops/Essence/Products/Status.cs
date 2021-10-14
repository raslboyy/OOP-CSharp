namespace Shops.Essence.Products
{
    public enum Status
    {
        /// <summary>
        /// New event created
        /// </summary>
        Create,

        /// <summary>
        /// The event in progress
        /// </summary>
        Processing,

        /// <summary>
        /// Delivery event
        /// </summary>
        Delivery,

        /// <summary>
        /// The event completed
        /// </summary>
        Complete,
    }
}