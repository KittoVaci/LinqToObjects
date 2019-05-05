using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_LinqToObjects
{
  class LinqToObjects
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Press ENTER to run without debug prints,");
      Console.WriteLine("Press D1 + ENTER to enable some debug prints,");
      Console.Write("Press D2 + ENTER to enable all debug prints: ");
      string command = Console.ReadLine().ToUpper();
      DebugPrints1 = command == "D2" || command == "D1" || command == "D";
      DebugPrints2 = command == "D2";
      Console.WriteLine();

      var groupA = new Group();

      // Hubert, Anna
      HighlightedWriteLine("Assignment 1: Vsechny osoby, ktere nepovazuji nikoho za sveho pritele.");
      var Assigment1 = from person in groupA where person.Friends.Count() == 0 select person;
      MainLine();
      foreach (var item in Assigment1)
      {
        MainSolution(item.ToString());
      } 

      Console.WriteLine();
      // Daniel, Emil, Ursula, Vendula
      HighlightedWriteLine("Assignment 2: Vsechny osoby setridene vzestupne podle jmena, ktere jsou starsi 15 let, a jejichz jmeno zacina na pismeno D nebo vetsi.");
      var Assigment2 = from person in groupA where person.Age > 15 && person.Name[0] >= 'D' orderby person.Name select person;
      MainLine();
      foreach (var item in Assigment2)
      {
        MainSolution(item.ToString());
      }

      Console.WriteLine();
      // Ursula, Vendula
      HighlightedWriteLine("Assignment 3: Vsechny osoby, ktere jsou ve skupine nejstarsi, a jejichz jmeno zacina na pismeno T nebo vetsi.");
      var Assigment3 = from person in groupA
                       where person.Name[0] >= 'T' 
                        && person.Age == groupA.Max( all => all.Age)
                       select person;
      MainLine();
      foreach (var item in Assigment3)
      {
        MainSolution(item.ToString());
      }

      Console.WriteLine();
      // Hubert, Anna, Ursula, Vendula, Cyril
      HighlightedWriteLine("Assignment 4: Vsechny osoby, ktere jsou starsi nez vsichni jejich pratele.");
      var Assigment4 = from person in groupA
                       where person.Friends.Count() == 0 
                         ? true 
                         : person.Age >= person.Friends.Max(x => x.Age)
                       select person;
      MainLine();
      foreach (var item in Assigment4)
      {
        MainSolution(item.ToString());
      }

      Console.WriteLine();
      // Hubert
      HighlightedWriteLine("Assignment 5: Vsechny osoby, ktere nemaji zadne pratele (ktere nikoho nepovazuji za sveho pritele, a zaroven ktere nikdo jiny nepovazuje za sveho pritele).");
      var Assigment5 = from person in groupA
                       where person.Friends.Count() == 0
                         && groupA.Where(p => p.Friends.Contains(person)).Count() == 0
                       select person;
      MainLine();
      foreach (var item in Assigment5)
      {
        MainSolution(item.ToString());
      }

      Console.WriteLine();
      // Anna, Ursula, Vendula, Blazena, Daniela, Usula, Vendula, Emil, Daniela, Frantisek
      HighlightedWriteLine("Assignment 6: Vsechny osoby, ktere jsou necimi nejstarsimi prateli (s opakovanim).");
      var Assigment6 = from person in groupA
                       from friend in person.Friends
                       where person.Friends.All(p => p.Age <= friend.Age)
                       select friend;
      MainLine();
      foreach (var item in Assigment6)
      {
        MainSolution(item.ToString());
      }

      Console.WriteLine();
      // Anna, Ursula, Vendula, Blazena, Daniela, Emil, Frantisek
      HighlightedWriteLine("Assignment 6B: Vsechny osoby, ktere jsou necimi nejstarsimi prateli (bez opakovani).");
      var Assigment6B = from person in groupA
                       where groupA.Where(
                         p => p.Friends.Contains(person) && p.Friends.All(f => person.Age >= f.Age)
                       ).Any()
                       select person;
      MainLine();
      foreach (var item in Assigment6B)
      {
        MainSolution(item.ToString());
      }
      // také by šlo udělat : var Assigment6B = Assigment6.Distinct()
      // Ale musíme se spoléhat, že Assigment6 je správně

      Console.WriteLine();
      // Blazena, Daniela, Emil, Daniela
      HighlightedWriteLine("Assignment 7: Vsechny osoby, ktere jsou nejstarsimi prateli osoby starsi nez ony samy (s opakovanim).");
      var Assigment7 = from person in groupA
                       from friend in person.Friends
                       where person.Age > friend.Age && person.Friends.All(p => p.Age <= friend.Age)
                       select friend;
      MainLine();
      foreach (var item in Assigment7)
      {
        MainSolution(item.ToString());
      }

      Console.WriteLine();
      // Blazena, Daniela, Emil
      HighlightedWriteLine("Assignment 7B: Vsechny osoby, ktere jsou nejstarsimi prateli osoby starsi nez ony samy (bez opakovani).");
      var Assigment7B = from person in groupA
                        where groupA.Where(
                          p => p.Friends.Contains(person) 
                            && p.Friends.All(f => person.Age >= f.Age)
                            && p.Age > person.Age
                        ).Any()
                        select person;
      MainLine();
      foreach (var item in Assigment7B)
      {
        MainSolution(item.ToString());
      }

      // také by šlo udělat : var Assigment7B = Assigment7.Distinct()
      // Ale musíme se spoléhat, že Assigment7 je správně

      Console.WriteLine();
      // Emil, Daniela, Blazena
      HighlightedWriteLine("Assignment 7C: Vsechny osoby, ktere jsou nejstarsimi prateli osoby starsi nez ony samy (bez opakovani a setridene sestupne podle jmena osoby).");
      var Assigment7C = from person in groupA
                        where groupA.Where(
                          p => p.Friends.Contains(person)
                            && p.Friends.All(f => person.Age >= f.Age)
                            && p.Age > person.Age
                        ).Any()
                        orderby person.Name descending
                        select person;
      MainLine();
      foreach (var item in Assigment7C)
      {
        MainSolution(item.ToString());
      }
      // také by šlo udělat : var Assigment7C = Assigment7.Distinct().OrderByDescending( p => p.Name )
      // nebo také: var Assigment7C = Assigment7B.OrderByDescending( p => p.Name )
      // Ale musíme se spoléhat, že Assigment7 nebo Assigment7B (respektivě) je správně
    }

    public static void HighlightedWriteLine(string s)
    {
      ConsoleColor oldColor = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine(s);
      Console.ForegroundColor = oldColor;
    }
    public static void MainLine() => Console.WriteLine("Main: foreach:");
    public static void MainSolution(string s) => Console.WriteLine("Main: got " + s);

    public static bool DebugPrints1 = false;
    public static bool DebugPrints2 = false;

    class Person
    {
      public string Name { get; set; }
      public int Age { get; set; }
      public IEnumerable<Person> Friends { get; private set; }

      /// <summary>
      /// DO NOT USE in your LINQ queries!!!
      /// </summary>
      public IList<Person> FriendsListInternal { get; private set; }

      class EnumWrapper<T> : IEnumerable<T>
      {
        IEnumerable<T> innerEnumerable;
        Person person;
        string propName;

        public EnumWrapper(Person person, string propName, IEnumerable<T> innerEnumerable)
        {
          this.person = person;
          this.propName = propName;
          this.innerEnumerable = innerEnumerable;
        }

        public IEnumerator<T> GetEnumerator()
        {
          if (LinqToObjects.DebugPrints1) Console.WriteLine(" # Person(\"{0}\").{1} is being enumerated.", person.Name, propName);

          foreach (var value in innerEnumerable)
          {
            yield return value;
          }

          if (LinqToObjects.DebugPrints2) Console.WriteLine(" # All elements of Person(\"{0}\").{1} have been enumerated.", person.Name, propName);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
          return GetEnumerator();
        }
      }

      public Person()
      {
        FriendsListInternal = new List<Person>();
        Friends = new EnumWrapper<Person>(this, "Friends", FriendsListInternal);
      }

      public override string ToString()
      {
        return string.Format("Person(Name = \"{0}\", Age = {1})", Name, Age);
      }
    }

    class Group : IEnumerable<Person>
    {
      Person anna, blazena, ursula, daniela, emil, vendula, cyril, frantisek, hubert, gertruda;

      public Group()
      {
        anna = new Person { Name = "Anna", Age = 22 };
        blazena = new Person { Name = "Blazena", Age = 18 };
        ursula = new Person { Name = "Ursula", Age = 22, FriendsListInternal = { blazena } };
        daniela = new Person { Name = "Daniela", Age = 18, FriendsListInternal = { ursula } };
        emil = new Person { Name = "Emil", Age = 21 };
        vendula = new Person { Name = "Vendula", Age = 22, FriendsListInternal = { blazena, emil } };
        cyril = new Person { Name = "Cyril", Age = 21, FriendsListInternal = { daniela } };
        frantisek = new Person { Name = "Frantisek", Age = 15, FriendsListInternal = { anna, blazena, cyril, daniela, emil } };
        hubert = new Person { Name = "Hubert", Age = 10 };
        gertruda = new Person { Name = "Gertruda", Age = 10, FriendsListInternal = { frantisek } };

        blazena.FriendsListInternal.Add(ursula);
        blazena.FriendsListInternal.Add(vendula);
        ursula.FriendsListInternal.Add(daniela);
        daniela.FriendsListInternal.Add(cyril);
        emil.FriendsListInternal.Add(vendula);
      }

      public IEnumerator<Person> GetEnumerator()
      {
        if (LinqToObjects.DebugPrints1) Console.WriteLine("*** Group is being enumerated.");

        yield return hubert;
        yield return anna;
        yield return frantisek;
        yield return blazena;
        yield return ursula;
        yield return daniela;
        yield return emil;
        yield return vendula;
        yield return cyril;
        yield return gertruda;

        if (LinqToObjects.DebugPrints1) Console.WriteLine("*** All elements of Group have been enumerated.");
      }

      System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
      {
        return GetEnumerator();
      }
    }
  }
}
