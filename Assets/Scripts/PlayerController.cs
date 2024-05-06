using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody rb;

    public AudioClip coinClip, winnerClip, LoserClip;
    public AudioSource source;
    float xInput;
    float yInput;


    int score = 0;

    public int winScore;
    public GameObject winText;
    private void Awake()
    {
        // source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -60f)
        {
            SceneManager.LoadScene("SampleScene");

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
                // Game Win
                winText.SetActive(true);
                source.PlayOneShot(winnerClip);

            }
        }
        else if (other.gameObject.tag == "Finish")
        {
            source.PlayOneShot(LoserClip);

        }
    }
}
