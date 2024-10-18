using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q4 : ControllerBase
    {
        /// <summary>
        /// https://cemc.uwaterloo.ca/sites/default/files/documents/2022/2022CCCJrProblemSet.html 
        /// Fergusonball players are given a star rating based on the number of points that they score and the number of fouls that they commit. 
        /// 5 stars for each point scored
        /// 3 stars are taken away for each foul committed.
        /// Determine how many players on a team have a star rating greater than 40. You also need to determine if the team is considered a gold team which means that all the players have a star rating greater than 40.
        /// </summary>
        /// <param name="Players">The number of players</param>
        /// <param name="Points">The points array for each player</param>
        /// <param name="Fouls">The fouls array for each player</param>
        /// <returns>
        /// The number of players that have a star rating greater than 40, immediately followed by a plus sign if the team is considered a gold team.
        /// </returns>
        /// <example>
        /// POST api/Q4/StarRating
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// DATA: Players=3&Points=12%2C10%2C9&Fouls=4%2C3%2C1 -> 3+
        ///       MEAN: (Players=3&Points=12,10,9&Fouls=4,3,1 -> 3+)
        /// </example>
        /// <example>
        /// POST api/Q4/StarRating
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// DATA: Players=2&Points=8%2C12&Fouls=0%2C1 -> 1
        ///       MEAN: (Players=2&Points=8,12&Fouls=0,1 -> 1)
        /// </example>
        /// POST api/Q4/StarRating
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// DATA: Players=4&Points=8%2C6%2C4%2C2&Fouls=3%2C2%2C1%2C0 -> 0
        ///       MEAN: (Players=4&Points=8,6,4,2&Fouls=3,2,1,0 -> 0)
        /// </example>
        [HttpPost(template:"StarRating")]
        [Consumes("application/x-www-form-urlencoded")]
        public string StarRating([FromForm]string Players, [FromForm] string Points, [FromForm] string Fouls)
        {
            int finalCount = 0;
            bool scorePlus = true;
            int playersInput = int.Parse(Players);

            string[] pointsValue = Points.Split(',');
            string[] foulsValue = Fouls.Split(',');

            if (pointsValue.Length != playersInput || foulsValue.Length != playersInput)
            {
                finalCount = 0;
            }

            for (int i = 0; i < playersInput; i++)
            {
                int intPoints = int.Parse(pointsValue[i].Trim());
                int intFouls = int.Parse(foulsValue[i].Trim());
                int StarRating = intPoints * 5 - intFouls * 3;

                if (StarRating > 40)
                {
                    finalCount++;
                }
                else
                {
                    scorePlus = false;
                }
            }

            if (scorePlus == true)
            {
                return finalCount + "+";
            }
            else
            {
                return finalCount.ToString();
            }
        }
    }
}
