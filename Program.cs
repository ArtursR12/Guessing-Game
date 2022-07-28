using System.Linq;
var randomNum = GenerateRandomNum().ToString();
   Console.WriteLine("Please enter your guess:");
for (int i = 0; i < 8; i++) {
    string GuessNumber = Console.ReadLine();
    int checkGuessNumber;
    bool isNumber = int.TryParse(GuessNumber, out checkGuessNumber);
    if (checkGuessNumber <= 0)
    {
        Console.WriteLine("U can guess only positive numbers !");
        continue;
    }
    if (!isNumber)
    {
        Console.WriteLine("U can guess only numbers !");
        continue;
    }
    if (GuessNumber.Length != 4)
    {
        Console.WriteLine("U can write only 4 digit number");
        continue;
    }

    (int correctDigits, int correctPlaces) = CheckDigits(randomNum, GuessNumber);

    if (correctPlaces == 4)
    {
        Console.WriteLine("Congrats, u win ! Play another game ?");

    }

    Console.WriteLine($"M:{correctDigits} P:{correctPlaces}");
 }

static (int, int) CheckDigits(string? randomNum, string guessNumber)
{
    var correctDigit = 0;
    var correctPlace = 0;
    for (int i = 0; i < 4; i++)
    {
        var digit = randomNum[i];
        var guessDigit = guessNumber[i];
        if (guessDigit == digit)
        {
            correctPlace++;
        }
        if (randomNum.Contains(guessDigit))
            correctDigit++;
    }
        return (correctDigit, correctPlace);
}

static int GenerateRandomNum()
{
    // Number of digits for random number to generate
    int randomDigits = 4;
    int max = 9999;
    Random random = new Random();
    int answ = random.Next(0, max);

    while (randomDigits != answ.ToString().ToArray().Distinct().Count())
    {
        answ = random.Next(0, max);
    }
    return answ;
}
