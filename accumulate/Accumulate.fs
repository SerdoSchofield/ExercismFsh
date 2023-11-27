module Accumulate

let accumulate (func: 'a -> 'b) (input: 'a list): 'b list = [ for x in input -> func x ]