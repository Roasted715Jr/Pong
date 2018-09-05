using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    
    public int xDirection;
    public float ballInitialVelocity = 1000f;
    public GM GM;

    private Rigidbody rb;
    private bool ballInPlay = false;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        GM = GetComponent<GM>();
    }

    void Start()
    {
        if (Random.value <= 0.5f)
            xDirection = 1;
        else
            xDirection = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity * xDirection, ballInitialVelocity * Random.value, 0));
        }
    }
}
