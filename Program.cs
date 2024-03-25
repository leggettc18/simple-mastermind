internal class Program {
  private static int[]? TryParseInput() {
    string? guess = Console.ReadLine();
    if (string.IsNullOrEmpty(guess)) {
      Console.WriteLine("Invalid Input. Please enter a 4 digit number.");
      return null;
    }
    if (guess.Length != 4) {
      Console.WriteLine("Invalid Input Length, please enter a 4 digit number.");
      return null;
    }
    int[] guessDigits = new int[4];
    for (int j = 0; j < guessDigits.Length; j++) {
      int guessDigit = 0;
      if (int.TryParse(guess.Substring(j, 1), out guessDigit)) {
        if (guessDigit < 1 || guessDigit > 6) {
          Console.WriteLine(
              "Invalid Input. Please enter 4 digits between 1 and 6");
          return null;
        }
        guessDigits[j] = guessDigit;
      } else {
        Console.WriteLine("Unable to parse input, please try again.");
        return null;
      }
    }
    return guessDigits;
  }

  private static string GenerateOutput(int[] guessDigits, int[] solution,
                                       out bool won) {
    int numPlus = 0;
    int numMinus = 0;
    for (int i = 0; i < guessDigits.Length; i++) {
      if (guessDigits[i] == solution[i]) {
        numPlus++;
        continue;
      } else {
        for (int j = 0; j < solution.Length; j++) {
          if (guessDigits[i] == solution[j]) {
            numMinus++;
            break;
          }
        }
      }
    }
    string output = "";
    if (numPlus == 4) {
      output = "You Win";
      won = true;
    } else {
      won = false;
      for (int i = 0; i < numPlus; i++) {
        output += "+";
      }
      for (int i = 0; i < numMinus; i++) {
        output += "-";
      }
    }
    return output;
  }

  private static void Main(string[] args) {
    Random rnd = new Random();
    int[] solution = new int[4];
    for (int i = 0; i < solution.Length; i++) {
      solution[i] = rnd.Next(1, 7);
    }

    int tries = 10;
    int attempt = 0;
    while (attempt < tries) {
      Console.WriteLine("Input a 4 digit number with digits between 1 and 6. " +
                        "Attempts Remaining: " + (tries - attempt));
      int[]? guessDigits = TryParseInput();
      if (guessDigits == null) {
        continue;
      }
      bool won = false;
      string output = GenerateOutput(guessDigits, solution, out won);
      Console.WriteLine(output);
      if (won) {
        System.Environment.Exit(0);
      }
      attempt++;
    }

    Console.WriteLine("Out of Attempts. The Correct Solution was:");
    Console.WriteLine(string.Join("", solution));
  }
}
