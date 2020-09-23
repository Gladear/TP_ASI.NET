namespace ClientConvertisseurV2.Models
{
    /// <summary>
    /// Model of a currency
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// The id of the currency
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the currency
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The rate of a currency (compared to dollars)
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// Constructor of the currency model
        /// </summary>
        public Currency()
        {

        }

        /// <summary>
        /// Constructor of the currency model.
        /// Set up the attributes.
        /// </summary>
        /// <param name="id">The id of the currency</param>
        /// <param name="name">The name of the currency</param>
        /// <param name="rate">The rate of the currency</param>
        public Currency(int id, string name, double rate)
        {
            Id = id;
            Name = name;
            Rate = rate;
        }
    }
}
