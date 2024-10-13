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
        /// <param name="Amount">the number of peppers Ron adds to his chili</param>
        /// <param name="Ingredients">the name of a pepper Ron has added</param>
        /// <returns>
        /// The total spiciness of Ron’s chili
        /// </returns>
        /// <example>
        /// GET api/Q2/ChiliPeppers&Ingredients=Poblano,Cayenne,Thai,Poblano -> 118000
        /// </example>
        /// <example>
        /// GET api/Q2/ChiliPeppers&Ingredients=Habanero,Habanero,Habanero,Habanero,Habanero -> 625000
        /// </example>
        /// <example>
        /// GET api/Q2/ChiliPeppers&Ingredients=Poblano,Mirasol,Serrano,Cayenne,Thai,Habanero,Serrano -> 278500
        /// </example>
        /// <example>
        /// GET api/Q2/
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

 