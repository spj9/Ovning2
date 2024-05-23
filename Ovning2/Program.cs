// Övning 2

// Skriv ut huvudmenyn med de olika valen
while (true)
{
    Console.WriteLine("\nVälkommen! Här på huvudmenyn navigerar du genom att välja en siffra i menyn nedan:");
    Console.WriteLine("0. Avsluta");
    Console.WriteLine("1. Vad kostar det att gå på bio");

    string? input = Console.ReadLine();

        // Checka vilket val som gjorts
        switch (input)
        {
            case "0":
                Environment.Exit(0);
                break;
            case "1":
                CheckTicketPrice("Vänligen ange ålder på besökaren.");
                break;
            default:
                PrintInvalidInput(null);
                break;
        }
}
// Skriv ut biljettpriset för det val som gjorts eller anropa metod för felaktig input.
int CheckTicketPrice(string query)
{
    while (true)
    {
        Console.WriteLine(query);
        string? input = Console.ReadLine();
            if (int.TryParse(input, out int age))
            {
                if (age < 0)
                {
                    PrintInvalidInput("Du kan inte ange ett negativt tal för ålder.");
                    continue;
                }
                if (age < 20)
                {
                    Console.WriteLine("Biljettpris, ungdom: 80 kr");
                    return 80;
                }
                if (age < 65)
                {
                    Console.WriteLine("Biljettpris, vuxen: 120 kr");
                    return 120;
                }
                if (age  > 64)
                {
                    Console.WriteLine("Biljettpris, pensionär: 90 kr");
                    return 90;
                }
            }
            else
            {
                PrintInvalidInput("You need to enter a positive integer!");
            }
    }
}

void PrintInvalidInput(string? errorDescription)
{
    Console.WriteLine($"FEL: {errorDescription ?? ""} Vänligen försök igen!\n");
}