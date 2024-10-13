using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q3 : ControllerBase
    {
        /// <summary>
        /// Determine  the total spiciness of Ron’s chili after he has finished adding peppers.
        /// Ron’s chili is currently not spicy at all, but each time Ron adds a pepper, the total spiciness of the chili increases by the SHU value of that pepper.
        /// Poblano = 1500
        /// Mirasol = 6000
        /// Serrano = 15500
        /// Cayenne = 40000
        /// Thai = 75000
        /// Habanero = 125000
        /// </summary>
        /// <param name="Ingredients">the name of a pepper Ron has added</param>
        /// <returns>
        /// The total spiciness of Ron’s chili
        /// </returns>
        /// <example>
        /// GET api/Q3/ChiliPeppers&Ingredients=Poblano%2CCayenne%2CThai%2CPoblano -> 118000
        /// </example>
        /// <example>
        /// GET api/Q3/ChiliPeppers&Ingredients=Habanero%2CHabanero%2CHabanero%2CHabanero%2CHabanero -> 625000
        /// </example>
        /// <example>
        /// GET api/Q3/ChiliPeppers&Ingredients=Poblano%2CMirasol%2CSerrano%2CCayenne%2CThai%2CHabanero%2CSerrano -> 278500
        /// </example>
        /// <example>
        /// GET api/Q3/ChiliPeppers&Ingredients=Poblano%2CPoblano%2CMirasol%2CMirasol -> 15000
        /// </example>
        [HttpGet(template:"ChiliPeppers&Ingredients={Ingredients}")]
        public string Spiciness(string Ingredients)
        // public string Spiciness(int Amount, string Ingredients)
        {
            string[] value = Ingredients.Split(',');

            // if (value.Length != Amount)
            // {
            //     return "Sorry, the number of Ingredients doesn't match the number of ChiliPeppers.";
            // }
            int spiciness = 0;

            foreach (string pepper in value)
            {
                string updatedPepper = pepper.Trim();
                if (updatedPepper == "Poblano")
                {
                    spiciness += 1500;
                }
                else if  (updatedPepper == "Mirasol")
                {
                    spiciness += 6000;
                }
                else if  (updatedPepper == "Serrano")
                {
                    spiciness += 15500;
                }
                else if  (updatedPepper == "Cayenne")
                {
                    spiciness += 40000;
                }
                else if  (updatedPepper == "Thai")
                {
                    spiciness += 75000;
                }
                else if  (updatedPepper == "Habanero")
                {
                    spiciness += 125000;
                }
            }
            return spiciness.ToString();
        }
    }
}

 