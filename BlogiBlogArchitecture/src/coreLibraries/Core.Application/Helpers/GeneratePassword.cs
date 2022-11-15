namespace Core.Application.Helpers
{
    public static class GeneratePassword
    {
        public static string GenerateRandomPassword()
        {
            string[] randomChars = new[] {
                                "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
                                "abcdefghijkmnopqrstuvwxyz",    // lowercase
                                "0123456789",                   // digits
                                "!@$?_-"                        // non-alphanumeric
                        };

            var rand = new Random(Environment.TickCount);
            var chars = new List<char>();

            chars.Insert(rand.Next(0, chars.Count),
             randomChars[1][rand.Next(0, randomChars[1].Length)]);

            chars.Insert(rand.Next(0, chars.Count),
               randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < 8 || chars.Distinct().Count() < 4; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }


            return new string(chars.ToArray());
        }
    }
}
