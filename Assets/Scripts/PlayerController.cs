using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Sprite idleSprite;
    public Sprite walkRight1;
    public Sprite walkRight2;
    public Sprite walkLeft1;
    public Sprite walkLeft2;

    private SpriteRenderer spriteRenderer;
    private float animationTimer;
    private bool toggleSprite;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * moveX * moveSpeed * Time.deltaTime);

        if (Mathf.Abs(moveX) > 0.01f)
        {
            AnimateWalk(moveX);
        }
        else
        {
            spriteRenderer.sprite = idleSprite;
        }
    }

    void AnimateWalk(float direction)
    {
        animationTimer += Time.deltaTime;

        if (animationTimer >= 0.2f)
        {
            animationTimer = 0f;
            toggleSprite = !toggleSprite;

            if (direction > 0)
            {
                spriteRenderer.sprite = toggleSprite ? walkRight1 : walkRight2;
            }
            else
            {
                spriteRenderer.sprite = toggleSprite ? walkLeft1 : walkLeft2;
            }
        }
    }
}
