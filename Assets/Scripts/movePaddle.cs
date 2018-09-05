using System.Collections;
using UnityEngine;

public class movePaddle : MonoBehaviour {

    public string color;
    public float paddleSpeed;
    private Vector3 playerPos;

    // Use this for initialization
    void Start() {
        if (color == "Red")
            playerPos = new Vector3(18f, 0, 0);
        else if (color == "Blue")
            playerPos = new Vector3(-18f, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
		if (color == "Red")
        {
            float yPos = transform.position.y + (Input.GetAxisRaw("Red Vertical") * paddleSpeed);
            playerPos = new Vector3(18f, Mathf.Clamp(yPos, -7.5f, 7.5f), 0f);
            transform.position = playerPos;
        }
        else if (color == "Blue")
        {
            float yPos = transform.position.y + (Input.GetAxisRaw("Blue Vertical") * paddleSpeed);
            playerPos = new Vector3(-18f, Mathf.Clamp(yPos, -7.5f, 7.5f), 0f);
            transform.position = playerPos;
        }
	}
}
