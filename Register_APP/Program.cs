using System.Collections.Generic

;public class Ingredient {

	public string NAME
	;public int IOH

	;public Ingredient() {

		NAME= "New Ingredient"
		;IOH= 9999	

		;}

	public Ingredient(string name) {
	
		NAME= name
		;IOH= 9999

		;}

	public Ingredient(string name, int stock) {

		NAME= name
		;IOH= stock

		;}

	public override string ToString() {
		
		return this.NAME + " (" + this.IOH + ")"

		;}

	}

class FRAME {

	private static int ROWS= 36
	;private static int COLS= 128
	;private static char[] SCREEN=new char[ROWS * COLS]

	;public FRAME() {

		for(int i= 0; i < SCREEN.Length; i++) {

			SCREEN[i]= '*'

			;}

		;}

	public void Print() {

		foreach(char c in SCREEN) {

			Console.Write(c)

			;}

		;}	

	}

class Register {
	
	public Dictionary<string, Ingredient> Inventory= new Dictionary<string, Ingredient>()

	;public void __init__() {
	
		Ingredient REG_BUN= new Ingredient("Regular Bun")
		;Inventory.Add(REG_BUN.NAME, REG_BUN)
		;Ingredient REG_MEAT= new Ingredient("Regular Meat")
		;Inventory.Add(REG_MEAT.NAME, REG_MEAT)
		;Ingredient CHEESE= new Ingredient("Cheese Slice")
		;Inventory.Add(CHEESE.NAME, CHEESE)
		;Ingredient DH_ONION= new Ingredient("Dehydrated Onion")
		;Inventory.Add(DH_ONION.NAME, DH_ONION)
		;Ingredient PICKLE= new Ingredient("Pickle")
		;Inventory.Add(PICKLE.NAME, PICKLE)
		;Ingredient KETCHUP= new Ingredient("Ketchup")
		;Inventory.Add(KETCHUP.NAME, KETCHUP)
		;Ingredient MUSTARD= new Ingredient("Mustard")
		;Inventory.Add(MUSTARD.NAME, MUSTARD)

		;}

	private int CASH

	;public Register() {

		CASH= 7500

		;}

	public void SELL_MCDOUBLE(int quantity) {
	
		for(int i= 0; i < quantity; i++) {

			Inventory["Regular Meat"].IOH--
			;Inventory["Regular Meat"].IOH--
			;Inventory["Cheese Slice"].IOH--
			;Inventory["Dehydrated Onion"].IOH--
			;Inventory["Pickle"].IOH--
			;Inventory["Ketchup"].IOH--
			;Inventory["Mustard"].IOH--
		
			;CASH+= 249

			;}

		;}

	public static int Main() {

		;Register reg= new Register()
		;reg.__init__()

		;FRAME gui= new FRAME()
		;gui.Print()
		

		;return 0	

		;}

	}
