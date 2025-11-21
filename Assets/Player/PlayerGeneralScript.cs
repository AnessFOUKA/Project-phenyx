using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System;
public class PlayerScript : MonoBehaviour
{
    public int width;
    public int heigth;
    private PlayerInputs input;
    public float Speed=5;
    public GameObject SpecialProjectile;
    public  GameObject StandardProjectile;
    public GameObject bomb;
    public float ShootLatency=0.1f;
    private List<Action> Attacks;
    private int attackIndex = 1;
    public int BombNb=3;
    public Camera cam;
    void Awake()
    {
        cam=Camera.main;
        input=new PlayerInputs();
        input.Player.Bomb.performed+=OnBomb;
        Attacks=new List<Action>()
        {
            () =>{
                List<List<float>> ShootPositions=new List<List<float>>()
                {
                    new List<float>(){-0.687f,0.071f},
                    new List<float>(){0.687f,0.071f}
                };
                foreach(List<float> i in ShootPositions)
                {
                    Instantiate(SpecialProjectile,new Vector3(transform.position.x+i[0],transform.position.y+i[1],transform.position.z),Quaternion.identity);
                }
            },
            () =>{
                List<List<float>> ShootPositions=new List<List<float>>()
                {
                    new List<float>(){-0.687f,0.071f},
                    new List<float>(){0.687f,0.071f}
                };
                foreach(List<float> i in ShootPositions)
                {
                    Instantiate(StandardProjectile,new Vector3(transform.position.x+i[0],transform.position.y+i[1],transform.position.z),Quaternion.identity);
                }
            }
        };

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
        transform.position+=((Vector3)input.Player.Move.ReadValue<Vector2>())*Time.deltaTime*Speed;
        transform.position+=cam.GetComponent<CameraController>().CamSpeedVector*Time.deltaTime;
        if (input.Player.Shoot.IsPressed()&&ShootLatency>=0.1)
        {
            OnShoot();
            ShootLatency=0;
        }else if(input.Player.Shoot.IsPressed()){
            ShootLatency+=1*Time.deltaTime;
        }
        
    }

    void OnShoot()
    {
        Attacks[attackIndex]();
        
    }

    void OnBomb(InputAction.CallbackContext ctx){
        if(BombNb>0){
            Instantiate(bomb,transform.position,Quaternion.identity);
            BombNb-=1;
        }
    }
}
