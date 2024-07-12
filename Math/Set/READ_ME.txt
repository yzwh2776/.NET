
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

Okay! We can sort of arbitrarily generate the natural numbers... I think. We're still using
the '++' operator, but I believe that from the Peano Axioms, the increment operator is 
fundamental. 

Existance of the element relation
Existance of the empty set
Axiom on Pair sets
Axiom on Unions sets
Axiom of replacement
Existance of the power set
Axiom of infinity
Axiom of choice
Axiom of foundation

There are other ways of ordering and naming these axioms, which makes it confusing. I think
it's best to attempt to understand these as a logical system. As of right now, I'm about
as far as I have gotten with these matters. So what is the next step? 

I guess if we have pair sets, we probably want union sets next, since those are different

I.E. 

if x is a set, s.t. x= {0, 1, 2}, and y is a set, s.t. y= {4, 5, 6}, then the set 

	(x u y) := {0, 1, 2, 3, 4, 5}

So we are adding elements of sets to a set here (as opposed to adding sets to sets in pair
sets). It's a small difference since elements of sets are also sets, but there is a subtle
difference.

What about this case: If x is a set, s.t. X= {0, 1, 2}, and Y is a set, s.t. Y= {0, 1, 2},
then the set

	(X U Y) := {0, 1, 2, 0, 1, 2} v {0, 0, 1, 1, 2, 2} v ...

There is an order invoked here isn't there? Interestingly, we could also take the pair set
of the sets X and Y and get:

	{X, Y} := {{0, 1, 2}, {0, 1, 2}} == {{0, 1, 2}} (by definition of pair sets)

So those are two different things. The order is interesting here. Do we want to only 
consider one order? I think it might be more pedagoical to create a method that generates
all ordered pairs. If I remember correctly there should be 2^N unique ordered sets. Yeah
this is most definitely something we want to explore. Let's try and write some code for 
this. 

We might already be invoking an order in Do_PairSet()... Is this something we want to 
consider there? I don't even know how I would do that. Because I think when I compare the 
two strings, the order does matter. So if, for example, I had a string of "{0, 1}" and 
a second string of "{1, 0}", I don't think taking the pair set of those would result in
a new string of "{{0, 1}}" so maybe we need to consider this. Obviously at this point, we 
might need to already invoke the axiom of choice because I don't know anyway around this. 
Or maybe we don't... Are the sets "{0, 1}" and "{1, 0}" the same set? Certainly if we are
not considering the order, those sets are not the same. Okay, so as of right now, we have 
invoked an order, so the order does matter. 

That makes Do_PairSet() still work as we would like it to, however, when we start writing 
a union set function, we will need to consider order, I think we want to somehow display
all possible ordered sets when we get the union set. This is going to be difficult. I
need an algorithm to generate all possible permutations. 

Okay, we have two sets, X and Y, both with elements {0, 1, 2}. How many ordered union sets
can we generate. 

I think it's 2^6 (because we have n= 6 elements in our union set)...But we also only have
3 distinguishable elements.. so maybe its 6!/(6 - 3)!, I don't remember. 

Okay, never mind, we have two sets X = {a, b}, and Y = {c, d}, how many union sets do we 
have. 

X U Y = {a, b, c, d}
	{a, b, d, c}
	{a, c, b, d}
	{a, c, d, b}
	{a, d, b, c}
	{a, d, c, b}
	{b, a, c, d}
	{b, a, d, c}
	{b, c, a, d}
	{b, c, d, a}
	{b, d, a, c}
	{b, d, c, a}
	{c, a, b, d}
	{c, a, d, b}
	{c, b, a, d}
	{c, b, d, a}
	{c, d, a, b}
	{c, d, b, a}
	{d, a, b, c}
	{d, a, c, b}
	{d, b, a, c}
	{d, b, c, a}
	{d, c, a, b}
	{d, c, b, a}

And I think that is all, so how many? there are 24 different perumtations.

I think it might just be 4!, right. 4! = 4 * 3 * 2 * 1 = 24. And that's because we have 
n= 4 elements, and we are choosing 4 elements. So what is a combination then? 

I think a combination would be, from the 24 possible permutations, how many ways can I 
choose an element first. So for our example, there are 6 combinations in which we can
choose a particular element first. 

If we wanted to choose any two elements, there are 2 combinations out of 24 permutations 
that we could choose those elements. 

So it's great that we know these numbers, now how do we implement the union set function?
Given two sets, we want to generate all possible permutations of the union sets between
those two. I think what we'll need to do is deliminate our sets by ',' and then use loops
to generate new sets and reorder them using substrings.

So I just realized that my functions can both take 'Set' objects as parameters, and return
Sets as the return object. I think I need to rewrite my code to make that the case so 
that I'm not working directly with strings, but instead working with set objects. 

We've run into the next issue. I have no idea what the 'static' keyword is or how to use
the 'this' keyword. I think I need to figure those out if I'm hoping to have a set object
that has functions that take sets as parameters and then returns a new set. 

I was doing this before I reworked this, but I was doing it in the function, where I think
I want to do this redefining of set names in the main method instead of in a function. 
 
I want to make a Remove_Element function that takes an integer as a parameter. The idea
is that we can remove an element from a set, by its ordered postion (index) in the set. 
We might also want to be able to remove an element with a string as a parameter also. 

I got the Do_PairSet() function to work, but I'm doing it by updating a created Set object
instead of creating a new Set object. I think I might be able to fix that though.

Everything is back working again, I want to make a Remove_Element() function, but I want it
to work as a 'pop()' function (especially when considering generating natural numbers). 
For example;

	Suppose we have the set X := {{}, {{}, {}}} == 2, and we want to find the
	predecessor set, or the set which generated this set, we would want to return to 
	the set X_-1= {{}} == 1. So how might we do this? 

What if instead of focusing on using the string class, we use our Set object. We might then
want to pass Remove_Element() a Set obj and we will attempt to remove that set, from the 
set calling Remove_Element(). So how can we do this? 

If we know the length of the set (# of characters in the string), then we can use 
IndexOf(string arg) to find the integer index of the starting position of the string, and 
using the length, we can find the ending index. We could then use the Remove() function
to remove all characters between the starting and ending indices. Let's try this.
 
I'm having a hard time figuring out this Remove_Element() function. I could remove sets,
and I could remove elements, but I'm still left with some ', ' that I'm not sure how to 
get rid of or account for.

Let's try to find an example problem:

	Suppose we have a set Hello := {{H}, {E}, {L}, {L}, {O}}.
	If we want to remove the set {E}, we can either remove an additional, 2 characters
	before the start, or 2 chars after the end of the set. 
