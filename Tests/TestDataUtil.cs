using System.Text;

namespace Tests;

public class TestDataUtil
{
    public static string GenerateRandomString(int length)
    {
        // Define the characters allowed in the random string
        const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        // Create a Random object
        Random random = new Random();

        // Create a StringBuilder to store the random string
        StringBuilder stringBuilder = new StringBuilder();

        // Generate x-number random characters
        for (int i = 0; i < length; i++)
        {
            // Get a random index to select a character from allowedChars
            int randomIndex = random.Next(0, allowedChars.Length);

            // Append the randomly selected character to the StringBuilder
            stringBuilder.Append(allowedChars[randomIndex]);
        }

        // Convert the StringBuilder to a string
        return stringBuilder.ToString();
    }
}
