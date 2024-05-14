using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerLevel2 : MonoBehaviour
{
    public float speed;
    Rigidbody rb;

    public AudioClip coinClip, winnerClip, loserClip;
    public AudioSource source;
    float xInput;
    float yInput;

    int score = 0;
    public int winScore;
    public GameObject GameOverText;
    public GameObject gameOverText; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y < -60f)
        {
            SceneManager.LoadScene("level1");
        }
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        rb.AddForce(xInput * speed, 0, yInput * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            source.PlayOneShot(coinClip);
            score++;

            if (score >= winScore)
            
            {
                GameOverText.SetActive(true);
                source.PlayOneShot(winnerClip);
            }
        }
        else if (other.gameObject.tag == "Finish")
        {
            source.PlayOneShot(loserClip);
            gameOverText.SetActive(true);
        }
    }
}


