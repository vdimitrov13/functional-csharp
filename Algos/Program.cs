namespace Algos
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            //CalculateTipExercise();
            //ImmutableListExercise();
            //AbbreviateExercise();
            //ListImmutabilityExercise();
            //RankedWordsExercise();

            ;

        }

        private static void RankedWordsExercise()
        {
            var words = ImmutableList.Create<string>
            (   "ada",
                "haskell",
                "scala",
                "java",
                "rust"
            );
            var rankedWords = RankWordsByScore(words, CalculateWordScore);

            var rankedWordsWithBonus = RankWordsByScore(words, (x) =>
                CalculateWordScore(x) +
                CalculateWordBonus(x))
            ;

            var rankedWordsWithBonusAndPenalty = RankWordsByScore(words, (x) => 
                CalculateWordScore(x) + 
                CalculateWordBonus(x) + 
                CalculateWordPenalty(x));
            ;

        }

        private static ImmutableList<string> RankWordsByScore(ImmutableList<string> words, Func<string, int> scoreCalculator)
        {
            var rankedWords = words.OrderByDescending(x => scoreCalculator(x)).ToImmutableList();
            return rankedWords;
        }

        private static int CalculateWordPenalty(string word)
        {
            return word.Contains('s') ? -7 : 0;
        }

        private static int CalculateWordBonus(string word)
        {
            return word.Contains('c') ? 5 : 0;
        }

        private static int CalculateWordScore(string word)
        {
            return word.Replace("a", "").Length;
        }

        private static void ListImmutabilityExercise()
        {
            var inputList = ImmutableList.Create<string>("a", "b", "c", "d");
            var inputString = "f";

            var firstTwo = ReturnFirstTwo(inputList);
            var lastTwo = ReturnLastTwo(inputList);
            var movedToEnd = MoveFirstTwoToEnd(inputList);
            var insertedBeforeLast = InsertBeforeLast(inputList, inputString);
            ;
        }

        private static ImmutableList<string> InsertBeforeLast(ImmutableList<string> inputList, string inputString)
        {
            var last = inputList.IndexOf(inputList.LastOrDefault());
            var insertedList = inputList.Insert(last, inputString);

            return insertedList;
        }

        private static ImmutableList<string> MoveFirstTwoToEnd(ImmutableList<string> inputList)
        {
            var firstTwo = ReturnFirstTwo(inputList);
            var switchedPlaceList = inputList.RemoveRange(firstTwo).AddRange(firstTwo);

            return switchedPlaceList;
        }

        private static ImmutableList<string> ReturnLastTwo(ImmutableList<string> inputList)
        {
            return inputList.TakeLast(2).ToImmutableList();
        }

        private static ImmutableList<string> ReturnFirstTwo(ImmutableList<string> inputList)
        {
            return inputList.Take(2).ToImmutableList();
        }

        private static void CalculateTipExercise()
        {
            var people = new List<string>() { "Ivan", "Dragan", "Pesho" };

            var tip = CalculateTip(people);
        }

        private static void AbbreviateExercise()
        {
            var name = "Alonzo Church";

            Console.WriteLine(Abbreviate(name));
            Console.WriteLine(name);
        }

        private static string Abbreviate(string name)
        {
            var firstNameAbbreviated = name.Substring(0, 1) + ". " + name.Substring(name.IndexOf(' ') + 1);

            return firstNameAbbreviated.ToString();
        }

        private static void ImmutableListExercise()
        {
            var allLaps = ImmutableList.Create<double>(31.0, 20.9, 21.1, 21.3);

            var lapTime = TotalTime(allLaps, RemoveFirstLap);
            var avgLapTime = AverageTime(allLaps, RemoveFirstLap);

            Console.WriteLine(Math.Round(lapTime, 2));
            Console.WriteLine(Math.Round(avgLapTime, 2));
        }

        static double TotalTime(
            ImmutableList<double> lapTimes, 
            Func<ImmutableList<double>, ImmutableList<double>> removeFirstLap)
        { 
            return removeFirstLap(lapTimes).Sum();
        }

        static double AverageTime(
            ImmutableList<double> lapTimes, 
            Func<ImmutableList<double>, ImmutableList<double>> removeFirstLap)
        {
            return removeFirstLap(lapTimes).Average();
        }

        private static ImmutableList<double> RemoveFirstLap(ImmutableList<double> lapTimes)
        {
            return lapTimes.RemoveAt(0);
        }

        static int CalculateTip(List<string> people)
        {
            if (people.Count > 5)
            {
                return 20;
            }
            else if(people.Count > 0)
            {
                return 10;
            }
            return 0;
        }
    }
}
