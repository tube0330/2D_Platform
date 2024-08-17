using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    float speed = 1f;
    private Rigidbody2D rb;
    private Animator ani;
    private Transform tr;
    private float h = 0f;

    void Start()
    {
        tr = transform;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        h = 0f;
        float v = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.A))
            h = -1f;

        else if (Input.GetKey(KeyCode.D))
            h = 1f;

        // 방향 전환
         if (h > 0)
            spriteRenderer.flipX = true;

        else if (h < 0)
            spriteRenderer.flipX = false;

        // 속도 적용
        rb.velocity = new Vector2(h * speed, rb.velocity.y);

         // 애니메이션 설정
        if (Mathf.Abs(h) > 0)
            ani.SetBool("isWalk", true);

        else
            ani.SetBool("isWalk", false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 1f, ForceMode2D.Impulse);
            ani.SetTrigger("Jump");
        }

    }
}
