using System.Collections;
using UnityEngine;

public class boundary : MonoBehaviour {

    public GM GM;
    public string color;

    public void Start()
    {
        GM = GetComponent<GM>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GM.instance.DestroyBall();
            GM.instance.SetupBall();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            if (color == "Red")
            {
                GM.instance.DestroyBall();
                GM.instance.UpdatePoints("Blue");
            } else if (color == "Blue") {
                GM.instance.DestroyBall();
                GM.instance.UpdatePoints("Red");
            }
        }
    }
}
