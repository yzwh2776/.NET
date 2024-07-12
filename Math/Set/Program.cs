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

	public Set Remove_Element(Set a) {

		Console.WriteLine($"Doing Remove_Element({a.set})");

		int start_pos;
		int length;	

		start_pos= this.set.IndexOf(a.set);
		length= a.set.Length;

		Console.WriteLine();
		Console.WriteLine($"Start: {start_pos} Length: {length}");
		Console.WriteLine($"Set: {this.set} Elements: {this.elements}");

		try {

			Console.WriteLine("Trying this.set[start_pos + length + 1] == ','");
			if (this.set[start_pos + length + 1] == ',') {
			
				Console.WriteLine("Doing this.set= this.set.Remove(start_pos, length + 2)");
				this.set= this.set.Remove(start_pos, length + 2);
			
				}

			}

		catch (Exception e) {

			Console.WriteLine($"Caught exception: {e}");
			this.set= this.set.Remove(start_pos - 2, length + 2);

			}

		Console.WriteLine($"Element to be Removed: {a.elements}");
		start_pos= this.elements.IndexOf(a.elements);
		length= a.elements.Length;

		Console.WriteLine($"Start: {start_pos} Length: {length}");

		try {

			if (this.elements[start_pos + length + 1] == ',') {

				this.elements= this.elements.Remove(start_pos, length + 2);

				}

			}

		catch {

			this.elements= this.elements.Remove(start_pos - 2, length + 2);

			}

		Console.WriteLine($"Set: {this.set} Elements: {this.elements}");
		return this;

		}
		
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

	public static Set Get_NaturalNumbers(int n) {
		
		Set Empty_Set= new Set();
		Set N= new Set();
		for (int i= 0; i <= n; i++) {

			Console.WriteLine($"{i} := {N.set}");	
			N= N.Do_PairSet(Empty_Set);

			}

		return N;

		}

	public static Set Get_Number(int n) {

		Set Empty_Set= new Set();
		Set N= new Set();
		for (int i= 0; i < n; i++) {

			N= N.Do_PairSet(Empty_Set);

			}

		return N;

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

	Set.Get_NaturalNumbers(10);	
	Console.WriteLine();

	Console.WriteLine(Set.Get_Number(3).set);

	Console.WriteLine();
	Console.WriteLine("Section 2a: (Removing Elements from sets)");
	Console.WriteLine();

	Set Hello= new Set("Hello");
	Set World= new Set("World!");
	Set Hello_World= World.Do_PairSet(Hello);
	Console.Write("Expected: {{Hello}, {World!}}");
	Console.WriteLine($" Actual: {Hello_World.set}");	

	Hello_World= Hello_World.Remove_Element(World);
	Console.Write("Expected: {{Hello}}");
	Console.WriteLine($" Actual: {Hello_World.set}");

	Hello_World= World.Do_PairSet(Hello_World);
	Console.Write("Expected: {{Hello}, {World!}}");
	Console.WriteLine($" Actual: {Hello_World.set}");	
	
	Hello_World= Hello_World.Remove_Element(Hello);
	Console.Write("Expected: {{World!}}");
	Console.WriteLine($" Actual: {Hello_World.set}");



	
	
	Console.WriteLine();

	}

}
