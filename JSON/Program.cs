using System.Text.Json;

string fileName = "Character.json";
Hero hero = JsonSerializer.Deserialize<Hero>(File.ReadAllText(fileName));

Hero Hero = new Hero();

Game();
void Game() {
    Console.Clear();
    Console.WriteLine("Hello Player!\nWould you like to create a new character?\nType '1' to create a character\nType '2' to load an old character");
    string input = Console.ReadLine();
    Console.Clear();
    if (input == "1") {
        Console.WriteLine("Are you sure?\nThis action will overwrite the old character's info\nType 'Y' To continue");
        input = Console.ReadLine().ToLower();
        if (input == "y") {
            Console.WriteLine("Character Name:");
            Hero.name = Console.ReadLine();
            Console.WriteLine("Character Description:");
            Hero.description = Console.ReadLine();
            Console.WriteLine("Character Ability:");
            Hero.ability = Console.ReadLine();
            string jsonString = JsonSerializer.Serialize<Hero>(Hero);
            File.WriteAllText(fileName, jsonString);
        }
        else {
            Game();
        }
    }
    else if (input == "2") {
        if (hero.name != null && hero.description != null && hero.ability != null) {
            Console.WriteLine("Character Stats:");
            Console.WriteLine($"Name: {hero.name}\nDescription: {hero.description}\nAbility: {hero.ability}");
            Console.ReadLine();
        }
        else {
            Game();
        }
    }

    else {
        Game();
    } 
}