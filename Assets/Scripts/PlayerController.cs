using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;

    public float verticalInput;
    public float speed = 10.0f;
    private float minX = -75.436f;
    private float maxX = -46.735f;
    private float minZ = -36.792f;
    private float maxZ = -13.314f;

    private float mouseSensitivity = 10f;

    private float rotationY = 0f;

    public GameObject projectilePrefab;

    public Transform firePoint;
    public AudioClip fireSound;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY += mouseX; // accumulate horizontal rotation
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);

        // --- Player movement relative to facing direction ---
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        transform.position += moveDirection * speed * Time.deltaTime;

        // --- Clamp player's position inside the area ---
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedZ = Mathf.Clamp(transform.position.z, minZ, maxZ);
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);

        if (Input.GetMouseButtonDown(0))
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            audioSource.PlayOneShot(fireSound, 1.0f);
        }
    }
}
