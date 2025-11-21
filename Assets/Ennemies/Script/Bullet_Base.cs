using UnityEngine;
using UnityEngine.Rendering;

public class Bullet_Base : MonoBehaviour
{
    [Header("Stats générales")]
    public float dammage = 5f;
    public float moveSpeed = 10f;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
