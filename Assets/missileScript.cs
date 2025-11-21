using UnityEngine;
using System.Collections.Generic;
public class missileScript : MonoBehaviour
{
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
        new List<float>(){6,-6,0},
        
        new List<float>(){0,12,0},
        new List<float>(){0,-12,0},
        new List<float>(){12,0,0},
        new List<float>(){-12,0,0},
        new List<float>(){-12,12,0},
        new List<float>(){-12,-12,0},
        new List<float>(){12,12,0},
        new List<float>(){12,-12,0}
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
                if (shootIndex>=frequence)
                {
                    foreach(List<float> i in projectilesDirection){
                        ThrowProjectile(i[0],i[1],i[2]);
                    }
                    shootIndex=0;
                    Destroy(gameObject);
                }
                transform.position+=(redBirdSpeedVector+cam.GetComponent<CameraController>().CamSpeedVector)*Time.deltaTime;
                shootIndex+=Time.deltaTime;
            eventIndex+=10f*Time.deltaTime;
        }
    }
        
}

