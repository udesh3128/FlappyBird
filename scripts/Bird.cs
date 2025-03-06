using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public float force;
    public GameObject gameOver;
    IntersitialAds intersitialAds;
    Rigidbody2D rb;
    bool isGameRunning = false;
    public Image image;

    private void Start()
    {
        intersitialAds = GameObject.FindFirstObjectByType<IntersitialAds>();
        Time.timeScale = 0;
        rb = GetComponent<Rigidbody2D>();
        image.gameObject.SetActive(true);

    }

    private void Update()
    {

        if (!isGameRunning)
        {

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
                isGameRunning = true;
                rb.velocity = Vector3.up * force;
                image.gameObject.SetActive(false);
                
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
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
    public void RestartGame()
    {
        gameOver.SetActive(false);
        SceneManager.LoadScene("flappyBird");
        Time.timeScale = 1;
    }
}
