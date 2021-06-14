using System;

namespace RestAPIExampleProject
{
    public class EmailHelper
    {

        public static string generateRandomEmail()
        {
            Random randomGenerator = new Random();

            int randomInt = randomGenerator.Next(1000);

            string generatedEmail = "testUser" + randomInt + "@mail.com";

            return generatedEmail;
        }

    }
}
