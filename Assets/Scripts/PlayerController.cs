using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7;


    private Rigidbody2D rb;

    // horizontal & vertical input
    private float h, v;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine(PlayerMovement());
    }

    IEnumerator PlayerMovement()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(h * speed, v * speed);
        yield return new WaitForFixedUpdate();

        StartCoroutine(PlayerMovement());
    }
}
