using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// This class describes how collision with the brick affect other components such as lives, score 
//and defines what happens when it comes into contact with the ball 
 class Bricks : MonoBehaviour
{ //Declaration all of variables 

    public ball Ball; //reference to ball script 
      int lives = 3; // variable to track  lives 
    public int score; // variable to track score
    public Text scoreLabelText; // variable for text for score 
    public Text livesText; // variable for text for lives
    bool PlayGame = true; // variable for if the game is in play 
    public  int bricknumber; // Varaible to track number of bricks 
    public Text GameOver = null; // Variable for Gameover Text 
    public Paddle Paddle; // Reference to paddle script 
    BallSpawner spawn; // Refrence for bBallSpawner Script 

    // This method is carried out before the first frame 
    public  void Start()
    {
       bricknumber = GameObject.FindGameObjectsWithTag("Brick").Length; // Gives the variable "bricknumber" the value of the number of bricks within the array 

       livesText.text = lives.ToString("Lives: " + lives); // Converts the text to string message 
       
       scoreLabelText.text = score.ToString("Score: " + score); // Converts the text to string message 
        
    }


    
    
    public void Updatelives() //Method which deducts lives from the player 

    { 
        lives--; // Decrements the number of lives by 1 
        livesText.text = lives.ToString(" Lives: " + lives); // Lives Text is updated on screen, showing the new value for the variable 'lives'
        {
            if (lives == 0) // if the amount of lives reaches 0, 
                gameOver(); //the gameOver method is called and executed(Ends the game)

        }
    }

        public void IncreaseScore() // method which updates the player's score 
    {
        score++; //increments the score by 1 
        scoreLabelText.text = score.ToString("Score: " + score); // score Text is updated on screen, showing the new value for the variable 'score'
        { if (score == 32) // sets a condition if the score is equal to 32
                gameOver();//the gameOver method is called and executed(Ends the game)
        }
    }
    public void BrickArray()// method which is called to detract bricks from an array 
    {
        bricknumber--; //decrements  1  brick each time this method is called 



        {
            if (bricknumber == 0) // if the number of bricks reaches zero, 
                gameOver(); //the gameOver method is called and executed(Ends the game)


        }


    }

    public void gameOver() // Method to end the game 
    {
        PlayGame = false; //  Sets the value to false making the game end 
        GameOver.gameObject.SetActive(true); // Game Over message is activated and shown on screen 
        spawn.gameObject.SetActive(false); //Makes the ball inactive  to siginify end game 
        Paddle.gameObject.SetActive(false); // Makes the paddle inactive  to siginify end game 



    }
    public void OnCollisionEnter2D(Collision2D other) 
        // Method which detects collisions for the brick object 
        //with the parameters set to 'other' which contains information about the collisions 
        
    {
        if (other.gameObject.tag == "Ball") // makes a collision with the Brick(s) if the condition in which  gameObject with the Tag "Ball" is fulfilled
            BrickArray();// Method is called to subtract 1 brick from the brick array 
        Destroy(gameObject);// Destroys  Brick object the ball has a collision with 
  

    }


   
}

