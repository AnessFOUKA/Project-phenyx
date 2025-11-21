using UnityEngine;
using System.Collections.Generic;
public class BombScript : MonoBehaviour
{
    private Vector3 Vectorspeed = new Vector3(0,10,0);
    public GameObject projectile;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void ThrowProjectile(float x,float y,float z){
        projectile.GetComponent<projectile>().speedVector=new Vector3(x,y,z);
        Instantiate(projectile,transform.position,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=Vectorspeed*Time.deltaTime;
        if(Vectorspeed.y>=0){
            Vectorspeed-=new Vector3(0,20,0)*Time.deltaTime;
        }else{
            foreach(List<float> i in projectilesDirection){
                ThrowProjectile(i[0],i[1],i[2]);
            }
            Destroy(gameObject);
        }
    }
}
