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
                string[] list = new string[] { "potatoes", "onion", "corn", "garlic", "apple", "bear", "peach", "melon", "watermelon", "life", "like", "sos", "chicken", "pork", "fish", "muscle", "lobster" };
                string[] typelist = new string[] { "vegetable", "fruit", "meet", "seafood", "sous" };
                List<Dish> dish1 = new List<Dish>();
                dish1.Add(new Dish());
                dish1.Add(new Pizza("meet", "big"));
                dish1.Add(new Panini("white_bread"));
                dish1.Add(new Pasta("little", "bigoli"));
                Random rand = new Random();
                foreach (Dish d in dish1)
                    for (int i = 1; i < 6; ++i)
                        d.AddIngredient(typelist[typelist.Length - 1 - i / 3/*rand.Next(typelist.Length - 1)*/], list[list.Length - 1 - i/*rand.Next(list.Length - 1)]*/], i);
                int a = rand.Next(list.Length - 1);
                string na = list[a];
                if (dish1[2].DeleteIngredientForName(list[a]))
                    Console.WriteLine("Ingredient {0} was delete", na);
                else
                    Console.WriteLine("Ingredient {0} wasn't delete, because he isn't exist", list[a]);
                Console.WriteLine(dish1[2]);
                Console.WriteLine("Cost of pizza after delete/undelete ingredient: {0}", dish1[2].CostDish());
                a = rand.Next(typelist.Length - 1);
                na = typelist[a];
                if (dish1[2].DeleteIngredientForType(na))
                    Console.WriteLine("All ingredient of type {0} were deleted", na);
                else
                    Console.WriteLine("This type of ingredient was not delete");
                Console.WriteLine(dish1[2]);
                Console.WriteLine("Cost of pizza after delete/undelete type of ingredients: {0}", dish1[2].CostDish());
                Console.WriteLine("\nDemonstation late communicate");
                foreach (Dish d in dish1)
                    Console.WriteLine("Cost " + d.GetType() + " with ingredients {0}", d.CostDish());
                Console.WriteLine("\nDemonstrate early communicate");
                foreach (Dish d in dish1)
                    Console.WriteLine(d.HowCook());
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(((Pizza)dish1[1]).HowCook()); 
                Console.WriteLine(((Panini)dish1[2]).HowCook());
                Console.WriteLine(((Pasta)dish1[3]).HowCook());
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
    }
}

class Dish
{
    /// <summary>
    /// amouy time for cooking something dish
    /// </summary>
    protected int timeCooking;
    protected List<Ingredient> ingredient;

    /// <summary>
    /// access to time cook of dish
    /// </summary>
    public int TimeCooking
    {
        get { return timeCooking; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Time is invalid");
            timeCooking = value;
        }
    }
    public Dish()
    {
        timeCooking = 1;
        ingredient = new List<Ingredient>();
    }

    /// <summary>
    /// Count cost of dish, she equals some ingredient
    /// </summary>
    /// <returns></returns>
    public virtual double CostDish()
    {
        double suma = 0;
        foreach (Ingredient ingr in ingredient) suma += ingr.CostIngredient; //suma with all ingredient
        return suma;
    }

    /// <summary>
    /// determinates whether dish is cook
    /// </summary>
    /// <param name="timeCooking"></param>
    /// <param name="timeCookingCurrent"></param>
    /// <returns></returns>
    public string Cook(double timeCookingCurrent)
    {
        if (timeCookingCurrent < timeCooking)
            return "Dish is raw"; // when dish is not cook
        if (timeCooking == timeCookingCurrent)
            return "Dish is cook";
        return "Dish is overcook"; // when dish is cook
    }

    /// <summary>
    /// Add some ingredient to dish
    /// </summary>
    /// <param name="nameingr"></param>
    /// <param name="typeingr"></param>
    /// <param name="costingr"></param>
    public void AddIngredient(string typeingr, string nameingr, double costingr)
    {
        if (FindIngredientPerName(nameingr))
            throw new ArgumentException("This ingredient already exist");
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
    /// //Delete  ingredient in dish
    /// </summary>
    /// <param name="nameIngredient"></param>
    /// <returns></returns>
    public bool DeleteIngredientForName(string nameIngredient)
    {
        bool check = false;
        for (int i = 0; i < ingredient.Count; i++)
            if (ingredient[i].NameIngredient == nameIngredient) // returns true if ingredient have deleted and false if haven't deleted                                                       
            {
                ingredient.Remove(ingredient[i]);
                check = true;
            }
        return check;
    }

    /// <summary>
    /// Find all ingredient in dish for type
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
    /// Delete type of ingredient in dish
    /// </summary>
    /// <param name="typeIngredient"></param>
    /// <returns></returns>
    public bool DeleteIngredientForType(string typeIngredient)
    {
        bool check = false;
        for (int i = 0; i < ingredient.Count; i++)
            if (ingredient[i].TypeIngredient == typeIngredient) //returns true if all of ingredient with same type have deleted and 
                                                                //false if haven't deleted 
            {
                ingredient.Remove(ingredient[i]);
                check = true;
            }
        return check;
    }

    /// <summary>
    /// Returns list of ingredient in dish
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        string ingredients = "";
        foreach (Ingredient ingr in ingredient)
            ingredients += ingr.NameIngredient + ", ";
        return "Dish contains: " + ingredients;
    }

    /// <summary>
    /// this is cooking recipe
    /// </summary>
    /// <returns></returns>
    public string HowCook()
    {
        return "Dish should be cook before eating";
    }

    /// <summary>
    /// determinates whether both dishes on same ingredients
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(Object obj)
    {
        if (this == obj)
            return true;
        if (!ReferenceEquals(this.GetType(), obj.GetType()))
            return false;
        Dish ingr = obj as Dish;
        if (ingr == null)
            return false;
        foreach (Ingredient ingri in this.ingredient)
            if (!ingr.ingredient.Contains(ingri))
                return false;
        return true;
    }
    public static bool operator ==(Dish dish1, Dish dish2)
    {
        if (ReferenceEquals(dish1, null) || ReferenceEquals(dish2, null))
            return false;
        return dish1.Equals(dish2);
    }
    public static bool operator !=(Dish dish1, Dish dish2)
    {
        return !(dish1 == dish2);
    }
    public Ingredient this[int index]
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
    /// <summary>
    /// list of all type ingridients
    /// </summary>
    enum typeList { vegetable, fruit, meet, seafood, sous, milk, tisto, pasta }

    /// <summary>
    /// name of all ingredients
    /// </summary>
    enum nameList { potatoes, onion, corn, garlic, tomatoes, apple, bear, peach, melon, watermelon, cheese, life, like, sos, chicken, pork, fish, muscle, lobster, withoutdrogdgi, majonez, spaghetti, bigoli, canalini, bavette, white_bread, black_bread, grey_bread }

    /// <summary>
    /// save type ingredienta and his name
    /// </summary>
    string typeIn, name;

    /// <summary>
    /// cost of ingredient
    /// </summary>
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
            if (value <= 0)
                throw new ArgumentException("Cost is not less zero");
            cost = value;
        }
    }
    public Ingredient() : this("", "", 0) { }
    /// <summary>
    /// type of ingredient, name of ingredient, cost of ingredient
    /// </summary>
    /// <param name="typeIn"></param>
    /// <param name="name"></param>
    /// <param name="cost"></param>
    public Ingredient(string typeIn, string name, double cost)
    {
        if (!Enum.IsDefined(typeof(typeList), typeIn)) // looking for entered type with existence
            throw new ArgumentException("Type is invalid");
        if (!Enum.IsDefined(typeof(nameList), name)) //looking for name in existence
            throw new ArgumentException("Name is invalid");
        if (cost <= 0)                         // check whether cost > 0
            throw new ArgumentException("Cost is not less zero");
        this.typeIn = typeIn;
        this.name = name;
        this.cost = cost;
    }

    /// <summary>
    /// Compares two ingredient for their name
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
        if (ReferenceEquals(ingr1, null) || ReferenceEquals(ingr2, null))
            return false;
        return ingr1.Equals(ingr2);
    }
    public static bool operator !=(Ingredient ingr1, Ingredient ingr2)
    {
        return !(ingr1 == ingr2);
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
class Pizza : Dish
{
    /// <summary>
    /// type of welt of pizza
    /// </summary>
    protected string typeWelt;

    /// <summary>
    /// list of all welt of pizza
    /// </summary>
    protected enum typeList { usual, meet, cheese }

    /// <summary>
    /// list of all size of pizza
    /// </summary>
    protected enum sizeDish { little, middle, big }

    /// <summary>
    /// some size of pizza
    /// </summary>
    protected string size;

    /// <summary>
    /// Gave access to size pizza
    /// </summary>
    public string SizePizza
    {
        get { return size; }
    }

    /// <summary>
    /// access to type of welt of pizza
    /// </summary>
    public string TypeOfWelt
    {
        get { return typeWelt; }
    }

    public Pizza() : this("cheese", "little") { }

    /// <summary>
    /// Initial object of class Pizza
    /// </summary>
    /// <param name="typeWelt">usual, meet, cheese</param>
    /// <param name="size">little, middle, big</param>
    public Pizza(string typeWelt, string size)
    {
        if (!Enum.IsDefined(typeof(typeList), typeWelt))
            throw new ArgumentException("Type of pizza is invalid");
        this.typeWelt = typeWelt;
        AddIngredient("tisto", "withoutdrogdgi", 10);
        AddIngredient("milk", "cheese", 5);
        AddIngredient("milk", "majonez", 3);
        AddIngredient("vegetable", "tomatoes", 4);
        this.size = size;
        timeCooking = 20; // time for cooking all pizza
    }

    /// <summary>
    /// Count cost of pizza for all ingredientstype of welt+size of pizza
    /// </summary>
    /// <returns></returns>
    public override double CostDish()
    {
        double suma = 0;
        foreach (Ingredient ingr in ingredient) suma += ingr.CostIngredient; //suma with all ingredient
        switch (size) // add cost for size of pizza
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
            case "meet":
                suma += 30;
                break;
            case "cheese":
                suma += 20;
                break;
            case "usual":
                suma += 10;
                break;
        }
        return suma;
    }

    /// <summary>
    /// recipe how you should cook pizza
    /// </summary>
    /// <returns></returns>
    public new string HowCook()
    {
        return "To start making the dough, and then add the ingredients, and then put in the oven";
    }

    /// <summary>
    /// Compares two pizza for both size of pizza and type of welt
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    //public override bool Equals(object obj)
    //{
    //    if (this == obj)
    //        return true;
    //    Pizza piz = obj as Pizza;
    //    if (piz == null)
    //        return false;
    //    return this.size == piz.size && this.typeWelt == piz.typeWelt;
    //}
}
class Panini : Dish
{
    protected string typeBread;
    enum listOver { white_bread, black_bread, grey_bread }
    public string Over
    {
        get { return typeBread; }
        set
        {
            if (!Enum.IsDefined(typeof(listOver), value))
                throw new ArgumentException("Type of bread is not invalid");
            typeBread = value;
        }
    }

    /// <summary>
    /// initial time for cooking
    /// </summary>     

    public Panini() : this("white_bread") { }
    /// <summary>
    /// Initial object of class Panini
    /// </summary>
    /// <param name="typeBread">slightly, more_slightly, over_cook</param>
    public Panini(string typeBread)
    {
        if (!Enum.IsDefined(typeof(listOver), typeBread))
            throw new ArgumentException("Degree of roasting is not invalid");
        this.typeBread = typeBread;
        AddIngredient("tisto", typeBread, 5);
        AddIngredient("milk", "cheese", 3);
        AddIngredient("vegetable", "tomatoes", 4);
        timeCooking = 10;
    }

    /// <summary>
    /// Count cost of pannini for start work+all ingredient
    /// </summary>
    /// <returns></returns>
    public override double CostDish()
    {
        double suma = 10;
        foreach (Ingredient ingr in ingredient) suma += ingr.CostIngredient; //suma with all 
        return suma;
    }

    /// <summary>
    /// recipe how cook this dish
    /// </summary>
    /// <returns></returns>
    public new string HowCook()
    {
        return "Put between rolls ingredients, and then heats";
    }
}
class Pasta : Dish
{
    /// <summary>
    /// list all of type of pasta
    /// </summary>
    protected enum typeOfPasta { spaghetti, bigoli, canalini, bavette }

    /// <summary>
    /// all size of portion pasta
    /// </summary>
    protected enum sizeDish { little, middle, big }

    /// <summary>
    /// some size of portion  or type of pasta
    /// </summary>
    protected string size, typeP;

    /// <summary>
    /// Gave access to size pasta
    /// </summary>
    public string Size
    {
        get { return size; }
    }

    /// <summary>
    /// access to type of pasta
    /// </summary>
    public string TypeP
    {
        get { return typeP; }
    }
    public Pasta() : this("little", "spaghetti") { }

    /// <summary>
    /// Initial object of class Pasta
    /// </summary>
    /// <param name="size"></param>
    /// <param name="typeP"></param>
    public Pasta(string size, string typeP)
    {
        if (!Enum.IsDefined(typeof(sizeDish), size))
            throw new ArgumentException("size of pasta is invalid");
        if (!Enum.IsDefined(typeof(typeOfPasta), typeP))
            throw new ArgumentException("Type of pasta is invalid");
        this.size = size;
        AddIngredient("pasta", typeP, 2);
        this.typeP = typeP;
        timeCooking = 25;
    }

    /// <summary>
    /// Count cost of pasta for size of portion pasta and type of pasta
    /// </summary>
    /// <returns>Suma of all ingredients in dish</returns>
    public override double CostDish()
    {
        double suma = 0;
        foreach (Ingredient ingr in ingredient) suma += ingr.CostIngredient; //suma with all ingredient
        switch (size) // add cost for size of panini
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
        switch (typeP) // add cost for type of pasta
        {
            case "spaghetti":
                suma += 30;
                break;
            case "bigoli":
                suma += 20;
                break;
            case "canalini":
                suma += 10;
                break;
            case "bavette":
                suma += 10;
                break;
        }

        return suma;
    }

    /// <summary>
    /// recipe how cook pasta
    /// </summary>
    /// <returns></returns>
    public new string HowCook()
    {
        return "Put the pasta in boiling water, boil, drain, add ingredients";
    }
}