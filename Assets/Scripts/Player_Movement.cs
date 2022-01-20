using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    public float speed;
    Rigidbody PlayerRigidbody;
    private GameObject[] coins;

    public int coinCount;

    public GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        PlayerRigidbody.AddForce(movement * speed * Time.deltaTime);
        WinCondition();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            coinCount ++;
            print("Get coin!");
            Destroy(collision.gameObject);
            scoreText.GetComponent<Text>().text = "Score: " + coinCount;
        }

        if (collision.gameObject.tag == "Hazard")
        {
            print("Got Hurt");
            LoseCondition();
        }
    }

    private void WinCondition()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");

        if(coins.Length <= 0)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
    private void LoseCondition()
    {
        SceneManager.LoadScene("LoseScene");
    }
}
