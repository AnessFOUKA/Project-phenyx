using UnityEngine;

public class SpecialProjectileScript : MonoBehaviour
{
    private Animator anim;
    private Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cam=Camera.main;
        anim=GetComponent<Animator>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (transform.position.y <= cam.transform.position.y+6f)
        {
            transform.position += new Vector3(0, 15f, 0) * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnAnimationEnd()
    {
        anim.speed=0f;
    }
}
