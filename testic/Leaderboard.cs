using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Leaderboard
{
    private const string LeaderboardFilePath = "leaderboard.json";

    public static List<User> LoadLeaderboard()
    {
        if (File.Exists(LeaderboardFilePath))
        {
            string json = File.ReadAllText(LeaderboardFilePath);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        return new List<User>();
    }

    public static void SaveLeaderboard(List<User> leaderboard)
    {
        string json = JsonConvert.SerializeObject(leaderboard, Formatting.Indented);
        File.WriteAllText(LeaderboardFilePath, json);
    }

    public static void DisplayLeaderboard(List<User> leaderboard)
    {
        Console.WriteLine("Лидеры:");
        Console.WriteLine("Имя\t\tБВМ\tБВС");
        foreach (var user in leaderboard)
        {
            Console.WriteLine($"{user.Name}\t\t{user.CharactersPerMinute}\t{user.CharactersPerSecond}");
        }
    }
}


