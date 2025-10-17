using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    public Rigidbody enemyRb;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player == null)
            return;
        GameManager gm = Object.FindFirstObjectByType<GameManager>();
        if (gm == null || !gm.gameStarted) return;
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        lookDirection.y = 0;
        enemyRb.AddForce(lookDirection * speed);
        // Smoothly rotate to face the player
        if (lookDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
}
