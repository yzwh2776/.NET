using System.Collections.Generic

;public class Item {

	public string ITEM_NAME
	;public int IOH
	;public int UNIT_PRICE

	;public Item() {

		ITEM_NAME= "New Item"
		;IOH= 0
		;UNIT_PRICE= 1

		;}

	public Item(string name, int stock, int cost) {

		ITEM_NAME= name
		;IOH= stock
		;UNIT_PRICE= cost

		;}

	}

class Register {

	// private List<Item> Inventory= new List<Item>()

	private int CASH

	;public Register() {

		CASH= 7500

		;}

	public void SELL(Item item) {

		CASH+= item.UNIT_PRICE
		;item.IOH--

		;}

	public static int Main() {

		Register reg= new Register()
	
		;Item BIGMAC= new Item("Big Mac", 100, 1)
		;reg.SELL(BIGMAC)	
		;Console.Write(reg.CASH)

		;return 0	

		;}

	}
