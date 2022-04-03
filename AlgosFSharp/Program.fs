let calculateWordScore (word: string) =
    word.Replace("a", "").Length

let calculateBonus (word: string) =
    if word.Contains('c') then 5 else 0

let calculatePenalty (word: string) =
    if word.Contains('s') then 7 else 0

let sortWordsByLength (word: string) =
    word.Length

let sortWordsByLetterS (word: string) =
    Array.filter(fun (x: char) -> x.Equals('s')) (word.ToCharArray()) 
    |> fun (x) -> (x.Length)

let sortNumbersAscending (numbers: int[]) =
    Array.sortBy(fun (x :int) -> (x)) numbers

let sortNumbersDescending (numbers: int[]) =
    Array.sortByDescending(fun (x :int) -> (x)) numbers

let rankWordsByScore(words : string[], sortingFunction : string -> int) = 
    Array.sortByDescending(fun (x :string) -> sortingFunction(x)) words