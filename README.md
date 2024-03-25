# Simple Mastermind

This repository contains a simple version of "Mastermind" written in C# .NET Core.

When it boots up, it generates a 4 digit number, with each digit being in an inclusive range from 1-6.
You then enter a 4 digit number of your own, attempting to guess the randomly generated number.
For each digit of your guess that is both correct and in the place, the program will print a `+` sign.
For each digit of your guess that is correct but not in the right place, the program will print a `-` sign.
Note that it does not tell you which digit it printed a `+` or `-` for, it prints all the `+` symbols first, followed
by the `-` symbol. You are given 10 attempts to guess the number based on this output.

For example: say the solution is `1234` and your guess is `4233`. The program will print `++--`.
This is because the 2nd and 3rd digits of your guess match the exact digit of the solution, so it prints
two `+` symbols. The 1st and 4th digits of your guess match digits from the solution, but are not in the
correct position. Notice, even though the solution has one `3` and your guess has two, and one of them
is in the correct position and got a `+`, the second `3` in your guess still got a `-` sign.

## How to Build and/or Run

### Requirements

- .NET Core

### Build

Clone this repository, change directory into it, and run

```bash
dotnet build
```

### Run

Clone this repository, change directory into it, and run

```bash
dotnet run
```
