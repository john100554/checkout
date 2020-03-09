//The program is written in C# by Yip Wai Shing
using System;
using System.Collections.Generic;

class ipd{ //Super iPad
public static double price=549.99;
public static int count=0;
 }		
class mbp{  //MacBook Pro
public static double price=1399.99;
public static int count=0;
 }
class atv{   //Apple TV
public static double price=109.50;
public static int count=0;
 }
class vga{   //VGA adaptor
public static double price=30.00;
public static int count=0;
}

class Checkout
{
Dictionary<string, int> dict = new Dictionary<string, int>(); //using dictionary to store
double totalprice=0;
public Checkout(string rule) {  //initialize 4 products(product name, no.of product=0) 
dict.Add("ipd", ipd.count);
dict.Add("mbp", mbp.count);
dict.Add("atv", atv.count);
dict.Add("vga", vga.count);
}
	
public void scan(string item){   //no.of product + 1 
if (dict.ContainsKey(item))     
dict[item]+=1;	
else
Console.WriteLine("No this Item!");
}
	
public void total(){
dict.TryGetValue("ipd", out ipd.count);       //get the no. of each item
dict.TryGetValue("mbp", out mbp.count);
dict.TryGetValue("atv", out atv.count);
dict.TryGetValue("vga", out vga.count);

/*rule setting (modify rule)  */

//rule no.1
atv.count=(atv.count-atv.count/3);

//rule no.2
if(ipd.count>4)
ipd.price=499.99;

//rule no.3 
if(vga.count<=mbp.count)
vga.price=0;
else
vga.count=(vga.count-mbp.count);
//rule setting end

totalprice=((ipd.count*ipd.price)+(mbp.count*mbp.price)+(atv.count*atv.price)+(vga.count*vga.price));
Console.WriteLine("Total expected: "+ "$"+ totalprice);
}
}


public class program{
public static void Main(string[] args)
{
Checkout co = new Checkout("pricingRules");
co.scan("mbp");
co.scan("vga");
co.scan("ipd");

co.total();

}
}