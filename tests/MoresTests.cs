using MoresCode;
namespace MorseTestColection
{
    class MoresTests
    {

        public static void ConditionalyRunTests(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] == "--test")
                {
                    MoresTests tests = new MoresTests();
                    tests.RunTests();
                }
            }
        }


        public void RunTests()
        {
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
        }


    }
}