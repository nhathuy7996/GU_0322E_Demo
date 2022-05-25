using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFactory : MonoBehaviour
{
  
    Animal animal;
    AnimaFactory animaFactory = new AnimaFactory();
    // Start is called before the first frame update
    void Start()
    {
        animal = animaFactory.CreateAnimal(AnimaFactory.typeAnimal.Cat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
