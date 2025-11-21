using UnityEngine;

public class Event1Script : MonoBehaviour
{
    private PlayerScript playerController;
    public SpriteRenderer fader;
    private CameraController camController;
    private Vector3 SpecialSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerController=GetComponent<PlayerScript>();
        camController=playerController.cam.GetComponent<CameraController>();
        SpecialSpeed=new Vector3(0f,5f,0f);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //y=165.78 event trigger
        if (transform.position.y>=200)
        {
            if (camController.CamSpeedVector.y>0)
            {
                camController.CamSpeedVector-=new Vector3(0f,0.3f,0f)*Time.deltaTime;
            }
            else
            {
                if (fader.color.a < 255f)
                {
                    Color c = fader.color;
                    c.a += 0.3f * Time.deltaTime;   // fade sur 1 seconde
                    fader.color = c;
                }
            }
            if (SpecialSpeed.y>0)
            {
                transform.position+=SpecialSpeed*Time.deltaTime;
            }
        }
        else
        {
            if (fader.color.a > 0f)
            {
                Color c = fader.color;
                c.a -= 0.3f * Time.deltaTime;   // fade sur 1 seconde
                fader.color = c;
            }
        }
    }
}
