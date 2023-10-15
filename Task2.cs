using System;
using System.Text.RegularExpressions;

public static class Helper
{
    public static bool IsOdd(this int number)
    {
        return number % 2 != 0;
    }

    public static bool IsEven(this int number)
    {
        return number % 2 == 0;
    }

    public static bool HasDigit(this string word)
    {
        return Regex.IsMatch(word, @"\d");
    }

    public static bool CheckPassword(this string password)
    {
        return Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*\d).{8,}$");
    }

    public static string Capitalize(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        string[] words = input.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].ToUpper();
        }

        return string.Join(" ", words);
    }
}

class Program
{
    static void Main(string[] args)
    {
        int number = 5;
        Console.WriteLine($"{number} is odd. {number.IsOdd()}");
        Console.WriteLine($"{number} is even {number.IsEven()}");

        string word = "0sman";
        Console.WriteLine($"'{word}' contain digits. {word.HasDigit()}");

        string password = "Password";
        Console.WriteLine($"'{password}' is valid. {password.CheckPassword()}");

        string input = "we are all uppercase!";
        Console.WriteLine($"Capitalized: {input.Capitalize()}");
    }
}
