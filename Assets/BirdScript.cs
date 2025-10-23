using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    public float flapStrength;
    public LogicScript logic;
    public bool isBirdAlive = true;

    private float maxYOffset = 17;
    private float minYOffset = -17;

    void Awake()
    {
        // spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        // InvokeRepeating(nameof(animateSprite), 0.15f, 0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Keyboard.current.spaceKey.wasPressedThisFrame || Input.GetMouseButtonDown(0)) && isBirdAlive)
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
        }
  
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == UnityEngine.TouchPhase.Began)
            {
                myRigidBody.linearVelocity = Vector2.up * flapStrength;
            }
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
    
    private void animateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
