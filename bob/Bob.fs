module Bob

open System.Text.RegularExpressions

//Bob is a lackadaisical teenager. In conversation, his responses are very limited.
//Bob answers 'Sure.' if you ask him a question, such as "How are you?".
//He answers 'Whoa, chill out!' if you YELL AT HIM (in all capitals).
//He answers 'Calm down, I know what I'm doing!' if you yell a question at him.
//He says 'Fine. Be that way!' if you address him without actually saying anything.
//He answers 'Whatever.' to anything else.
//Bob's conversational partner is a purist when it comes to written communication and always follows normal rules regarding sentence punctuation in English.

let response (input: string): string = 
    match input with 
    | _ when Regex.IsMatch(input.Trim(), @"[A-Z]") && not (Regex.IsMatch(input, @"[a-z]")) -> 
        if input.EndsWith("?") then "Calm down, I know what I'm doing!" else "Whoa, chill out!"
    | _ when Regex.IsMatch(input.Trim(), @"\?$") -> "Sure."
    | _ when Regex.IsMatch(input, @"^\s*$") -> "Fine. Be that way!"
    | _ -> "Whatever."