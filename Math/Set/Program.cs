class Set {

	public string set; 
	public string elements;

	public Set() {

		set= "{}";
		elements= ""; 

		}

	public Set(string arg) {

		elements= arg;
		set= "{" + arg + "}";

		}

	public void Remove_Element(string arg) {

		int pos1;

		pos1= this.elements.IndexOf(arg);

		Console.WriteLine(pos1);
	
		}
		
/*
	public Set Remove_Element(int pos) {
	
		int pos1, pos2;
		pos1= this.elements.IndexOf(',');

		}
*/		
	
	public Set Do_PairSet(Set a) {

		Set TEMP= new Set();

		if (this.elements == a.elements) {

			TEMP.elements= this.set;
			TEMP.set= "{" + TEMP.elements + "}";

			}

		else {

			TEMP.elements= a.set + ", " + this.set;
			TEMP.set= "{" + TEMP.elements + "}";

			}
	
		return TEMP;

		}

static void Main(string[] args) {

	Console.WriteLine();
	Console.WriteLine("Section 1: (Constructing Basic Sets)\n");

	Set Empty_Set= new Set();
	Set X= new Set("X");

	Console.WriteLine($"The set, X := {X.set}, ");
	Console.WriteLine($"Has, {X.elements}, as an element\n");
	Console.WriteLine($"We can also generate the empty set, {Empty_Set.set}\n");  

	Console.WriteLine("--------------------------------------------------\n");
	Console.WriteLine("Section 2: (Pair Sets)");
	Console.WriteLine();
	
	Set Y= new Set("Y");

	Console.WriteLine("We can generate pair sets");
	Console.WriteLine($"For example, if we have the sets, X := {X.set} and Y := {Y.set},");
	Console.WriteLine($"then their pair set is the set, XY := {Y.Do_PairSet(X).set} == {X.Do_PairSet(Y).set}");
	Console.WriteLine();
	Console.WriteLine("Using pair sets, we can generate the set of Natural Numbers, N, using only the empty set:");
	Console.WriteLine();
	
	Set N= new Set();
	for (int i= 0; i <=10; i++) {

		Console.WriteLine($"{i} := {N.set}");	
		N= N.Do_PairSet(Empty_Set);

		}

	Console.WriteLine("Section 2a: (Removing Elements from sets)");
	
	Console.WriteLine();

	}

}
