let calculateWordScore (word: string) =
    word.Replace("a", "").Length;

let calculateBonus (word: string) =
    if word.Contains('c') then 5 else 0

let calculatePenalty (word: string) =
    if word.Contains('s') then 7 else 0

let rankWordsByScore(words : string[], sortingFunction) = 
     Array.sortByDescending(fun (x :string) -> sortingFunction(x)) words