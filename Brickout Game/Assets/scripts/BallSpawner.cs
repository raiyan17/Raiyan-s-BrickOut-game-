using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// This class describes an object which can spawn ball gameobjects by copying
// a template of the ball gameobject which is already within the scene .

class BallSpawner : MonoBehaviour
{
   //Declaration of variables 

    // Sets balltemplate to the existing ball object 
    
    public ball ballTemplate;
    
   // The number of balls that are spawned initially is 1 
     int ballnumber = 1;
    public Bricks br; // reference to bricks script 
    // This method spawns the ball  template 
    void Start()
    {


        // Spawns ball using the parameter "ball template"
            SpawnBall(ballTemplate);
                
    }

    public void SpawnBall(ball template) //  Method which creates a clone of the ball object  
    
    {
        // Creats a clone of the template gameobject 
        ball Clone = Instantiate(template);

        // Moves the  ball clone to the spawner's position

        Clone.transform.position = transform.position;

        // Gives the ball clone a random direction within a certain range of numbers 
        int angle = Random.Range(-40,-180);

        //calls the setdirection method from ball class and sets the clone's direction to the angle 
        Clone.SetDirection(angle); 

        // Activates the ball clone in Unity 
  
        Clone.gameObject.SetActive(true);

    }

}


