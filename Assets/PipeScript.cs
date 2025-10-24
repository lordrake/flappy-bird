using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public GameObject coin;

    public float moveSpeed = 5;
    public float deadZone = -45;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Random.value < 0.5f)
        {
            spawnCoin();   
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe deleted");
            Destroy(gameObject);
        }
    }

    void spawnCoin()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(coin, position, transform.rotation);
    }
}
