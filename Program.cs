using System;
using System.Collections.Generic;
namespace Лаба_3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Random rand = new Random();
                string[] sizePizza = new string[] { "little", "middle", "big" };
                string[] typeWelt = new string[] { "meeting", "cheeseing", "usual" };
                int n, a;
                string typeingr;
                string nameingr;
                double costingr,
                    suma = 0;
                List<Pizza> menu = new List<Pizza>(); // createing list will have all pizza 
                for (int i = 0; i < 1; i++)
                    menu.Add(new Pizza(sizePizza[rand.Next(3)], typeWelt[rand.Next(3)])); //createing pizza with something size and welt and add to list
                foreach (Pizza pizza in menu)
                {
                    Console.WriteLine("Enter amount of ingredients:\a");
                    while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                    for (int i = 0; i < n; ++i)
                    {
                        Console.WriteLine("Enter type of ingredient:\n1) vegetable\n2) fruit\n3) meet\n4) cheese\n5) sous\n6) seafood");
                        typeingr = Console.ReadLine();
                        Console.WriteLine("Enter name of ingredient");
                        nameingr = Console.ReadLine();
                        Console.WriteLine("Enter cost of ingredient");
                        while (!Double.TryParse(Console.ReadLine(), out costingr) || costingr <= 0) ;
                        pizza.AddIngredient(nameingr, typeingr, costingr, ref i);
                    }
                    Console.WriteLine("Enter name of ingredient, that do you want to find");
                    nameingr = Console.ReadLine();
                    if (!pizza.FindIngredientPerName(nameingr))
                        Console.WriteLine("Ingredient not found.");
                    else
                        Console.WriteLine("Ingredient found - {0}", nameingr);
                    Console.WriteLine("Enter name of ingredient, that do you want to delete");
                    nameingr = Console.ReadLine();
                    if (pizza.DeleteIngredientForName(nameingr))
                        Console.WriteLine("Ingredient is deleted");
                    else Console.WriteLine("This ingredient not found");
                    suma = pizza.CostPizza();
                    Console.WriteLine("Cost of pizza is {0:F2}", suma);
                }
            }
            catch (Exception e) { Console.WriteLine(e); };
        }
    }
}
/// <summary>
/// Pizza has type of welt and size, and some ingredient
/// </summary>
class Pizza
{
    enum sizepiz { little, middle, big }
    enum typeWeltOfPiz { meeting, cheeseing, usual }
    string sizePizza, typeWelt;

    /// <summary>
    /// Gave access to size pizza
    /// </summary>

    public string SizePizza
    {
        get { return sizePizza; }
    }

    /// <summary>
    /// access to type of welt of pizza
    /// </summary>
    public string TypeWelt
    {
        get { return typeWelt; }
    }

    public Pizza() : this("", "") { }
    public Pizza(string sizePizza, string typeWelt)
    {
        if (!sizepiz.IsDefined(typeof(sizepiz), sizePizza) || !typeWeltOfPiz.IsDefined(typeof(typeWeltOfPiz), typeWelt))
            throw new ArgumentException("Invalid size or type of pizza");
        this.typeWelt = typeWelt;
        this.sizePizza = sizePizza;
    }

    List<Ingredient> ingredient = new List<Ingredient>();
    /// <summary>
    /// Count cost of pizza, she equals type+size+some ingredient
    /// </summary>
    /// <returns></returns>
    public double CostPizza()
    {
        double suma = 0;
        foreach (Ingredient ingr in ingredient) suma += ingr.CostIngredient; //suma with all ingredient
        switch (sizePizza) // add cost for size of pizza
        {
            case "little":
                suma += 15;
                break;
            case "middle":
                suma += 25;
                break;
            case "big":
                suma += 40;
                break;
        }
        switch (typeWelt) // add cost for type of welt of pizza
        {
            case "meeting":
                suma += 30;
                break;
            case "cheeseing":
                suma += 20;
                break;
            case "usul":
                suma += 10;
                break;
        }
        return suma;
    }

    /// <summary>
    /// Add some ingredient to pizza
    /// </summary>
    /// <param name="nameingr"></param>
    /// <param name="typeingr"></param>
    /// <param name="costingr"></param>
    /// <param name="i"></param>
    public void AddIngredient(string nameingr, string typeingr, double costingr, ref int i)
    {
        ingredient.Add(new Ingredient(typeingr, nameingr, costingr));
    }

    /// <summary>
    /// Find something ingredient for name
    /// </summary>
    /// <param name="nameIngredient"></param>
    /// <returns></returns>
    public bool FindIngredientPerName(string nameIngredient)
    {
        foreach (Ingredient ingr in ingredient)
            if (ingr.NameIngredient == nameIngredient)//compare name with list of ingredient and name that was enter
                return true;
        return false;
    }

    /// <summary>
    /// //Delete  ingredient in pizza
    /// </summary>
    /// <param name="nameIngredient"></param>
    /// <returns></returns>
    public bool DeleteIngredientForName(string nameIngredient)
    {
        foreach (Ingredient ingr in ingredient)
            if (ingr.NameIngredient == nameIngredient) // returns true if ingredient have deleted and false if haven't deleted                                                       
            {
                ingredient.Remove(ingr);
                return true;
            }
        return false;

    }
    /// <summary>
    /// Find all ingredient in pizza for type
    /// </summary>
    /// <param name="typeIngredient"></param>
    /// <returns></returns>
    public bool FindIngredientPerType(string typeIngredient)
    {
        foreach (Ingredient ingr in ingredient)
            if (ingr.TypeIngredient == typeIngredient)//compare name with list of ingredient and name that was enter
                return true;
        return false;
    }

    /// <summary>
    /// Delete type of ingredient in pizza
    /// </summary>
    /// <param name="typeIngredient"></param>
    /// <returns></returns>
    public bool DeleteIngredientForType(string typeIngredient)
    {
        bool check = false;
        foreach (Ingredient ingr in ingredient)
            if (ingr.TypeIngredient == typeIngredient) //returns true if all of ingredient with same type have deleted and 
                                                       //false if haven't deleted 
            {
                ingredient.Remove(ingr);
                check = true;
            }
        return check;

    }
    /// <summary>
    /// Returns list of ingredient in pizza
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        string ingredients = "";
        foreach (Ingredient ingr in ingredient)
            ingredients += ingr.NameIngredient + ", ";
        return "Pizza contains: " + ingredients;
    }

    /// <summary>
    /// Compares two pizza for both size of pizza and type of welt
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        if (this == obj)
            return true;
        Pizza piz = obj as Pizza;

        if (piz == null)
            return false;

        return this.sizePizza == piz.sizePizza && this.typeWelt == piz.typeWelt;
    }

    public static bool operator ==(Pizza piz1, Pizza piz2)
    {
        if (ReferenceEquals(piz1, null) || ReferenceEquals(piz2, null))
            return false;
        return piz1.Equals(piz2);
    }
    public static bool operator !=(Pizza piz1, Pizza piz2)
    {
        return !(piz1==piz2);
    }
    public Ingredient this [int index]
    {
        get
        {
            if (index < 0 || index >= ingredient.Count)
                throw new ArgumentException();
            return ingredient[index];
        }
    }
}
class Ingredient
{
    enum typeList { vegetable, fruit, meet, seafood, sous }
    enum nameList { potatoes, onion, corn, garlic, tomatoes, apple, bear, peach, melon, watermelon, cheese, life, like, sos, chicken, pork, fish, muscle, lobster }

    string typeIn, name;
    double cost;

    /// <summary>
    /// Access to type of ingredient
    /// </summary>
    public string TypeIngredient
    {
        get { return typeIn; }
    }

    /// <summary>
    /// Access to name of ingredient
    /// </summary>
    public string NameIngredient
    {
        get { return name; }
    }
    /// <summary>
    /// Access to cost of ingredient
    /// </summary>
    public double CostIngredient
    {
        get { return cost; }
        set
        {
            if (cost <= 0)
                throw new ArgumentException("Cost is not less zero");
            cost = value;
        }
    }

    public Ingredient(string typeIn, string name, double cost)
    {
        if (!typeList.IsDefined(typeof(typeList), typeIn)) // looking for entered type with existence
            throw new ArgumentException("Type is invalid");
        if (!nameList.IsDefined(typeof(nameList), name)) //looking for name in existence
            throw new ArgumentException("Name is invalid"); // check whether cost > 0
        if (cost <= 0)
            throw new ArgumentException("Cost is not less zero");
        this.typeIn = typeIn;
        this.name = name;
        this.cost = cost;
    }
    /// <summary>
    /// Compares teo ingredient for their name
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(Object obj)
    {
        if (this == obj)
            return true;
        Ingredient ingr = obj as Ingredient;
        if (ingr == null)
            return false;
        return this.name == ingr.name;

    }
    public static bool operator ==(Ingredient ingr1, Ingredient ingr2)
    {
        if (ReferenceEquals(ingr1, null)|| ReferenceEquals(ingr2, null))
            return false;
        return ingr1.Equals(ingr2);
        
    }
    public static bool operator !=(Ingredient ingr1, Ingredient ingr2)
    {
        return !(ingr1==ingr2);
    }

    /// <summary>
    /// Returns type of ingredient his name and his cost
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return typeIn + ": " + name + " " + cost;
    }
}