using UnityEngine;

public class FaderScript : MonoBehaviour
{
    private Camera cam;
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
        transform.position=new Vector3(cam.transform.position.x,cam.transform.position.y,0);
    }
}
