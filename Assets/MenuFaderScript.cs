using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuFaderScript : MonoBehaviour
{
    private SpriteRenderer sr;
    public bool firstFadeDone=false;
    public bool doSecondFade=false;
    private PlayerInputs input;
    void Awake()
    {
        sr=GetComponent<SpriteRenderer>();
        input=new PlayerInputs();
        input.Player.Shoot.performed+=OnStart;

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
        if (!firstFadeDone && sr.color.a>0)
        {
            Color c = sr.color;
            c.a -= 0.3f * Time.deltaTime;   // fade sur 1 seconde
            sr.color = c;
            if (sr.color.a<=0)
            {
                firstFadeDone=true;
            }
        }

        if (doSecondFade && sr.color.a<1f)
        {
            Color c = sr.color;
            c.a += 0.3f * Time.deltaTime;   // fade sur 1 seconde
            sr.color = c;
        }else if(doSecondFade && sr.color.a>=1f)
        {
            doSecondFade=false;
            SceneManager.LoadScene("SampleScene");
        }
    }
    void OnStart(InputAction.CallbackContext ctx)
    {
        doSecondFade=true;
    }
}
