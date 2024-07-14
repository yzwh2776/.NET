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
		Ux.elements= x.elements;
		Ux.set= x.elements;
		
		return Ux;
	
		}

	public static Set UnionSet(Set x, Set y) {

		Text.COMMAND($"\nRUN_UnionSet({x.set},{y.set});");
		Text.PRINT("\n	Running UnionSet()...");

		Set xUy= new Set(x.elements + "," + y.elements);

		return xUy;

		}
	
	public static Set Intersect(Set x, Set y) {

		Text.COMMAND($"\nRUN_Intersect({x.set},{y.set});");
		Text.PRINT("\n	Running Interect()...");

		

		

	static void Main(string[] arg) {

		Set Empty_Set= new Set();

		Set X= new Set("X");
		Set Y= new Set("Y");

		Set XY= Set.PairSet(X, Y);

		Set UX= Set.UnionSet(X);
		Set XUY= Set.UnionSet(X, Y);

		Set ONE= Set.PairSet(Empty_Set, Empty_Set);
		ONE= Set.UnionSet(ONE);

		}

	}

		
