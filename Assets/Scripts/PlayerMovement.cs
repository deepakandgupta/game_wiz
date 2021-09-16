using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 1500f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Text score;
    public GameObject RemovingObject;

    private float topScore = 0f;
    private float moveForce;

    [SerializeField]
    AudioSource jumpN;
    [SerializeField]
    AudioSource jump1;
    [SerializeField]
    AudioSource jumpS;

    [SerializeField]
    AudioSource crossed1kSound;

    private float dir = -1f;

    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        // Reset the score to 0 for inital render
        PlayerPrefs.SetFloat("lastScore", 0);

        // Hide all other children characters
        for (int i=0;i<transform.childCount;i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        // Selected character to active, if not found default to 1st character
        int selInd = PlayerPrefs.GetInt("selChar", 0);
        transform.GetChild(selInd).gameObject.SetActive(true);
    }

    void Update()
    {
        moveForce = Input.acceleration.x;

        float posScore = rb.transform.position.y * 10;

        // Update score only when player moves up
        if (rb!=null && rb.velocity.y >0 && posScore > topScore)
        {
            topScore = Mathf.Round(posScore);
            score.text = "Score: " + topScore.ToString();

            PlayerPrefs.SetFloat("lastScore", topScore);
            float highScore = PlayerPrefs.GetFloat("highscore", 0);
            if (topScore >0 && topScore % 1000 == 0 && crossed1kSound!=null) {
                crossed1kSound.Play();
            }
            if (highScore < topScore) {
                PlayerPrefs.SetFloat("highscore", topScore);
            }
        }
    }

    void FixedUpdate()
    {
        if (rb != null) {
            rb.velocity = new Vector2(moveForce * Time.deltaTime * speed, rb.velocity.y);

            if (rb.velocity.x < -1)
            {
                dir = 1;
            }
            else if (rb.velocity.x > 1)
            {
                dir = -1;
            }
            transform.localScale = new Vector3(dir, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform1Time" && collision.relativeVelocity.y > 0)
        {
            collision.transform.position = RemovingObject.transform.position;
            jump1.Play();
        }
        else if (collision.gameObject.tag == "PlatformNormal" && collision.relativeVelocity.y > 0)
        {
            jumpN.Play();
        }
        else if (collision.gameObject.tag == "PlatformSpring" && collision.relativeVelocity.y > 0)
        {
            jumpS.Play();
        }
    }
}
