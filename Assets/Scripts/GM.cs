using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public bool spawnBall = true;
    public float resetDelay = 0.5f;
    public static GM instance = null;
    public GameObject ball;
    public int bluePoints = 0;
    public int redPoints = 0;
    public Text scoreText;
    //public int scoreLimit;
    public Text winText;
    public GameObject winTextObject;

    private Ball _ball;
    private string winner;
    private GameObject cloneBall;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        SetupBall();
    }

    public void Start()
    {
        _ball = ball.GetComponent<Ball>();
    }

    public void SetupBall()
    {
        cloneBall = Instantiate(ball, transform.position, Quaternion.identity) as GameObject;
    }

    public void UpdatePoints(string color)
    {
        //Add on a point to the correct team
        if (color == "Blue")
            bluePoints++;
        else if (color == "Red")
            redPoints++;

        //Update the score text
        scoreText.text = bluePoints + " - " + redPoints;

        //If someone reaches the score limit, end the game; if not, spawn the ball with the Reset Delay and destroy the old ball for good looks :)
        if (bluePoints >= PlayerPrefs.GetInt("Score Limit") || redPoints >= PlayerPrefs.GetInt("Score Limit"))
            EndGame();
        else
        {
            //Reset the ball
            Invoke("SetupBall", resetDelay);
        }
    }

    //Destroy the ball from the Boundary scripts
    public void DestroyBall()
    {
        Destroy(cloneBall);
    }

    public void EndGame()
    {
        //Stop the ball from spawning
        spawnBall = false;

        //Determine who the winner is
        if (bluePoints > redPoints)
            winner = "Blue";
        else if (redPoints > bluePoints)
            winner = "Red";

        //Deactivate the GM Game Object
        gameObject.SetActive(false);

        //Make the win text display the winner of the game
        winText.text = winner + " Wins!";   //We still keep a text type of the Win Text so we can edit the text

        //Activate the Win Text
        winTextObject.SetActive(true);      //Unity won't let you set a variable with the text type to active, so you need to make the text a game object then make the game object active       
    }
}
