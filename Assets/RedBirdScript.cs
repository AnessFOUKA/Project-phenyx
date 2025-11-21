using UnityEngine;
using System.Collections.Generic;
public class RedBirdScript : MonoBehaviour
{
    public float life=5;
    private float shootIndex=0;
    private float eventIndex=0;
    public Vector3 redBirdSpeedVector;
    public GameObject projectile;
    public float frequence;
    private Camera cam;
    public float destroyAt;
    private List<List<float>> projectilesDirection=new List<List<float>>(){
        new List<float>(){0,6,0},
        new List<float>(){0,-6,0},
        new List<float>(){6,0,0},
        new List<float>(){-6,0,0},
        new List<float>(){-6,6,0},
        new List<float>(){-6,-6,0},
        new List<float>(){6,6,0},
        new List<float>(){6,-6,0}
    };
    void Awake()
    {
        cam=Camera.main;
    }
    void ThrowProjectile(float x,float y,float z){
        projectile.GetComponent<projectile>().speedVector=new Vector3(x,y,z);
        Instantiate(projectile,transform.position,Quaternion.identity);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y<cam.transform.position.y+6f)
        {
            if (eventIndex<destroyAt)
            {
                if (shootIndex>=frequence)
                {
                    foreach(List<float> i in projectilesDirection){
                        ThrowProjectile(i[0],i[1],i[2]);
                    }
                    shootIndex=0;
                }
                transform.position+=(redBirdSpeedVector+cam.GetComponent<CameraController>().CamSpeedVector)*Time.deltaTime;
                shootIndex+=Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
            eventIndex+=10f*Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        // Vérifier le tag
        if (other.CompareTag("Projectile"))
        {
            if (life>0)
            {
                life-=30*Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }
        
}
