using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProJumpByPutoAmo : MonoBehaviour {

    public float fallMultiplier = 2.5f;
    public float lowMultiplier = 2f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        if (rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowMultiplier - 1) * Time.deltaTime;
    }
}
