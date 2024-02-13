using System.Drawing;
using System.Dynamic;
using System.Net;
#pragma warning disable CS8618
#pragma warning disable CS8625



Response rsp = await HttpUtils.instance.Get("https://crismo-morseassignment.web.val.run/msg");
Console.WriteLine(rsp.content);

Console.WriteLine(Translator.Translate(rsp.content));

// Create a mores code translator 


if (Translator.Translate("... --- ...") == "SOS")
{
    Console.WriteLine("🟢 Given simple mores sturcture");
}
else
{
    Console.WriteLine("🔴 Given simple mores sturcture");
}


if (Translator.Translate("-... .- -. .- -. .-") == "BANANA")
{
    Console.WriteLine("🟢 Given longer simple mores sturcture");
}
else
{
    Console.WriteLine("🔴 Given longer simple mores sturcture");
}



class Translator
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



#region  - Http utility functions

class Response
{
    public string? content { get; set; }
    public int statusCode { get; set; }
    public string url { get; set; }
}

class HttpUtils
{

    private HttpClient httpClient = new HttpClient();


    private static HttpUtils _instance = null;

    public static HttpUtils instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new HttpUtils();
            }
            return _instance;
        }
    }

    private HttpUtils()
    {

    }


    public async Task<Response> Get(string url)
    {
        int statusCode = 0;
        String? respons = null;
        try
        {
            respons = await httpClient.GetStringAsync(url);
            statusCode = 200;
        }
        catch (HttpRequestException e)
        {
            statusCode = (int)(e.StatusCode ?? 0);
            Console.Error.WriteLine($"Error : {statusCode} ");
        }

        return new Response() { content = respons, statusCode = statusCode, url = url };

    }


}


#endregion

