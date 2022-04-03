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

let highScoringWords(words : string[], scoringFunction : string -> int) : int -> string[] = 
    fun (higherThan : int) -> Array.filter(fun (x: string) -> scoringFunction(x) > higherThan) words


let asd : int -> string[] = highScoringWords([|"ada";"hassskell";"scala"; "java";"rust"|], fun (x : string) -> calculateWordScore(x) + calculateBonus(x) - calculatePenalty(x));;


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
    