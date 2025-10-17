using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float minX = -76.436f;
    private float maxX = -45.6f;
    private float minZ = -37.8f;
    private float maxZ = -11.4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        // if the object goes out of bounds, destroy it
        if (pos.x < minX || pos.x > maxX || pos.z < minZ || pos.z > maxZ)
        {
            Debug.Log($"{gameObject.name} destroyed (out of bounds)");
            Destroy(gameObject);
        }
    }
}
