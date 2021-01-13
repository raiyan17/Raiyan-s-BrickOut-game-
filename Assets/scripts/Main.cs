using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// This class allows to load the game from the main menu 
public class Main : MonoBehaviour
{
        public void Startgame() //  Method which is called when at the main menu to start the game 
        {
            SceneManager.LoadScene("BrickOut Game"); //Loads the scene with the game  
        }
    
}
