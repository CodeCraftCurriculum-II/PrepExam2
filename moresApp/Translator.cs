namespace MoresCode
{

    public class Translator
    {
        private static Dictionary<string, string> morseToAlphabet = new Dictionary<string, string>
{
    {".-", "A"},
    {"-...", "B"},
    {"-.-.", "C"},
    {"-..", "D"},
    {".", "E"},
    {"..-.", "F"},
    {"--.", "G"},
    {"....", "H"},
    {"..", "I"},
    {".---", "J"},
    {"-.-", "K"},
    {".-..", "L"},
    {"--", "M"},
    {"-.", "N"},
    {"---", "O"},
    {".--.", "P"},
    {"--.-", "Q"},
    {".-.", "R"},
    {"...", "S"},
    {"-", "T"},
    {"..-", "U"},
    {"...-", "V"},
    {".--", "W"},
    {"-..-", "X"},
    {"-.--", "Y"},
    {"--..", "Z"},
    {"-----", "0"},
    {".----", "1"},
    {"..---", "2"},
    {"...--", "3"},
    {"....-", "4"},
    {".....", "5"},
    {"-....", "6"},
    {"--...", "7"},
    {"---..", "8"},
    {"----.", "9"},
    {"/", " "}, // Word delimiter
    {".-.-.-", "."},
    {"--..--", ","},
    {"..--..", "?"},
    {".----.", "'"},
    {"-.-.--", "!"},
    {"-..-.", "/"},
    {"-.--.", "("},
    {"-.--.-", ")"},
    {".-...", "&"},
    {"---...", ":"},
    {"-.-.-.", ";"},
    {"-...-", "="},
    {".-.-.", "+"},
    {"-....-", "-"},
    {"..--.-", "_"},
    {".-..-.", "\""},
    {"...-..-", "$"},
    {".--.-.", "@"}
};

        public static string Translate(string moresCode)
        {

            string[] lettersInMorse = moresCode.Split(" ");
            string translation = "";

            foreach (string letter in lettersInMorse)
            {
                if (morseToAlphabet.ContainsKey(letter))
                {
                    translation += morseToAlphabet[letter];
                }
                else
                {
                    translation += "🤪";
                }
            }

            return translation;
        }
    }
}