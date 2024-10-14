using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q5 : ControllerBase
    {
        /// <summary>
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
        /// POST api/Q5/SecretInstructions
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// DATA: Players=3&Points=12%2C10%2C9&Fouls=4%2C3%2C1 -> 3+
        ///       MEAN: (Players=3&Points=12,10,9&Fouls=4,3,1 -> 3+)
        /// </example>
        [HttpPost(template:"SecretInstructions")]
        [Consumes("application/x-www-form-urlencoded")]
        public string SecretInstructions([FromForm]string Instructions)
        {
            List<string> Results = new List<string> { };
            var inputList = Instructions.Split(' ');
            string previousDirection = "";

            foreach (string Result in inputList)
            {
                if (Result == "99999")
                break;

                int firstInstruction = int.Parse(Result.Substring(0, 2));
                int secondInstruction = int.Parse(Result.Substring(2));
                string direction;
                int sum = int.Parse(firstInstruction.ToString()[0].ToString()) + int.Parse(firstInstruction.ToString()[1].ToString());

                if (sum == 0)
                {
                    direction = previousDirection;
                }
                else if (sum % 2 == 0)
                {
                    direction = "Right";
                }
                else
                {
                    direction = "Left";
                }

                Results.Add($"{direction} {secondInstruction}");
                previousDirection = direction;
            }

            return string.Join(" ", Results);
        }
    }
}
