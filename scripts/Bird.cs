using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public Vector3 pos;
    public float speed;
    public float force;
    public GameObject gameOver;
    IntersitialAds intersitialAds;
    Rigidbody2D rb;
    bool isGameRunning = false;

    private void Start()
    {
        intersitialAds = GameObject.FindFirstObjectByType<IntersitialAds>();
        Time.timeScale = 0;
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {

        if (!isGameRunning)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                isGameRunning = true;
                rb.velocity = Vector3.up * force;
            }
            return;
        }

        pos = transform.position;

        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * force;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);


    }

    public void restart()
    {
        if (intersitialAds != null)
        {
            intersitialAds.ShowInterstitialAd();

        }
        else
        {
            RestartGame();
        }

    }
    private void RestartGame()
    {
        gameOver.SetActive(false);
        SceneManager.LoadScene("flappyBird");
        Time.timeScale = 1;
    }
}
