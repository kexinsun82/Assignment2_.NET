using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q1 : ControllerBase
    {
        /// <summary>
        /// Determine the final score at the end of a game.
        /// Gain 50 points for every package delivered.
        /// Lose 10 points for every collision with an obstacle.
        /// Earn a bonus 500 points if the number of packages delivered is greater than the number of collisions with obstacles.
        /// </summary>
        /// <param name="collisions">the number of collisions</param>
        /// <param name="deliveries">the number of deliveries</param>
        /// <returns>
        /// score -> deliveries * 50 - collisions * 10 + 500 (if deliveries > collisions)
        /// </returns>
        /// <example>
        /// POST api/Q1/Delivedroid
        /// Header: Content-Type: application/x-www-form-urlencoded
        /// DATA:   collisions=2&deliveries=5 -> 730
        /// </example>
        /// <example>
        /// POST api/Q1/Delivedroid
        /// Header: Content-Type: application/x-www-form-urlencoded
        /// DATA:   collisions=10&deliveries=0 -> -100
        /// </example>
        /// <example>
        /// POST api/Q1/Delivedroid
        /// Header: Content-Type: application/x-www-form-urlencoded
        /// DATA:   collisions=3&deliveries=2 -> 70
        /// </example>
        /// <example>
        /// POST api/Q1/Delivedroid
        /// Header: Content-Type: application/x-www-form-urlencoded
        /// DATA:   collisions=6&deliveries=7 -> 790
        /// </example>
        [HttpPost(template:"Delivedroid")]
        public int Delivedroid([FromForm]int collisions, [FromForm]int deliveries)
        {
            int score = deliveries * 50 - collisions * 10;
            if (deliveries > collisions) 
            {
                score += 500;
            } 
            return score;
        }
    }
}