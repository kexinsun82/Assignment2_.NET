using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Q5 : ControllerBase
    {
        /// <summary>
        /// https://cemc.uwaterloo.ca/sites/default/files/documents/2021/2021CCCJrProblemSet.html
        /// Professor Santos has decided to hide a secret formula for a new type of biofuel. She has, however, left a sequence of coded instructions for her assistant. Each instruction is a sequence of five digits which represents a direction to turn and the number of steps to take. 
        /// The first two digits represent the direction to turn:
        /// If their sum is zero, then the direction to turn is the same as the previous instruction.
        /// If their sum is odd, then the direction to turn is left.
        /// If their sum is even and not zero, then the direction to turn is right.
        /// The remaining three digits represent the number of steps to take which will always be at least 100.
        /// Determine how to decode the instructions so the assistant can use them to find the secret formula.
        /// </summary>
        /// <param name="Instructions">User's input string</param>
        /// <returns>
        /// Decoding of the corresponding instruction: either left or right, followed by a single space, followed by the number of steps to be taken in that direction.
        /// </returns>
        /// <example>
        /// POST api/Q5/SecretInstructions
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// DATA: Instructions=57234%2C00907%2C34100%2C99999 -> Right 234,Right 907,Left 100
        ///       MEAN: (Instructions=57234,00907,34100,99999 -> Right 234,Right 907,Left 100)
        /// </example>
        /// <example>
        /// POST api/Q5/SecretInstructions
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// DATA: Instructions=12666%2C00777%2C62999%2C67123%2C00888 -> Left 666,Left 777,Right 999,Left 123,Left 888
        ///       MEAN: (Instructions=12666,00777,62999,67123,00888 -> Left 666,Left 777,Right 999,Left 123,Left 888)
        /// </example>
        /// <example>
        /// POST api/Q5/SecretInstructions
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// DATA: Instructions=23456%2C46532%2C00679%2C99999%2C12987%2C86532 -> Left 456,Right 532,Right 679
        ///       MEAN: (Instructions=23456,46532,00679,99999,12987,86532 -> Left 456,Right 532,Right 679)
        /// </example>
        [HttpPost(template:"SecretInstructions")]
        [Consumes("application/x-www-form-urlencoded")]
        public string SecretInstructions([FromForm]string Instructions)
        {
            List<string> finalResult = new List<string> { };
            var inputList = Instructions.Split(',');
            string previousDirection = "";

            foreach (string Result in inputList)
            {
                if (Result == "99999")
                break;

                if (Result.Length == 5) 
                {
                    int firstInstruction = int.Parse(Result.Substring(0, 2));
                    int steps = int.Parse(Result.Substring(2));
                    int sum = (firstInstruction / 10) + (firstInstruction % 10);
                    string direction = "";

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

                    finalResult.Add($"{direction} {steps}");
                    previousDirection = direction;
                }
            }

            return string.Join(",", finalResult);
        }
    }
}
