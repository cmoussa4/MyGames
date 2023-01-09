using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float jumpforce;
    public TMP_Text score;
    public TMP_Text highScore;
    [SerializeField] private Transform jumpeffectPos;
    public GameObject jumpParticles;
    private bool canjump = false;
    public int Score = 1;
    // Start is called before the first frame update
    void Start()
    {
        Score = 1;
        score.text = "Score: ";
        rb = GetComponent<Rigidbody2D>();
        highScore.text = PlayerPrefs.GetInt("HighScoreText", 0).ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        FlappyJump();
    }

    public void Update()
    {
        Inputs();
        if(Score > PlayerPrefs.GetInt("HighScoreText", 0))
        {
            PlayerPrefs.SetInt("HighScoreText", Score-1);
            highScore.text = (Score-1).ToString();
        }
       
    }
    void FlappyJump()
    {
        if (canjump)
        {
            rb.AddForce(new Vector2(0.0f, 0.1f * jumpforce), ForceMode2D.Impulse);
        }
        canjump = false;
    }

    void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canjump = true;
            FlappyJump();
            Instantiate(jumpParticles, jumpeffectPos.position, Quaternion.identity);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PipeTrigger"))
        {
            score.text = "Score: " + Score++.ToString();
            
        }
    }
    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = "0";
    }
} 