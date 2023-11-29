using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    float xInput;
    float yInput;

    Rigidbody playerRigidbody;

    int coinsCollected;

    public GameObject winText;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if(transform.position.y <= -5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    private void FixedUpdate()
    {
        playerRigidbody.AddForce(xInput * moveSpeed, 0, yInput * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            coinsCollected++;
            other.gameObject.SetActive(false);
        }

        if(coinsCollected >= 6)
        {
            winText.SetActive(true);
        }
    }
}
