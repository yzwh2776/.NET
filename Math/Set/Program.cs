class Text {
	
	public static void PRINT(string text) {

		char[] chars= text.ToCharArray();

		for (int i= 0; i < text.Length; i++) {

			Console.Write(chars[i]);
			System.Threading.Thread.Sleep(25);

			}

		Console.WriteLine();
		System.Threading.Thread.Sleep(250);

		}

	public static void COMMAND(string text) {

		char[] chars= text.ToCharArray();

		for (int i= 0; i < text.Length; i++) {

			Console.Write(chars[i]);
			System.Threading.Thread.Sleep(20);

			}

		Console.WriteLine();
		System.Threading.Thread.Sleep(300);

		}

	}
	
class Set {

	public string set; 
	public string elements;

	public Set() {

		Text.COMMAND("\nRUN_Set();");

		set= "{}";
		elements= ""; 

		Text.PRINT("\n	Generating new Set...");
		Text.PRINT("	Successfully created new set!");
		Text.COMMAND($"\nPRINT_Set();");
		Text.COMMAND($"{this.set};");

		}

	public Set(string arg) {

		Text.COMMAND($"\nRUN_Set(string \"{arg}\");");

		elements= arg;
		set= "{" + arg + "}";

		Text.PRINT("\n	Generating new Set...");
		Text.PRINT("	Successfully created new set!");
		Text.COMMAND($"\nPRINT_Set();");
		Text.COMMAND($"{this.set};");

		}

	public Set Remove_Element(Set a) {

		Text.COMMAND($"RUN_Remove_Element();");

		Text.PRINT($"\n	Running Remove_Element()...");

		int start_pos;
		int length;	

		start_pos= this.set.IndexOf(a.set);
		length= a.set.Length;

		Text.PRINT($"	Attempting to remove {a.set} from {this.set}...");

		try {

			if (this.set[start_pos + length + 1] == ',') {
			
				this.set= this.set.Remove(start_pos, length + 2);
			
				Text.PRINT($"	Successfully removed {a.set} from {this.set}.");
				Text.COMMAND($"\nPRINT_Set();");
				Text.COMMAND($"{this.set}");
			
				}

			}

		catch {

			this.set= this.set.Remove(start_pos - 2, length + 2);

			Text.PRINT($"	Successfully removed {a.set} from {this.set}.");
			Text.COMMAND($"PRINT_Set();");
			Text.COMMAND($"{this.set}");

			}

		start_pos= this.elements.IndexOf(a.elements);
		length= a.elements.Length;

		Text.PRINT($"	Validating contents of {this.set}...");

		try {

			if (this.elements[start_pos + length + 1] == ',') {

				this.elements= this.elements.Remove(start_pos, length + 2);
				Text.COMMAND($"\nPRINT_Elements();");
				Text.COMMAND($"{this.elements}");

				}

			}

		catch {

			this.elements= this.elements.Remove(start_pos - 2, length + 2);
			Text.COMMAND($"\nPRINT_Elements();");
			Text.COMMAND($"{this.elements}");

			}

		return this;

		}
		
	public Set Do_PairSet(Set a) {

		Text.COMMAND($"\nRUN_Do_PairSet();");

		Text.PRINT("\n	Running Do_PairSet()...");

		Set TEMP= new Set();

		if (this.elements == a.elements) {

			TEMP.elements= this.set;
			TEMP.set= "{" + TEMP.elements + "}";

			}

		else {

			TEMP.elements= a.set + ", " + this.set;
			TEMP.set= "{" + TEMP.elements + "}";

			}

		Text.COMMAND($"\nPRINT_Set();");
		Text.COMMAND($"{TEMP.set}");
	
		return TEMP;

		}

	public static Set Get_NaturalNumbers(int n) {

		Text.COMMAND($"\nRUN_Get_NaturalNumbers({n});");
		
		Set Empty_Set= new Set();
		Set N= new Set();
		for (int i= 0; i <= n; i++) {

			N= N.Do_PairSet(Empty_Set);

			}

		return N;

		}

class NOTES() {

		public static 
		Text.PRINT("\n				Notes on Sets\n");

		Text.PRINT("\n		Table of Contents:");
		Text.PRINT("\n	Section 1: Generating Sets");
		Text.PRINT("\n	Section 2: Pair Sets");
		Text.PRINT("\n	Section 3: Removing Element From Sets\n");
		Text.PRINT("\nEnter section number <#>, or press <enter> to continue...");

		switch (Console.ReadKey().key) {

		Case ConsoleKey.Enter:

			while(console.ReadKey().Key != ConsoleKey.Enter) {

			Console.WriteLine("----------------------------------------------------------------------");	


			Text.PRINT("	Section 1: Generating Sets");

			Text.PRINT("\n		We can generate the empty set ('{}') with Set()\"\n");

			Set Empty_Set= new Set();
			Set X= new Set("X");

				}

			}

		Console.WriteLine("----------------------------------------------------------------------");	
		Text.PRINT("\n	Section 2: Pair Sets\n");
		Set Y= new Set("Y");

		Text.PRINT($"		\"{X.set} and {Y.set} are both sets with {X.elements} and {Y.elements} as elements, respectively.");
		Text.PRINT("		Using Do_PairSet(), we can generate the pair set between two sets:\"");

		Set XY= new Set();
		
		XY= Y.Do_PairSet(X);

		Text.PRINT("		\"Using Set() and Do_PairSet(), we can generate the set of natrual numbers:\"");

		Set.Get_NaturalNumbers(10);	

		Console.WriteLine("----------------------------------------------------------------------");	
		Text.PRINT("	Section 3: Removing Elements From Sets\n");

		Set Hello= new Set("Hello");
		Set World= new Set("World!");
		Set Hello_World= World.Do_PairSet(Hello);

		Text.PRINT($"		\"We have now three sets {Hello.set}, {World.set}, andtheir pair set {Hello_World.set}");
		Text.PRINT("		We can use Remove_Element() to remove a specified element from a set.\"");

		Hello_World= Hello_World.Remove_Element(Hello);
	
	}		
	
static void Main(string[] args) {

	Set.NOTES();

	}

}
