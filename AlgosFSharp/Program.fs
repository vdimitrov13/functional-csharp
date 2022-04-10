﻿let calculateWordScore (word: string) : int =
    word.Replace("a", "").Length

let calculateBonus (word: string) : int =
    if word.Contains('c') then 5 else 0

let calculatePenalty (word: string) : int =
    if word.Contains('s') then 7 else 0

let sortWordsByLength (word: string) : int =
    word.Length


//Classes
type Book(title: string, authors : string[]) =
    member this.title = title
    member this.authors = authors

type Movie(title: string) =
    member this.title = title

let bookAdaptations(author : string) =
    if author = "Tolkien" then [|Movie("An Unexpected Journey"); Movie("The Desolation of Smaug")|] else Array.empty 

let recommendedBooks(friend: string): Book[] = 
    let scala = [|Book("FP in Scala", [|"Chiusano"; "Bjarnason"|]); Book("Get Programming with Scala", [|"Sfregola"|])|]
    let fiction = [|Book("Harry Potter", [|"Rowling"|]); Book("The Lord of the Rings", [|"Tolkien"|])|]
    if friend = "Alice" then scala elif friend = "Bob" then fiction else Array.empty


let friends = [|"Alice"; "Bob"; "Charlie"|]
let recommendations = 
    friends
    |> Array.collect(fun friend -> recommendedBooks(friend))
    |> Array.collect(fun b -> b.authors)

let books = [|Book("FP in Scala", [|"Chiusano"; "Bjarnason"|]); Book("The Hobbit", [|"Tolkien"|])|];;

let movieTitlesByAdaptation = 
    fun books -> Array.collect(fun (book : Book) -> book.authors) books
    >> fun authors -> Array.collect(fun (author : string) -> bookAdaptations(author)) authors
    >> fun movies -> Array.map(fun (movie : Movie) -> $"You may like {movie.title} because you liked ") movies

let recommendationFeed (books : Book[]) =
    Array.collect(
        fun (book : Book) -> 
            Array.collect(
                fun (author : string) -> 
                    Array.map(fun (movie : Movie) -> $"You may like {movie.title} because you liked {book.title} from {author}")(bookAdaptations(author))) book.authors) 
        books

//let evens books =
//    seq { for book in 1 .. books do book.Equals(1) then yield x }
//printf "%A" (evens 10)

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
    