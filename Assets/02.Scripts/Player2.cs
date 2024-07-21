using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 5f;
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
        float h = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
            h = -1f;

        else if (Input.GetKey(KeyCode.RightArrow))
            h = 1f;

        // 방향 전환
        if (h < 0)
            spriteRenderer.flipX = true;
        else if (h > 0)
            spriteRenderer.flipX = false;

        // 속도 적용
        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        // 애니메이션 설정
        if (Mathf.Abs(h) > 0)
            ani.SetBool("isWalk", true);
            
        else
            ani.SetBool("isWalk", false);
    }
}