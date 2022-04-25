let calculateWordScore (word: string) : int =
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

        //For Comprehension
let recommendationFeedComprehension (books : Book[]) = [ 
    for book in books do
        for author in book.authors do
            for movie in bookAdaptations(author) do
                yield $"You may like {movie.title} because you liked {book.title} from {author}" 
    ];;

type Point(x: int, y : int) =
    member this.x = x
    member this.y = y

type Point3D(x: int, y : int, z: int) =
    member this.x = x
    member this.y = y
    member this.z = z

let pointLocation (xs,ys) = [
    for x in xs do
        for y in ys do
            yield Point(x,y)
    ];;

let point3DLocation (xs,ys,zs) = [
    for x in xs do
        for y in ys do
            for z in zs do
                yield Point3D(x,y,z)
    ];;

let isInside(point : Point, radius : int) =
    radius * radius >= point.x * point.x + point.y * point.y

let pointFilter (point: Point, r:int) : Point[] =
    if(isInside(point,r)) then [|point|] else [||]

let pointsInRadius(radiuses : int[], points : Point[]) = [
    for radius in radiuses do
        for point in points do
            for s in pointFilter(point, radius) do
                yield $"Point({s.x}, {s.y}) is within a radius of {radius}"
    ];;


//Error Handling
type TVShow(title: string, startYear : int, endYear: int) =
    member this.title = title
    member this.startYear = startYear
    member this.endYear = endYear

let shows = [| TVShow("Breaking Bad", 2008, 2013); TVShow("The Wire", 2002, 2008); TVShow("Mad Men", 2007, 2015)|];;
let rawShows = [| "Breaking Bad (2008-2013)"; "The Wire, (2002-2008)"; "Mad Men, (2007-2015)"|];;

let sortShows(shows : TVShow[]) : TVShow[] =
    Array.sortByDescending(fun (x) ->  x.endYear - x.startYear) shows

let extractStartYear (rawShow : string) : Option<int> =
    let bracketOpen = rawShow.IndexOf('(')
    let dash = rawShow.IndexOf('-')

    if(bracketOpen <> -1 && dash > bracketOpen + 1) then Some(rawShow.Substring(bracketOpen + 1, 4) |> int)
    else None

let extractName (rawShow : string) : Option<string> =
    let bracketOpen = rawShow.IndexOf('(')
    if bracketOpen > 0 then Some(rawShow.Substring(0, bracketOpen).Trim())
    else None

let extractEndYear (rawShow : string) : Option<int> =
    let bracketClose = rawShow.IndexOf('(')
    let dash = rawShow.IndexOf('-')

    if(dash <> -1 && bracketClose > dash + 1) then Some(rawShow.Substring(dash + 1, 4) |> int)
    else None



let parseShow(show : string) : Option<TVShow> =
    let name = extractName show
    let endYear = extractEndYear show
    let startYEar = extractStartYear show
    match name && endYear && startYEar with
    | Some -> TVShow(name,startYEar, endYear)
    | None

    
let parseShows(rawShows : string[]) : TVShow[] =
    //Array.map(fun show -> parseShow(show)) rawShows
    null
//Error Handling



//Classes

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
    
