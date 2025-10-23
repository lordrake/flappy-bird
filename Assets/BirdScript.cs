using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool isBirdAlive = true;

    private float maxYOffset = 17;
    private float minYOffset = -17;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isBirdAlive)
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
        }

        if (myRigidBody.position.y >  maxYOffset || myRigidBody.position.y < minYOffset)
        {
            logic.gameOver();
            isBirdAlive = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBirdAlive)
        { 
            logic.gameOver();
            isBirdAlive = false;
        }
    }
}
