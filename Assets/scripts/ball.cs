using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// This class decribes the movement of the ball and sets conditions for when it hits bricks and  the barriers. 
class ball : MonoBehaviour
{


    public BallSpawner spawner ;  // reference to BallSpawner script 
    public Bricks br; // reference to Bricks script 
    public Paddle paddle; // reference to paddle script 
    float size = 0.5f; // sets value for size 
    float speed = 0.115f; // sets value for speed  
    float directionX = 0.55f; // initial value for horizontal direction 
    float directionY = 0.55f; //  initial value for vertical direction 
    new AudioSource audio; // reference to audiosource component 
     
    // Start is called before the first frame update

    void Start()
    {

        audio = GetComponent<AudioSource>(); // gives audio variable the value of AudioSource component attached to Ball   


    }

    // Update is called once every frame
    public void Update()

    {

    
        

        Vector2 position = transform.localPosition; // Positions the ball to where it is positioned in Unity         position.x += speed * directionX; // sets the x value of the component         position.y += speed * directionY;// sets the y value of the component 
        transform.localPosition = position; // 



    }
    


    // This method is run by Unity whenever the ball hits something. The 'other' parameter
    // contains details about the collision, including the other game object that was hit.
    void OnCollisionEnter2D(Collision2D col)

    { // This switch statement compares the other game object name to each of the cases
      // within the switch. If the other game object name matches one of the cases then
      // all the statements underneath that case will be run, until the break statement.

        // Switch statment which compares the "col" gameobject  to the cases named within the statement 
        // If there is a collision with one of the matched cases then the directives(commands) below the case will be carried out 
        switch (col.gameObject.name)  
        {

            case "Paddle": // if the  gamobject has  a collision with anything   named "Right barrier"  "paddle"
            case "Top barrier": // if the  gameobject   has  a collision with anything   named "Right barrier"   "Top barrier"

                directionY = -directionY; // if any cases are matched above, this changes the direction of the ball vertically 
                break; //ends statement   

            case "Left barrier":// if the  gameobject has  a collision with anything   named "Left barrier"
            case "Right barrier": // if the  gameobject  has  a collision with anything   named "Right barrier"

                directionX = -directionX; // if any cases are matched above, this changes the direction of the ball horizontally  
                break; //ends statement   


        }
        switch (col.gameObject.tag) // switch statment which compares the col gameobject  with tags described within the cases 
        {
            case "Brick": // if the  gameobject has a collision with  anything with tag "Brick" 
                directionY = -directionY; // Direction of ball changes vertically 
                br.IncreaseScore(); // Method is called from bricks class to increase the score by 1 after hitting  "Brick" 
                audio.Play(); //Plays audio if  ball hits   "brick"
                br.BrickArray(); // Method is called from bricks class to subtract a brick from the brick array 
                break; //ends statement   


            case "Bottom barrier":  // if the  gameobject has a collision with anything with tag  "Bottom barrier"
                br.Updatelives(); // Method is called from bricks class to decrease lives by 1 after hitting "Bottom barrier"
                spawner.SpawnBall(this); //  Method is called from Ball Spawner class which respawns ball back 
                break;//ends statement   
        }
      




    }
    public void SetDirection(int angleInDegrees) // Method which sets the direction for the ball. It is given the 'angleInDegrees' parameter 
    {
        float angleInRadians = angleInDegrees * Mathf.Deg2Rad; //converts angle in degrees to angle in radians 
        directionX = Mathf.Cos(angleInRadians);// Sets the variable to the horizontal componnent using the Cos  Function
        directionY = Mathf.Sin(angleInRadians); // Sets the variable to the vertcial componnent using the Sin  Function
    }
  


}
