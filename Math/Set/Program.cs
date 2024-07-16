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

	public bool Is_Empty() {

		return this.elements == "";

		}

	public Set Element_At(int i) {

		Text.COMMAND($"\nRUN_Element_At({i});");
		Text.PRINT("\n	Running Element_at()...");

		string temp_elements= this.elements;
		int index;
		string s= "";

		for (int j= 0; j <= i; j++) {
	
			try {

			index= temp_elements.IndexOf(',');
			s= temp_elements.Substring(0, index);
			temp_elements= temp_elements.Remove(0, index + 1);

				}

			catch {

				s= temp_elements;
			
				}

			}
		
		Set temp_set= new Set(s);

		return Set.UnionSet(temp_set);

		}

	public static int Get_Cardinality(Set x) {
	
		Text.COMMAND($"\nRUN_Get_Cardinality({x.set});");
		Text.PRINT("\n	Running Get_Cardinality()...");

		Set temp_x= new Set(x.elements);
		int count= 0;

		do {

			try { 

				temp_x.Remove_Element(temp_x.Element_At(0));
				count++;
	
				}

			catch { 
		
				break;

				}

			}

		while (!temp_x.Is_Empty()); 

		Text.COMMAND($"\nPRINT_Get_Cardinality();");
		Text.COMMAND($"{count}");

		return count;

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
				
			Text.COMMAND($"\nPRINT_ELEMENTS({this.set});");
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

	public static Set Intersect(Set x, Set y) {

		Text.COMMAND($"\nRUN_Intersect({x.set}, {y.set});");
		Text.PRINT("\n	Running Intersect()...");

		int card_x= Set.Get_Cardinality(x);
		int card_y= Set.Get_Cardinality(y);

		int length;

		if (card_x <= card_y) {

			length= card_x;
			
			}

		else {
			
			length= card_y;

			}

		Set intersection= new Set();

		for (int i= 0; i < length; i++) {

			if (y.Contains_Element(x.Element_At(i))) {

				if (!intersection.Is_Empty() ) {

				intersection= Set.UnionSet(intersection, x.Element_At(i));


					}

				else {

					intersection= Set.UnionSet(x.Element_At(i));

					}

				}	

			}

		Text.PRINT("\n	Finished running Intersect()!");
		return intersection;

		}

	public static bool Equivalent(Set x, Set y) {

		Text.COMMAND($"\nRUN_Equivalent({x.set}, {y.set});");
		Text.PRINT($"\n	Running Equivalent()...");
	
		if (x.set == Set.Intersect(x, y).set) {

			Text.PRINT("\n	Sets are equivalent!");
			return true;

			}

		else {

			Text.PRINT("\n	Sets are not equivalent!");
			return false;
		
			}
		
		}

	}

class CHAPTERS {

	public static void Chapter_6() {

		Console.WriteLine("\x1b[2J");
		Text.PRINT("\n				Chapter 6: Intersections, Equivalence, and Subsets");
		Text.PRINT("\n			We can generate the intersection set using Intersect(Set x, Set y)");
		
		Set x1= new Set("1,2,3");
		Set x2= new Set("1,2");

		Set intersect= Set.Intersect(x1, x2);

		Text.PRINT("\n			\"Using Intersect() we can easily check if two sets are equivalent.\"");

		Set.Equivalent(x2, intersect); 

		Text.PRINT("\nEnter section number <#>, or press <enter> to continue...");

		CHAPTERS.Get_Chapter("");

		}

	public static void Chapter_5() {

		Console.WriteLine("\x1b[2J");
		Text.PRINT("\n				Chapter 5: Cardinalty and Index of Sets");
	
		Text.PRINT("\n			Using Element_At() we can find the index of an element in a set.");
		Text.PRINT("\n			Using Get_Cardinality() we can find the cardinality of a set,\n			or the number of elements in the set.");

		Set X= new Set("1,2,3");
		Set e= X.Element_At(1);
		Set.Get_Cardinality(X);	

		Text.PRINT("\nEnter section number <#>, or press <enter> to continue...");

		CHAPTERS.Get_Chapter("");
		
		}

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

		CHAPTERS.Get_Chapter("5");

		}

	public static void Chapter_3() {

		Console.WriteLine("\x1b[2J");
		Text.PRINT("\n				Chapter 3: Union Sets");
		Text.PRINT("\n			\"We can generate the union set between two \n			sets with UnionSet(Set x, Set y).\"");

		Set X= new Set("X");
		Set Y= new Set("Y");
		Set XUY= Set.UnionSet(X,Y);	

		Text.PRINT("\nEnter section number <#>, or press <enter> to continue...");

		CHAPTERS.Get_Chapter("4");

		}

	public static void Chapter_2() {

		Console.WriteLine("\x1b[2J");
		Text.PRINT("\n				Chapter 2: Pair Sets");
		Text.PRINT("\n			\"We can generate the pair set between two sets \n			with PairSet(Set x, Set y).\"");

		Set X= new Set("X");
		Set Y= new Set("Y");
		Set XY= Set.PairSet(X,Y);

		Text.PRINT("\nEnter section number <#>, or press <enter> to continue...");

		CHAPTERS.Get_Chapter("3");

		}

	public static void Chapter_1() {

		Console.WriteLine("\x1b[2J");
		Text.PRINT("				Chapter 1: Generating Sets");
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
		Text.PRINT("\n				Chapter 4: Removing Elements From Sets");
		Text.PRINT("\n				Chapter 5: Cardinality and Index of Sets");
		Text.PRINT("\n				Chapter 6: Intersections, Equivalence, and Subsets\n");
		
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

		case "5":

			CHAPTERS.Chapter_5();
			break;

		case "6":

			CHAPTERS.Chapter_6();
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

			case "5":

				CHAPTERS.Chapter_5();
				break;

			case "6":
			
				CHAPTERS.Chapter_6();
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

		
