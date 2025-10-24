using System.Collections;
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

    public CoinScript coin;

    public GameObject invincibilityCloak;
    public bool isBirdAlive = true;

    private float maxYOffset = 17;
    private float minYOffset = -17;

    public bool isInvincible = false;
    public float invincibleDuration = 5f;

    void Awake()
    {
        // spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        // coin = GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinScript>();

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
        if (isInvincible)
        {
            Debug.Log("Invincible!");
            return;
        }
        
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Example: Collect power-ups
        if (other.CompareTag("Coin"))
        {
            logic.increasePowerUpCount(1);
            Destroy(other.gameObject);

            Debug.Log(logic.powerUpCount + " - " + logic.powerUpGoal + " - " +  isInvincible);

            if (logic.powerUpCount >= logic.powerUpGoal && !isInvincible)
            {
                StartCoroutine(ActivateInvincibility());
            }
        }
    }

    private System.Collections.IEnumerator ActivateInvincibility()
    {
        Debug.Log("Invincible!");
        isInvincible = true;
        logic.powerUpText.color = Color.orange;
        invincibilityCloak.SetActive(true);


        StartCountdown();
        yield return new WaitForSeconds(invincibleDuration);

        isInvincible = false;
        invincibilityCloak.SetActive(false);
        logic.powerUpText.color = new Color32(207, 0, 255, 255);
        Debug.Log("Invincibility ended!");
        logic.resetPowerUps();


        // Optionally reset power-ups
    }
    
    public void StartCountdown()
    {
        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        float remainingTime = invincibleDuration;

        while (remainingTime > 0)
        {
            logic.hintText.text = "Invincible! " + Mathf.CeilToInt(remainingTime);
            remainingTime -= Time.deltaTime;
            yield return null; // wait for next frame
        }


        logic.hintText.text = "Shield deactived, be careful!";
        yield return new WaitForSeconds(2);
        logic.hintText.text = "";
    }
}

