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
		Text.PRINT("	Filling new set...");
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
		Text.PRINT("\n	 Running Remove_Element()...");
		
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
				
			if (this.elements[start - 1] == ',') {

				this.elements= this.elements.Remove(start - 1, length + 1);
			
				}
			
			else if (this.elements[start + length] == ',') {
	
				this.elements= this.elements.Remove(start, length + 1);

				}
			
			else {

				this.elements= this.elements.Remove(start, length);

				}
			
			Text.COMMAND($"\nPRINT_ELEMENTS(this.set);");
			Text.COMMAND($"{this.elements}");
	
			Text.PRINT($"	Contents validated!");
			Text.COMMAND($"\nPRINT_Set();");
			Text.COMMAND($"{this.set}");
	
			return this;

			}
			
		else {

			return this;	

			}

		}

	static void Main(string[] arg) {

		Set ONE= new Set("1");
		Set TWO= new Set("2");
		Set THREE= new Set("3");

		Set x1= Set.UnionSet(ONE,TWO);
		x1= Set.UnionSet(x1, THREE);

		TWO= Set.UnionSet(TWO);
		x1= x1.Remove_Element(TWO);

		}

	}

		
