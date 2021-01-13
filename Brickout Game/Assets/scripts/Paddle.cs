using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class describes movement, positioning and defines perimeters for the paddle 
class Paddle : MonoBehaviour
{

    float speed = 0.15f; //variable for paddle speed 
    float direction = 0.0f; //variable for paddle direction 
    public KeyCode moveRightKey = KeyCode.RightArrow; //variable given the value of the right arrow key 
    public KeyCode moveLeftKey = KeyCode.LeftArrow; //variable given the value of the left  arrow key 
    bool PositiveMotion = true; //variable to allow  movement to the right 
    bool NegativeMotion = true; //  //variable to allow movement to the left
    public Bricks br; // reference to bricks script 
    
    // Method which sets the paddle's position 
    void FixedUpdate  ()
    {
        Vector2 position = transform.localPosition; // Sets the position of paddle to the chosen position within Unity 
        position.x += speed * direction; //sets x value of the component 
        transform.localPosition = position;// 

    }





    //Method which gives the paddle movement if conditions  are met (if keys are pressed)
    public void Update()
    {
        bool RightKey = Input.GetKey(moveRightKey); //Gives local variable the value as the right arrow key input 
        bool LeftKey = Input.GetKey(moveLeftKey);//Gives local variable the value as the left arrow key input 
        if (RightKey && PositiveMotion)// if both conditions are met (if right key is pressed)
        {
            direction = 1.0f; // paddle moves to the right 
        }
        else if (LeftKey && NegativeMotion) // else if both conditions are met (if left key is pressed)
        {
            direction = -1.0f; // paddle moves to the left  
        }
        else 
        {
            direction = 0.0f; // if no button pressed, paddle remains stationary 
        }
        


    }

    void OnCollisionEnter2D(Collision2D col)//Method for the paddle to restrict movement beyond the barriers when it hits them 
    {
        switch (col.gameObject.name) //switch statement which compares gameobject to the values described within the case  
        {
            case "Right barrier": // if paddle hits the right barrier 
                PositiveMotion = false; // , movement to the right is restrcited 
                break;//end statment 

            case "Left barrier": //   if paddle hits Left barrier
                NegativeMotion = false; // , movement to the left is restricted 
                break; // end statement
        }
        
    }
    void OnCollisionExit2D(Collision2D other) // Method which allows paddle to move again after hitting the barriers( creates perimeter for paddle ) 
    {
        switch (other.gameObject.name) //switch statement which compares gameobject to the values described within the case  
        {
            case "Right barrier": 
                PositiveMotion = true; // allows for movement to the right again 
                break;  // end statement

            case "Left barrier":
                NegativeMotion = true; // allows for movement to the left again 
                break; // end statement
        }
    }
    
}
