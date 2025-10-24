using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private LogicScript logic;
    public float moveSpeed = 5;
    public float deadZone = -45;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("Coin deleted");
            Destroy(gameObject);
        }

    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // gameObject.SetActive(false);
            // logic.increasePowerUpCount(1);
        }
    }
}
