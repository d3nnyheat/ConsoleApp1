using System;
using System.Collections.Generic;
using System.Linq;

// объявление класса User с необходимыми для запроса данными
public class User
{
    public string nickname { get; set; } // добавили никнейм для идентификации пользователя в таблице
    public int age { get; set; }
    public int wallet { get; set; }
    public DateTime regdate { get; set; }
    public bool IsActiveSub { get; set; }
    public string email { get; set; }
    
// создание списка пользователей и генерация информации о них
    public static List<User> GenerateRandomUsers(int count)
    {
        Random random = new Random();
        return Enumerable.Range(1, count).Select(_ => new User
        {
            nickname = GenerateNickname(),
            age = random.Next(1, 101),
            wallet = random.Next(100, 1000000),
            regdate = GenerateRandomRegDate(),
            email = GenerateRandomEmail(),
            IsActiveSub = random.Next(2) == 0
        }).ToList();
    }
    // генерация никнейма пользователя
    private static string GenerateNickname()
    {
        Random r = new Random();
        string[] soglas = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
        string[] glas = { "a", "e", "i", "o", "u", "y" };
        string Nickname = "";
        Nickname += soglas[r.Next(soglas.Length)].ToUpper();
        Nickname += glas[r.Next(glas.Length)];
        int b = 2;
        while (b < 10)
        {
            Nickname += soglas[r.Next(soglas.Length)];
            b++;
            Nickname += glas[r.Next(glas.Length)];
            b++;
        }
        return Nickname;
    }
// генерация email
    private static string GenerateRandomEmail()
    {
        Random random = new Random();
        string[] domains = { "gmail.com", "yahoo.com", "mail.ru", "icloud.com" };
        return $"user{random.Next(100)}@{domains[random.Next(domains.Length)]}";
    }
// генерация даты регистрации
    private static DateTime GenerateRandomRegDate()
    {
        Random random = new Random();
        int range = (DateTime.Today - new DateTime(2000, 1, 1)).Days;
        return new DateTime(2010, 1, 1).AddDays(random.Next(range));
    }
}

public class Program
{
    static void Main()
    {
        List<User> users = User.GenerateRandomUsers(10000);g
        
        // цикл выводит данные о пользователях в таблицу
        for (int i = 0; i < users.Count; i++)
        {
            Console.Write(i + " "); //id
            Console.Write(users[i].nickname + " "); //никнейм
            Console.Write(users[i].age + " "); // возраст пользователя
            Console.Write(users[i].wallet+ " "); //состояние кошелька
            Console.Write(users[i].email+ " "); // адрес электронной почты
            Console.WriteLine(users[i].regdate+ " "); // дата регистрации
        }
        Console.ReadLine();
    }
}