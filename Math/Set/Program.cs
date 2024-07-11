
// Create Set class
class Set {

	public string set; // Create a field 
	public string elements;

	// Create a class constructor for the Set class
	public Set() {

		set= "{}";
		elements= ""; 

		}

	public void Do_PairSet(string a, string b) {

		if (elements != "") {

			elements+= ", ";

			}
		
		if (a == b) {
		
			elements+= a;
			set= "{" + elements + "}";

			}

		else {

			elements+= a + ", " + b;
			set= "{" + elements + "}";
			
			}

		}

static void Main(string[] args) {

	Set ZERO= new Set();
	Console.WriteLine($"0 := {ZERO.set}");

	Set ONE= new Set();
	ONE.Do_PairSet(ZERO.set, ZERO.set);
	Console.WriteLine($"1 := {ONE.set}");	

	Set TWO= new Set();
	TWO.Do_PairSet(ZERO.set, ONE.set);
	Console.WriteLine($"2 := {TWO.set}");
	
	Set THREE= new Set();
	THREE.Do_PairSet(ZERO.set, TWO.set);
	Console.WriteLine($"3 := {THREE.set}");

	Set FOUR= new Set();
	FOUR.Do_PairSet(ZERO.set, THREE.set);
	Console.WriteLine($"4 := {FOUR.set}");

	Console.WriteLine("---------------------------------------");

	Set Empty_Set= new Set();
	Set mySet= new Set();

	for (int i= 0; i <= 10; i++) {

		Console.WriteLine($"{i} := {mySet.set} ");

		Set TEMP= new Set();
		TEMP.Do_PairSet(Empty_Set.set, mySet.set);
//		Console.WriteLine($"x = {TEMP.set}\n");

		mySet.set= TEMP.set;		

		}

	}



}
