using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q2 : ControllerBase
    {
        /// Notes: I specified that the box numbers had to be non-negative, this may be unnecessary but just for practice :)
        /// <summary>
        /// https://cemc.uwaterloo.ca/sites/default/files/documents/2022/2022CCCJrProblemSet.html
        /// Determine how many cupcakes will be left over if each student gets one cupcake and the number of boxes must be non-negative.
        /// A regular box of cupcakes holds 8 cupcakes, while a small box holds 3 cupcakes.
        /// There are 28 students in a class and a total of at least 28 cupcakes.s
        /// </summary>
        /// <param name="R">the number of regular box</param>
        /// <param name="S">the number of small box</param>
        /// <returns>
        /// left over cupcakes -> (R * 8 + S * 3) - 28
        /// </returns>
        /// <example>
        /// GET api/Q2/CupcakesLeft?R=2&S=5 -> 3
        /// </example>
        /// <example>
        /// GET api/Q2/CupcakesLeft?R=2&S=4 -> 0
        /// </example>
        /// <example>
        /// GET api/Q2/CupcakesLeft?R=3&S=2 -> 2
        /// </example>
        /// <example>
        /// GET api/Q2/CupcakesLeft?R=4&S=1 -> 7
        /// </example>
        /// <example>
        /// GET api/Q2/CupcakesLeft?R=-4&S=1 -> The number of boxes must be non-negative.
        /// </example>
        [HttpGet(template:"CupcakesLeft")]
        public string CupcakesLeft(int R, int S)
        {
            int totalCuptakes = R * 8 + S * 3;
            int left = totalCuptakes - 28;
            if (R < 0 || S < 0)
            {
                return "The number of boxes must be non-negative.";
            }
            else 
            {
                return left.ToString();
            }
        }
    }
}