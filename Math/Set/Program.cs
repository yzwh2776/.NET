using System.IO;

class Text {
	
	public static void PRINT(string text) {

		char[] chars= text.ToCharArray();

		for (int i= 0; i < text.Length; i++) {

			Console.Write(chars[i]);
			System.Threading.Thread.Sleep(30);

			}

		Console.WriteLine();
		System.Threading.Thread.Sleep(300);

		}

	public static void COMMAND(string text) {

		char[] chars= text.ToCharArray();

		for (int i= 0; i < text.Length; i++) {

			Console.Write(chars[i]);
			System.Threading.Thread.Sleep(10);

			}

		Console.WriteLine();
		System.Threading.Thread.Sleep(200);

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
		Text.COMMAND($"{this.set}");

		}

	public Set(string arg) {

		Text.COMMAND($"\nRUN_Set(string \"{arg}\");");

		elements= arg;
		set= "{" + arg + "}";

		Text.PRINT("\n	Generating new Set...");
		Text.PRINT("	Successfully created new set!");
		Text.COMMAND($"\nPRINT_Set();");
		Text.COMMAND($"{this.set}");

		}

	public Set Remove_Element(Set a) {

		Text.COMMAND($"\nRUN_Remove_Element();");

		Text.PRINT($"\n	Running Remove_Element()...");

		int start_pos;
		int length;	

		start_pos= this.set.IndexOf(a.set);
		length= a.set.Length;

		Text.PRINT($"	Attempting to remove {a.set} from {this.set}...");
		
		try {

			Text.PRINT("	Trying...");
			Text.PRINT($"	Removing {this.set.Substring(start_pos, length)}...");
			this.set= this.set.Remove(start_pos, length + 2);
		
			Text.PRINT($"	Successfully removed {a.set}!");
			Text.COMMAND($"\nPRINT_Set();");
			Text.COMMAND($"{this.set}");
		
			}

		catch {

			Text.PRINT("	Caught Exception!");
			Text.PRINT($"	Removing {this.set.Substring(start_pos, length)}...");
			this.set= this.set.Remove(start_pos - 2, length + 2);

			Text.PRINT($"	Successfully removed {a.set}!");
			Text.COMMAND($"\nPRINT_Set();");
			Text.COMMAND($"{this.set}");
			
			}

		finally {	

			start_pos= this.elements.IndexOf(a.elements);
			length= a.elements.Length;
	
			Text.PRINT($"\n	Validating contents of {this.set}...");

			try {

				Text.PRINT("	Trying...");
				Text.COMMAND($"	Removing {this.elements.Substring(start_pos - 1, length + 4)}...");
				this.elements= this.elements.Remove(start_pos - 1, length + 4);
				Text.COMMAND($"\nPRINT_Elements();");
				Text.COMMAND($"{this.elements}");

				}
			
			catch {

				Text.PRINT("	Caught Exception!");
				Text.PRINT($"	Removing {this.elements.Substring(start_pos - 1, length + 2)}...");
				this.elements= this.elements.Remove(start_pos - 3, length + 4);
				Text.COMMAND($"\nPRINT_Elements();");
				Text.COMMAND($"{this.elements}");

				}

			}

		Text.PRINT("\n	Contents validated!");
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
		Text.PRINT($"\n	Running Get_NaturalNumbers({n})...");
		
		Set Empty_Set= new Set();
		Set N= new Set();
		for (int i= 0; i <= n; i++) {

			N= N.Do_PairSet(Empty_Set);

			}

		return N;

		}

	}


class NOTES {

	public static void Chapter_3() {

		Console.WriteLine("\x1b[2J");
		Text.PRINT("				Section 3: Removing Elements From Sets\n");

		Set Hello= new Set("Hello");
		Set World= new Set("World!");
		Set Hello_World= World.Do_PairSet(Hello);

		Text.PRINT($"\n			\"We now have three sets {Hello.set}, {World.set}, and their pair set {Hello_World.set}");
		Text.PRINT("			We can use Remove_Element() to remove a specified element from a set.\"");

		Hello_World= Hello_World.Remove_Element(Hello);

		Hello_World= World.Do_PairSet(Hello);
		Hello_World= Hello_World.Remove_Element(World);

		Text.PRINT("\nEnter section number <#>, or press <enter> to continue...");

		string x= Console.ReadLine();

		switch (x) {

		case "1":

			NOTES.Chapter_1();
			break;
			
		case "2":

			NOTES.Chapter_2();
			break;

		case "3":

			NOTES.Chapter_3();
			break;

		case "":

			NOTES.Intro();
			break;

			}
	
		}

	public static void Chapter_2() {

		Console.WriteLine("\x1b[2J");
		Text.PRINT("\n				Section 2: Pair Sets\n");
		
		Set X= new Set("X");
		Set Y= new Set("Y");

		Text.PRINT($"			\"{X.set} and {Y.set} are both sets with {X.elements} and {Y.elements} as elements, respectively.");
		Text.PRINT("			Using Do_PairSet(), we can generate the pair set between two sets:\"");

		Set XY= new Set();
		
		XY= Y.Do_PairSet(X);

		Text.PRINT("		\"Using Set() and Do_PairSet(), we can generate the set of natrual numbers:\"");

		Set.Get_NaturalNumbers(3);	

		Text.PRINT("\nEnter section number <#>, or press <enter> to continue...");

		string x= Console.ReadLine();

		switch (x) {

		case "1":

			NOTES.Chapter_1();
			break;
			
		case "2":

			NOTES.Chapter_2();
			break;

		case "3":

			NOTES.Chapter_3();
			break;

		case "":

			NOTES.Chapter_3();
			break;

			}
	
		}

	public static void Chapter_1() {

		Console.WriteLine("\x1b[2J");
		Text.PRINT("				Section 1: Generating Sets");
		Text.PRINT("\n			We can generate the empty set ('{}') with Set()\"\n");

		Set Empty_Set= new Set();
		Set X= new Set("X");

		Text.PRINT("\nEnter section number <#>, or press <enter> to continue...");

		string x= Console.ReadLine();

		switch (x) {

		case "1":

			NOTES.Chapter_1();
			break;
			
		case "2":

			NOTES.Chapter_2();
			break;

		case "3":

			NOTES.Chapter_3();
			break;

		case "":

			NOTES.Chapter_2();
			break;

			}


		}
	

	public static void Intro() {

		Console.WriteLine("\x1b[2J");
		Text.PRINT("\n					Notes on Sets\n");

		Text.PRINT("\n			Table of Contents:");
		Text.PRINT("\n				Section 1: Generating Sets");
		Text.PRINT("\n				Section 2: Pair Sets");
		Text.PRINT("\n				Section 3: Removing Element From Sets\n");
		Text.PRINT("\nEnter section number <#>, or press <enter> to continue...");

		string x= Console.ReadLine();

		switch (x) {

		case "1":

			NOTES.Chapter_1();
			break;
			
		case "2":

			NOTES.Chapter_2();
			break;

		case "3":

			NOTES.Chapter_3();
			break;

		case "":

			NOTES.Chapter_1();
			break;

			}

		}
	
static void Main(string[] args) {
	
	NOTES.Intro();

	}

}
