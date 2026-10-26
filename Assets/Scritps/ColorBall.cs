using UnityEngine;
using UnityEngine.UIElements;

public class ColorBall : MonoBehaviour
{
    public float jumpForce = 6f;

    public Color blue = new Color(0.0f, 0.0f, 1.0f);
    public Color red = new Color(1.0f, 0.0f, 0.0f);
    public Color green = new Color(0.0f, 1.0f, 0.0f);
    public Color yellow = new Color(1.0f, 0.9f, 0.0f);
    public Color white = new Color(1.0f, 1.0f, 1.0f);

    public string currentColorName;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public GameObject GOP;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = rb.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetRandomColor();

        if (GOP != null)
        {
            Time.timeScale = 1f;
            GOP.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        if(Camera.main != null && transform.position.y < Camera.main.transform.position.y - 6f)
        {
            GameOverGame();
        }
    }
    void SetRandomColor()
    {
        int rnd = Random.Range(0, 5);

        switch (rnd)
        {
            case 0:
                currentColorName = "Blue";
                sr.color = blue;
                break;
            case 1:
                currentColorName= "Red";
                sr.color = red;
                break;
            case 2:
                currentColorName = "Green";
                sr.color = green;
                break;
            case 3:
                currentColorName = "Yellow";
                sr.color = yellow;
                break;
            case 4:
                currentColorName = "White";
                sr.color = white;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ChangeColor"))
        {
            SetRandomColor();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Blue") || collision.CompareTag("Red") || collision.CompareTag("Green") || collision.CompareTag("Yellow") || collision.CompareTag("White"))
        {
            if(collision.tag != currentColorName)
            {
                Debug.Log("GameOver");
                GameOverGame();
            }
        }

        if (collision.CompareTag("Score"))
        {
            GameManager.instance.AddScore();
            Destroy(collision.gameObject);
        }
    }
    void GameOverGame()
    {
        if(GOP !=  null)
        {
            Time.timeScale = 0f;
            GameManager.instance.SaveScore();
            GOP.SetActive(true);
        }
    }
}
