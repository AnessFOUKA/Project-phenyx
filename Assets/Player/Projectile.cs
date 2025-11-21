using UnityEngine;

public class projectile : MonoBehaviour
{
    private Camera cam;
    public Vector3 speedVector;
    void Awake()
    {
        cam=Camera.main;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 view = cam.WorldToViewportPoint(transform.position);
        if (!(view.x < 0 || view.x > 1 || view.y < 0 || view.y > 1 || view.z < 0))
        {
            transform.position += speedVector * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
