(7/17) 

I want to start a new project since I'm completely burnt out from working on Set theory. I
think I want to look into graphing on the terminal again. We know that every mathematical 
function can be generated from the increment operator and that a function is a map between
two sets. We also know that the set of natural numbers can be generated from the first
three axioms (Existance of Element Relation, Existance of the Empty Set, Axiom on Pair 
Sets). 

Example: 
	
Consider the expression (2 + 3), which we might also write as +(2,3) (so as not to
forget that addition is a map). The element in the first slow (2) is what I'll call our
'base value', and the element in the second slow (3) is the number of application of the
increment operator (or we could call it the successor map, ++(2)). 

So if we apply the successor map 3 times, starting at our base value, 2, we arrive at 
the set 5!

We can clearly see that the increment operator is just an application of the first three
axioms!

++(x) := Pair_Set(Empty_Set, x)

Asside:

A function is a special type of relation where each element of the domain is assigned a 
unique element of the range. I'm not sure if this is true, but I think a map is just another
term for a relation (a map takes you from one set to another set by a prescribed method?).

"... I hate all of this so much! Why does something so simple have to be so incredibly 
difficult." 

So the increment operator is not a relation because it doesn't relation elements of two 
sets. It is a method for generating new sets, and if repeated to infinity (assuming the 
Axiom of infinity), we construct the set of natural numbers. 

From this set of natural numbers we can define relations between elements of the set. 

Remark: ...Something about cartesian product? 

So the addition relation/map is a function from the cartesian product (N x N) to (N). In
symbols: N x N -> N. 

If x,y,z are elements of N, then we might write ++(x,y) := z, where x is the 'base-value',
y is the number of application of the increment operator to x, and z is the resulting set.
We could check that this definition is communative (++(x,y) == ++(y,x)), associative 
((++(x,++(y,z)) == (++(++(x,y), z))), and contains a neutral element (++(x,0) == x). 

"My head hurts from this... I have no idea how any of this helps us. I'm just repeating the
same things I've done time and time again. I might need to revist the Schuller lectures and
hit my head against the wall another time." 








	
