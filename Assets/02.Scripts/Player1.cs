using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator ani;
    private Transform tr;
    private float h = 0f;
    float speed = 5f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        tr = transform;
    }
    void FixedUpdate()
    {
        h = Input.GetAxisRaw("Horizontal");
        rb.AddForce(Vector2.right * h * speed);
    }
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            speed = 5f;
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            ani.SetBool("isWalk", true);
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            speed = 0f;
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            ani.SetBool("isWalk", false);
        }
    }
}
