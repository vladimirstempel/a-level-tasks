using System;

class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    public void MakeSound()
    {
        Console.WriteLine($"{Name} makes a sound.");
    }
}

class Dog : Animal
{
    public Dog(string name) : base(name)
    {
    }

    public void Bark()
    {
        Console.WriteLine($"{Name} barks.");
    }
}

class Example5
{
    static void Main()
    {
        Dog myDog = new Dog("Buddy");

        myDog.MakeSound();

        myDog.Bark();
    }
}