using System;
using System.Collections.Generic;

namespace InstructorIQ.Core.Tests.Samples
{
    public class Fruit
    {
        public string Name { get; set; }

        public int Rank { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Rank)}: {Rank}";
        }

        public static List<Fruit> Data()
        {
            return new List<Fruit>
            {
                new Fruit{ Name = "Pear", Rank = 1 },
                new Fruit{ Name = "Pineapple", Rank = 4 },
                new Fruit{ Name = "Peach", Rank = 2 },
                new Fruit{ Name = "Apple", Rank = 3 },
                new Fruit{ Name = "Grape", Rank = 5 },
                new Fruit{ Name = "Orange", Rank = 6},
                new Fruit{ Name = "Strawberry", Rank = 7 },
                new Fruit{ Name = "Blueberry", Rank = 7 },
                new Fruit{ Name = "Banana", Rank = 8 },
                new Fruit{ Name = "Raspberry", Rank = 7 }
            };
        }
    }
}