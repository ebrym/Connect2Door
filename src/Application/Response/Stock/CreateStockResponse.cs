namespace Application.Response.Stock
{
    public class CreateStockResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product model no.
        /// </summary>
        /// <value>
        /// The product model no.
        /// </value>
        public string ProductModelNo { get; set; }

        /// <summary>
        /// Gets or sets the identity number.
        /// </summary>
        /// <value>
        /// The identity number.
        /// </value>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>
        /// The unit price.
        /// </value>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the stock quantity.
        /// </summary>
        /// <value>
        /// The stock quantity.
        /// </value>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        /// <value>
        /// The total price.
        /// </value>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the re order level.
        /// </summary>
        /// <value>
        /// The re order level.
        /// </value>
        public int ReOrderLevel { get; set; }

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>
        /// The group identifier.
        /// </value>
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the sub group identifier.
        /// </summary>
        /// <value>
        /// The sub group identifier.
        /// </value>
        public string SubGroupId { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>
        /// The vendor identifier.
        /// </value>
        public string VendorId { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        public string LocationId { get; set; }

        /// <summary>
        /// Gets or sets the location threshold.
        /// </summary>
        /// <value>
        /// The location threshold.
        /// </value>
        public int LocationThreshold { get; set; }

        /// <summary>
        /// Gets or sets the unit of measurement identifier.
        /// </summary>
        /// <value>
        /// The unit of measurement identifier.
        /// </value>
        public string UnitOfMeasurementId { get; set; }

        /// <summary>
        /// Gets or sets the depreciation year.
        /// </summary>
        /// <value>
        /// The depreciation year.
        /// </value>
        public int DepreciationYear { get; set; }

        /// <summary>
        /// Gets or sets the attachment link.
        /// </summary>
        /// <value>
        /// The attachment link.
        /// </value>
        public string AttachmentLink { get; set; }
    }
}