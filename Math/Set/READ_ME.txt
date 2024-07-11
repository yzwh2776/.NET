
Our goal here is to use strings to somehow define the natural numbers. Since 'int' data-type
is already a class of it's own with defined function on it, we want to start from the very
bottom. The best we can do there, is to work with strings and try to apply the axioms of 
set theory to define the natural numbers. We do still have access to loops and logic
statements, but we haven't yet defined the increment operator (++). 

Do we want a class of sets? Or do we want a class of natural numbers... So I guess we 
probably want a class for both. We want to define a class of sets that have all the 
properties of sets, and using our set class, we can then define the natural numbers using
sets and their properites. So we need to figure out how to define a set. 

So I guess we need to agree on a notation, which I believe would be closed pairs of '{}'
brackets denote a set, while commas ',' denote elements of that set. 

I.E. {} is a set with no elements (the empty set)

{1, 1, 1} is the set containing the elemnts 1 and 1 and 1 and (whatever '1' is, we don't
know yet). 

{{}, {{}}, {}} is the set containing the elements {} (empty set) and {} (empty set) and
{{}} (the set containing the empty set). 

I guess the questions is, do we want do deal with the case that we might have random text
inbetween closed brackets? 

I.E. {asdjh,<>M!#)*Y!,{}WSDJG{SDGJ}}

Obviously this doesn't look much like a set. The element {}WSDJB{SDGJ} doens't look like
it is in the correct form of an element, does it? Or simpler, {{}, {}, {} {}}, is not a
set? I don't think. There is also a question of order at some point. 

I do think we should be able to handle these cases if our definition is worth anything. So
even though we might have an axiomatic system of the properties of set, we also need to
handle a lot of the 'user-error' cases, and that's where this is going to get tricky.

So I guess out set class has elements, right? So;

class Set {

	public string elements;

	}

I think that's all... Set's only have elements, nothing more. And any element of a set is
also, itself, a set. (This is going to get so confusing). Well a set can have multiple
elements.. so how do we handle that? I guess something like this:

If I recall correctly:

	{{},{}] := {{}} (by the union set axiom) 
	
So here's the new issue we're facing. We actually need all of these sets to be their own
set... Which I'm not sure how to do. 


0 := {}
1 := {{}} := {{},{}} == {0}
2 := {{},{{}}} == {0, 1} {0, {0}}
3 := {{}, {{},{{}}}} == {0, 2} == {0, {0, 1}} == {0, {0, {0}}}
4 := {{}, {{}, {{}, {{}}}}} == {0, 3} == {0, {0, 2}} == {0, {0, {0, 1}}} == {0. {0, {0, {0}}}}

Hmm, okay, we have an algorithm here. This is good. This is very good. Lets see if I can
program this. 

Okay, neat, this all works well, I think. I'm not quite sure how it works with things
other than 'sets' but at least for sets, everything works.
