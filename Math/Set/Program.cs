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

	public string elements;
	public string set;	

	public Set() {

		Text.COMMAND("\nRUN_Set();");
		Text.PRINT("\n	Generating new set...");	

		this.elements= "";
		this.set= "{}";

		Text.PRINT("	Successfully created new set!");
		Text.COMMAND($"\nPRINT_Set();");
		Text.COMMAND($"{this.set}");
		
		}

	public Set(string arg) {
	
		Text.COMMAND($"\nRUN_Set({arg});");
		Text.PRINT("\n	Generating new set...");

		this.elements= arg;
		this.set= "{" + arg + "}";

		Text.PRINT("	Successfully created new set!");
		Text.COMMAND($"\nPRINT_Set();");
		Text.COMMAND($"{this.set}");
	
		}

	public static Set PairSet(Set x, Set y) {

		Text.COMMAND($"\nRUN_PairSet({x.set},{y.set});");
		Text.PRINT("\n	Running PairSet()...");

		if (x.set == y.set) {

			Set xy= new Set(x.set);
			return xy;

			}

		else {

			Set xy= new Set(x.set + "," + y.set);
			return xy;

			}

		}

	public static Set UnionSet(Set x) {

		Text.COMMAND($"\nRUN_UnionSet({x.set});");
		Text.PRINT("\n	Running UnionSet()...");

		Set Ux= new Set();
		Text.PRINT("\n	Filling new set...");
		Ux.elements= x.elements;
		Ux.set= x.elements;
	
		Text.PRINT("	Successfully created new set!");
		Text.COMMAND($"\nPRINT_Set();");
		Text.COMMAND($"{Ux.set}");
		
		return Ux;
	
		}

	public static Set UnionSet(Set x, Set y) {

		Text.COMMAND($"\nRUN_UnionSet({x.set},{y.set});");
		Text.PRINT("\n	Running UnionSet()...");

		Set xUy= new Set(x.elements + "," + y.elements);

		return xUy;

		}

	public bool Contains_Element(Set x) {

		Text.COMMAND($"\nRUN_Contains_Element({this.set},{x.set});");
		Text.PRINT("\n	Running Contains_Element()...");
		Text.PRINT($"	Searching {this.set} for {x.set}...");

		if (this.set.Contains(x.set)) {

			Text.PRINT($"	Found {x.set}!");
			return true;
			
			}

		else {
			
			Text.PRINT($"	Failed to find {x.set}!");
			return false;

			}

		}

	public Set Remove_Element(Set x) {

		Text.COMMAND($"\nRUN_Remove_Element({this.set},{x.set});");
		Text.PRINT("\n	Running Remove_Element()...");
		
		if (this.Contains_Element(x)) {

			Text.PRINT($"\n	Attempting to remove {x.set} from {this.set}...");
			
			int start= this.set.IndexOf(x.set);
			int length= x.set.Length;
			
			if (this.set[start - 1] == ',') {

				this.set= this.set.Remove(start - 1, length + 1);
			
				}
			
			else if (this.set[start + length] == ',') {
	
				this.set= this.set.Remove(start, length + 1);

				}
			
			else {

				this.set= this.set.Remove(start, length);

				}
			
			Text.PRINT($"	Successfully removed {x.set}!");
			Text.PRINT($"\n	Validating contents of {this.set}...");

			start= this.elements.IndexOf(x.set);

			Text.COMMAND($"\nPRINT_ELEMENTS(this.set);");
			Text.COMMAND($"{this.elements}");
				
			try {
					
				// ,{}
				this.elements= this.elements.Remove(start - 1, length + 1);

				}
		
			catch {

				try {	
					
					// {},	
					this.elements= this.elements.Remove(start, length + 1);

					}
	
				catch {
					
					// {}
					this.elements= this.elements.Remove(start, length);

					}

				}
				
			Text.COMMAND($"\nPRINT_ELEMENTS(this.set);");
			Text.COMMAND($"{this.elements}");
	
			Text.PRINT($"\n	Contents validated!");
			Text.COMMAND($"\nPRINT_Set();");
			Text.COMMAND($"{this.set}");
	
			return this;

			}
			
		else {

			return this;	

			}

		}

	}

class CHAPTERS {

	public static void Chapter_4() {

		Console.WriteLine("\x1b[2J");
		Text.PRINT("\n				Chapter 4: Removing Elements From Sets");
		Text.PRINT("\n			\"We can remove an element from a set with Remove_Element(Set x).\n			{Set x} is the elemnt to be removed from the set calling the\n			function.\"");

		// Remove Low element

		Set X= new Set("X");
		Set Y= new Set("Y");
		Set XY= Set.PairSet(X,Y);
		Set Y_2= XY.Remove_Element(X);

		// Remove High Element

		Y= Set.UnionSet(Y);
		XY= Set.PairSet(X,Y);
		Set X_2= XY.Remove_Element(Y);
		X= Set.UnionSet(X);

		// Remove Middle Element

		Set ONE= new Set("1");
		Set TWO= new Set("2");
		Set THREE= new Set("3");

		Set vals= Set.UnionSet(ONE, TWO);
		vals= Set.UnionSet(vals, THREE);	
		TWO= Set.UnionSet(TWO);
		vals= vals.Remove_Element(TWO);

		Text.PRINT("\nEnter section number <#>, or press <enter> to continue...");

		CHAPTERS.Get_Chapter("");

		}

	public static void Chapter_3() {

		Console.WriteLine("\x1b[2J");
		Text.PRINT("\n				Section 3: Union Sets");
		Text.PRINT("\n			\"We can generate the union set between two \n			sets with UnionSet(Set x, Set y).\"");

		Set X= new Set("X");
		Set Y= new Set("Y");
		Set XUY= Set.UnionSet(X,Y);	

		Text.PRINT("\nEnter section number <#>, or press <enter> to continue...");

		CHAPTERS.Get_Chapter("4");

		}

	public static void Chapter_2() {

		Console.WriteLine("\x1b[2J");
		Text.PRINT("\n				Section 2: Pair Sets");
		Text.PRINT("\n			\"We can generate the pair set between two sets \n			with PairSet(Set x, Set y).\"");

		Set X= new Set("X");
		Set Y= new Set("Y");
		Set XY= Set.PairSet(X,Y);

		Text.PRINT("\nEnter section number <#>, or press <enter> to continue...");

		CHAPTERS.Get_Chapter("3");

		}

	public static void Chapter_1() {

		Console.WriteLine("\x1b[2J");
		Text.PRINT("				Section 1: Generating Sets");
		Text.PRINT("\n			\"We can generate a new empty set with Set().\"");
		Set Empty_Set= new Set();

		Text.PRINT("\n			\"We can generate a set with a string of \n			elements with Set(string arg).\"");

		Set X= new Set("X");
		Text.PRINT("\nEnter section number <#>, or press <enter> to continue...");

		CHAPTERS.Get_Chapter("2");

		}

	public static void Intro() {

		Console.WriteLine("\x1b[2J");
		Text.PRINT("\n					Notes on Sets\n");
		Text.PRINT("\n			Table of Contents:");
		Text.PRINT("\n				Chapter 1: Generating Sets");
		Text.PRINT("\n				Chapter 2: Pair Sets");
		Text.PRINT("\n				Chapter 3: Union Sets");
		Text.PRINT("\n				Chapter 4: Removing Elements From Sets\n");
		Text.PRINT("\nEnter section number <#>, or press <enter> to continue...");
		
		CHAPTERS.Get_Chapter("1");
	
		}

	public static void Get_Chapter(string arg) {

		string x= Console.ReadLine();

		switch (x) {

		case "1":

			CHAPTERS.Chapter_1();
			break;

		case "2":

			CHAPTERS.Chapter_2();
			break;
		
		case "3":

			CHAPTERS.Chapter_3();
			break;

		case "4":

			CHAPTERS.Chapter_4();
			break;

		case "":

			switch (arg) {

			case "1":

				CHAPTERS.Chapter_1();
				break;

			case "2":

				CHAPTERS.Chapter_2();
				break;
			
			case "3":

				CHAPTERS.Chapter_3();
				break;

			case "4":

				CHAPTERS.Chapter_4();
				break;

			case "":

				CHAPTERS.Intro();
				break;
			
				}

			break;

			}
		
		}

	static void Main(string[] arg) {

		CHAPTERS.Intro();

		}

	}

		
