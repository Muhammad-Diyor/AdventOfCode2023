using System.Text;

namespace AdventOfCode;

public static class Day1
{
    public static async Task<int> CalculateCalibrationValues(string textUrl)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Cookie", "session=token"); //replace token with yours
        HttpResponseMessage response = await httpClient.GetAsync(textUrl);

        string responseBody = await response.Content.ReadAsStringAsync();
        System.Console.WriteLine("Sent request and got response");

        string[] lines = responseBody.Split('\n');

        int sum = 0;
        var num = new StringBuilder("");
        foreach (var item in lines)
        {
            System.Console.WriteLine(item);
            var digitalizedString = Digitize(item);
            System.Console.WriteLine(digitalizedString);
            foreach (var character in digitalizedString)
            {
                if(Char.IsDigit(character))
                    num.Append(character);
            }
            if(num.Length == 1)
                sum += int.Parse($"{num[0]}{num[0]}");
            if(num.Length > 1)
                sum += int.Parse($"{num[0]}{num[num.Length - 1]}");
            System.Console.WriteLine(num);
            System.Console.WriteLine();
            num.Clear();
        }

        return sum;
    }

    private static string Digitize(string input)
    {
        var set = new HashSet<(string key, string value)>();

        set.Add(("one", "o1e"));
        set.Add(("two", "t2o"));
        set.Add(("three", "th3ee"));
        set.Add(("four", "fo4r"));
        set.Add(("five", "fi5e"));
        set.Add(("six", "s6x"));
        set.Add(("seven", "se7en"));
        set.Add(("eight", "eig8t"));
        set.Add(("nine", "n9ne"));

        foreach ((string key, string value) in set)
        {
            input = input.Replace(key, value);
        }

        return input;
    }   
}