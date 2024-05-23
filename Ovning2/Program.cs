// Övning 2

// Skriv ut huvudmenyn med de olika valen
while (true)
{
    Console.WriteLine("Välkommen! \nHär på huvudmenyn navigerar du genom att välja en siffra i menyn nedan:");
    Console.WriteLine("0. Avsluta");
    Console.WriteLine("1. Biobiljett - pris per person");
    Console.WriteLine("2. Biobiljett - pris för ett sällskap ");

    string? input = Console.ReadLine();

    // Checka vilket val som gjorts
    switch (input)
    {
        case "0":
            Environment.Exit(0);
            break;
        case "1":
            CheckTicketPrice(true, "Vänligen ange ålder på besökaren:");
            break;
        case "2":
            // CheckGroupPrice();
            break;
        default:
            PrintInvalidInput(null);
            break;
    }
}
// Skriv ut biljettpriset för det val som gjorts eller anropa metod för felaktig input.
int CheckTicketPrice(Boolean check, string query)
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
                if (check) {
                    Console.WriteLine("Biljettpris, ungdom: 80 kr");
                }
                return 80;
            }
            if (age < 65)
            {
                if (check) {
                    Console.WriteLine("Biljettpris, vuxen: 120 kr");
                }
                return 120;
            }
            if (age > 64)
            {
                if (check) {
                    Console.WriteLine("Biljettpris, pensionär: 90 kr");
                }
                return 90;
            }
        }
        else
        {
            PrintInvalidInput("You need to enter a positive integer!");
        }
    }
}
// Skriv ut biljettpriset för en vald grupp.
void CheckGroupPrice()
{
    int groupPrice = 0;
    while (true)
    {
        Console.WriteLine("Ange antal besökare i gruppen:");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int groupSize))
        {
            if (groupSize < 1)
            {
                PrintInvalidInput("Vänligen ange ett tal högre än 0.");
                continue;
            }

            for (int i = 0; i < groupSize; i++)
            {
                groupPrice += CheckTicketPrice(false, $"Ange ålder för besökare {i + 1}");
            }
        }

        Console.WriteLine($"Number of people in the group: {groupSize}");
        Console.WriteLine($"Cost for the whole group: {groupPrice}");
        break;
    }
}

// Skriv ut felmeddelande.
void PrintInvalidInput(string? errorDescription)
{
    Console.WriteLine($"FEL: {errorDescription ?? ""} Vänligen försök igen!\n");
}