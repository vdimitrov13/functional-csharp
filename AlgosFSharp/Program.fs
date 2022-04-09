let calculateWordScore (word: string) : int =
    word.Replace("a", "").Length

let calculateBonus (word: string) : int =
    if word.Contains('c') then 5 else 0

let calculatePenalty (word: string) : int =
    if word.Contains('s') then 7 else 0

let sortWordsByLength (word: string) : int =
    word.Length


//Map
let getLengthsOfStrings (strings: string[], getLength : string -> int) : int[] =
    Array.map(fun (x :string) ->  getLength(x)) strings

let getNumberOfSInString(strings: string[], getNumberofS : string -> int) : int[] =
    Array.map(fun (x :string) ->  getNumberofS(x)) strings

let rankWordsByScore(words : string[], scoringFunction : string -> int) : string[] = 
    Array.sortByDescending(fun (x :string) -> scoringFunction(x)) words

let getWordScores(words : string[], scoringFunction : string -> int) : int[] = 
    Array.map(fun (x :string) -> scoringFunction(x)) words

let mapNumbers (numbers: int[], mappingFunction) : int [] =
    Array.map(fun (x : int) -> mappingFunction(x)) numbers
//Map

//Fold
let accumulateScore(words : string[], scoreWord : string -> int) : int =
    words |> Array.fold(fun total word -> total + scoreWord(word)) 0

let accumulate(numbers : int[]) : int =
    numbers |> Array.fold(fun total number -> total + number) 0

let totalLength(words : string[]) : int =
    words |> Array.fold(fun total word -> total + word.Length) 0

let totalOccurencesOfLetter(words : string[])(getNumberOfLetterInWord : string -> char -> int)(letter : char) : int =
    words |> Array.fold(fun total word -> total + getNumberOfLetterInWord(word)(letter)) 0

let returnMaximumNum(numbers: int[]) =
    numbers |> Array.fold(fun total number -> if number > total then number else total) 0
//Fold


//Filter
let getNumberOfLetterInWord (word: string)(letter : char) : int =
    Array.filter(fun (x: char) -> x.Equals(letter)) (word.ToCharArray())
    |> Seq.length

let highScoringWords(calculateScore : string -> int) : int -> string[] -> string[] = 
    fun (higherThan) -> 
    fun (words) -> 
    Array.filter(fun (x: string) -> calculateScore(x) > higherThan) words

let highScoringWordsAnotherSyntax(calculateScore : string -> int)(higherThan: int)(words: string[] : string[]) = 
    Array.filter(fun (x: string) -> calculateScore(x) > higherThan) words

let higherThanSome(numbers : int[]) : int -> int [] = 
    fun(higherThan : int) -> Array.filter(fun (x: int) -> (x > higherThan)) numbers

let divisibleBySome(numbers : int[]) : int -> int [] = 
    fun(divideBy : int) -> Array.filter(fun (x: int) -> (x % divideBy = 0)) numbers

let shorterThanSome(words : string[]) : int -> string[] =
    fun(shorterThan : int) -> Array.filter(fun (x : string) -> (x.Length < shorterThan)) words

let haveMoreSThanSome(words : string[], numberOfSInWord : string -> int) : int -> string[] =
    fun(numberOfS : int) -> Array.filter(fun (x : string) -> (numberOfSInWord(x) > numberOfS)) words

let filterWords(words : string[], filteringFunction) : string[]= 
    Array.filter(fun (x: string) -> filteringFunction(x)) words

let isWordShorterThanFive(word : string) : bool = 
    word.Length < 5

let getWordsWithMoreThanTwoS(words : string[], filteringFunction : string -> int) : string[]= 
    Array.filter(fun (x: string) -> filteringFunction(x) > 2) words

let onlyOddNumbers(numbers : int []) : int [] =
    Array.filter(fun (x: int) -> (x % 2 = 1)) numbers

let largerThanFour(numbers : int []) : int [] =
    Array.filter(fun (x: int) -> (x > 4)) numbers

//Filter


let negateNumberValue (number: int) : int =
    -number

let doubleNumberValue (number: int) : int =
    number*2

let sortNumbersAscending (numbers: int[]) : int[] =
    Array.sortBy(fun (x :int) -> (x)) numbers

let sortNumbersDescending (numbers: int[]) : int[] =
    Array.sortByDescending(fun (x :int) -> (x)) numbers
    