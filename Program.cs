// See https://aka.ms/new-console-template for more information
Random rnd = new Random();
int[] solution = new int[4];
for (int i = 0; i < solution.Length; i++) {
  solution[i] = rnd.Next(1, 7);
}

int tries = 10;
int attempt = 0;
while (attempt < tries) {
  Console.WriteLine("Input a 4 digit number. Attempts Remaining: " +
                    (tries - attempt));
  string? guess = Console.ReadLine();
  if (string.IsNullOrEmpty(guess)) {
    Console.WriteLine("Invalid Input");
    continue;
  }
  if (guess.Length != 4) {
    Console.WriteLine("Invalid Input");
    continue;
  }
  int[] guessDigits = new int[4];
  for (int j = 0; j < guessDigits.Length; j++) {
    int guessDigit = 0;
    if (int.TryParse(guess.Substring(j, 1), out guessDigit)) {
      guessDigits[j] = guessDigit;
    } else {
      Console.WriteLine("Invalid Input");
      continue;
    }
  }
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
  if (numPlus == 4) {
    Console.WriteLine("You Win!");
    System.Environment.Exit(0);
  } else {
    string output = "";
    for (int i = 0; i < numPlus; i++) {
      output += "+";
    }
    for (int i = 0; i < numMinus; i++) {
      output += "-";
    }
    Console.WriteLine(output);
  }
  attempt++;
}

Console.WriteLine("Out of Attempts. The Correct Solution was:");
Console.WriteLine(string.Join("", solution));
