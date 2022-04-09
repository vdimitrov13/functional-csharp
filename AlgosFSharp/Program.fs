let calculateWordScore (word: string) : int =
    word.Replace("a", "").Length

let calculateBonus (word: string) : int =
    if word.Contains('c') then 5 else 0

let calculatePenalty (word: string) : int =
    if word.Contains('s') then 7 else 0

let sortWordsByLength (word: string) : int =
    word.Length

let getNumberOfSInWord (word: string) : int =
    Array.filter(fun (x: char) -> x.Equals('s')) (word.ToCharArray()) 
    |> fun (x) -> (x.Length)

let getLengthsOfStrings (strings: string[], getLength : string -> int) : int[] =
    Array.map(fun (x :string) ->  getLength(x)) strings

let getNumberOfSInString(strings: string[], getNumberofS : string -> int) : int[] =
    Array.map(fun (x :string) ->  getNumberofS(x)) strings

let rankWordsByScore(words : string[], scoringFunction : string -> int) : string[] = 
    Array.sortByDescending(fun (x :string) -> scoringFunction(x)) words

let getWordScores(words : string[], scoringFunction : string -> int) : int[] = 
    Array.map(fun (x :string) -> scoringFunction(x)) words


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




let negateNumberValue (number: int) : int =
    -number

let doubleNumberValue (number: int) : int =
    number*2

let mapNumbers (numbers: int[], mappingFunction) : int [] =
    Array.map(fun (x : int) -> mappingFunction(x)) numbers

let sortNumbersAscending (numbers: int[]) : int[] =
    Array.sortBy(fun (x :int) -> (x)) numbers

let sortNumbersDescending (numbers: int[]) : int[] =
    Array.sortByDescending(fun (x :int) -> (x)) numbers
    