class Set {

	public string set; 
	public string elements;

	public Set() {

		Console.WriteLine("\nRUN_Set();");

		set= "{}";
		elements= ""; 

		Console.WriteLine("\n	Generating new Set...");
		Console.WriteLine("	Successfully created new set!");
		Console.WriteLine($"\nPRINT_Set();\n{this.set};");

		}

	public Set(string arg) {

		Console.WriteLine($"\nRUN_Set(string \"{arg}\");");

		elements= arg;
		set= "{" + arg + "}";

		Console.WriteLine("\n	Generating new Set...");
		Console.WriteLine("	Successfully created new set!");
		Console.WriteLine($"\nPRINT_Set();\n{this.set};");

		}

	public Set Remove_Element(Set a) {

		Console.WriteLine();
		Console.WriteLine($"RUN_Remove_Element();");

		Console.WriteLine($"\n	Running Remove_Element()...");

		int start_pos;
		int length;	

		start_pos= this.set.IndexOf(a.set);
		length= a.set.Length;

		Console.WriteLine($"	Attempting to remove {a.set} from {this.set}...");

		try {

			if (this.set[start_pos + length + 1] == ',') {
			
				this.set= this.set.Remove(start_pos, length + 2);
			
				Console.WriteLine($"	Successfully removed {a.set} from {this.set}.");
				Console.WriteLine($"\nPRINT_Set();\n{this.set}");
			
				}

			}

		catch (Exception e) {

			this.set= this.set.Remove(start_pos - 2, length + 2);

			Console.WriteLine($"	Successfully removed {a.set} from {this.set}.");
			Console.WriteLine($"\nPRINT_Set();\n{this.set}");

			}

		start_pos= this.elements.IndexOf(a.elements);
		length= a.elements.Length;

		Console.WriteLine($"	Validating contents of {this.set}...");

		try {

			if (this.elements[start_pos + length + 1] == ',') {

				this.elements= this.elements.Remove(start_pos, length + 2);
				Console.WriteLine($"\nPRINT_Elements();\n{this.elements}");

				}

			}

		catch {

			this.elements= this.elements.Remove(start_pos - 2, length + 2);
			Console.WriteLine($"\nPRINT_Elements();\n{this.elements}");

			}

		return this;

		}
		
	public Set Do_PairSet(Set a) {

		Console.WriteLine($"RUN_Do_PairSet();");

		Console.WriteLine("\n	Running Do_PairSet()...");

		Set TEMP= new Set();

		if (this.elements == a.elements) {

			TEMP.elements= this.set;
			TEMP.set= "{" + TEMP.elements + "}";

			}

		else {

			TEMP.elements= a.set + ", " + this.set;
			TEMP.set= "{" + TEMP.elements + "}";

			}

		Console.WriteLine($"\nPRINT_Set();\n{TEMP.set}");
	
		return TEMP;

		}

	public static Set Get_NaturalNumbers(int n) {

		Console.WriteLine();
		Console.WriteLine($"RUN_Get_NaturalNumbers({n});");
		
		Set Empty_Set= new Set();
		Set N= new Set();
		for (int i= 0; i <= n; i++) {

			N= N.Do_PairSet(Empty_Set);

			}

		return N;

		}
/*
	public static Set Get_Number(int n) {

		Console.WriteLine();
		Console.WriteLine($"RUN_Get_Number({n});");

		Set Empty_Set= new Set();
		Set N= new Set();
		for (int i= 0; i < n; i++) {

			N= N.Do_PairSet(Empty_Set);

			}

		return N;

		}
*/

	
static void Main(string[] args) {

	Console.WriteLine("\n				Notes on Sets\n");
	Console.WriteLine("----------------------------------------------------------------------");	

	System.Threading.Thread.Sleep(1000);

	Console.WriteLine();
	Console.WriteLine("	Section 1: Generating Sets");

	Console.WriteLine();
	Console.WriteLine("		\"Sets have two fields; the 'set' and it's 'elements'");
	Console.WriteLine("		We can generate the empty set ('{}') with Set()\"\n");

	Set Empty_Set= new Set();
	Set X= new Set("X");

	Console.WriteLine();
	Console.WriteLine("----------------------------------------------------------------------");	
	Console.WriteLine("\n	Section 2: Pair Sets\n");
	Set Y= new Set("Y");

	Console.WriteLine();
	Console.WriteLine($"		\"{X.set} and {Y.set} are both sets with {X.elements} and {Y.elements} as elements, respectively.");
	Console.WriteLine("		Using Do_PairSet(), we can generate the pair set between two sets:\"");

	Set XY= new Set();
	
	XY= Y.Do_PairSet(X);

	Console.WriteLine();
	Console.WriteLine("		\"Using Set() and Do_PairSet(), we can generate the set of natrual numbers:\"");

	Set.Get_NaturalNumbers(10);	

	Console.WriteLine();
	Console.WriteLine("----------------------------------------------------------------------");	
	Console.WriteLine();
	Console.WriteLine("	Section 3: Removing Elements from sets\n");

	Set Hello= new Set("Hello");
	Set World= new Set("World!");
	Set Hello_World= World.Do_PairSet(Hello);

	Console.WriteLine();
	Console.WriteLine($"		\"We have now three sets {Hello.set}, {World.set}, andtheir pair set {Hello_World.set}");
	Console.WriteLine("		We can use Remove_Element() to remove a specified element from a set.\"");

	Hello_World= Hello_World.Remove_Element(Hello);
	
	


	}

}
