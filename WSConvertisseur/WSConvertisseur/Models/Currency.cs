using System.ComponentModel.DataAnnotations;

namespace WSConvertisseur.Models
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
        [Required]
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

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var that = (Currency)obj;

            return Id == that.Id &&
                Name.Equals(that.Name) &&
                Rate == that.Rate;
        }
    }
}
