using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
public class PlayerScript : MonoBehaviour
{
    private PlayerInputs input;
    public float Speed=5;
    public GameObject SpecialProjectile;
    public float ShootLatency=60;
    void Awake()
    {
        input=new PlayerInputs();
    }

    void OnEnable()=>input.Enable();
    void OnDisable()=>input.Disable();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=(Vector3)input.Player.Move.ReadValue<Vector2>()*Time.deltaTime*Speed;
        if (input.Player.Shoot.IsPressed()&&ShootLatency>=60)
        {
            OnShoot();
            ShootLatency=0;
        }else if(input.Player.Shoot.IsPressed()){
            ShootLatency+=1;
        }
        else
        {
            ShootLatency=60;
        }
    }

    void OnShoot()
    {
        List<List<float>> ShootPositions=new List<List<float>>()
        {
            new List<float>(){-0.687f,0.071f},
            new List<float>(){0.687f,0.071f}
        };
        foreach(List<float> i in ShootPositions)
        {
            Instantiate(SpecialProjectile,new Vector3(transform.position.x+i[0],transform.position.y+i[1],transform.position.z),Quaternion.identity);
        }
        
    }
}
