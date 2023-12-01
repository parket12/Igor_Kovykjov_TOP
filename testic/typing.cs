using System.Diagnostics;

public class TypingTest
{
    private const string TestText = "Вот это введи мне живо и быстрее и живее кайф короче балдеж, код будущего Дубай летим";

    public void RunTest()
    {
        Console.Write("Введи свое погоняло: ");
        string userName = Console.ReadLine();

        Console.WriteLine($"Нажми интер, чтобы начать :\n{TestText}");
        Console.ReadLine(); 

        Console.Clear();
        Console.WriteLine($"Вводи вот текст, что непонятного:\n{TestText}");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        int correctCharacters = 0;
        int currentIndex = 0;

        do
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.KeyChar == TestText[currentIndex])
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(key.KeyChar);
                Console.ResetColor();
                correctCharacters++;
                currentIndex++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("X");
                Console.ResetColor();
            }

        } while (currentIndex < TestText.Length);

        Console.WriteLine();

        stopwatch.Stop();

        int totalCharacters = TestText.Length;

        int charactersPerMinute = (int)(correctCharacters / stopwatch.Elapsed.TotalMinutes);
        int charactersPerSecond = (int)(correctCharacters / stopwatch.Elapsed.TotalSeconds);

        Console.WriteLine($"Букв в минуту: {charactersPerMinute}");
        Console.WriteLine($"Букв в секунду: {charactersPerSecond}");

        var leaderboard = Leaderboard.LoadLeaderboard();
        leaderboard.Add(new User
        {
            Name = userName,
            CharactersPerMinute = charactersPerMinute,
            CharactersPerSecond = charactersPerSecond
        });
        Leaderboard.SaveLeaderboard(leaderboard);

        Leaderboard.DisplayLeaderboard(leaderboard);
    }
}