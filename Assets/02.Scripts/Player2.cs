using UnityEngine;

public class Player2 : MonoBehaviour
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
    }

     void FixedUpdate()
    {
        float h = 0f;

        // A 키 (왼쪽) 또는 D 키 (오른쪽)이 눌렸는지 확인
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