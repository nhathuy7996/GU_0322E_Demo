using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaFactory : Animal
{
    public Animal CreateAnimal(typeAnimal typeAnimal)
    {
        switch (typeAnimal)
        {
            case typeAnimal.Dog:
                return new Dog();
                break;
            case typeAnimal.Cat:
                return new Cat();
                break;
                break;
            case typeAnimal.Duck:
                return new Duck();
                break;
            default:
                return new Duck();
                break;
        }

        
    }

    public enum typeAnimal
    {
        Dog,
        Cat,
        Cat1,
        Cat2,
        Duck
    }
}
