using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerLevel1 : MonoBehaviour
{
    public float speed;
    Rigidbody rb;

    public AudioClip coinClip, winnerClip, loserClip;
    public AudioSource source;
    float xInput;
    float yInput;

    int score = 0;
    public int winScore;
    public GameObject winText;
    public GameObject gameOverText; 

    public float delayBeforeLevel2 = 5f; 

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
                winText.SetActive(true);
                source.PlayOneShot(winnerClip);
                StartCoroutine(TransitionToLevel2());
            }
        }
        else if (other.gameObject.tag == "Finish")
        {
            source.PlayOneShot(loserClip);
            gameOverText.SetActive(true);
        }
    }

    IEnumerator TransitionToLevel2()
    {
        yield return new WaitForSeconds(delayBeforeLevel2);
        SceneManager.LoadScene("level2");
    }
}
