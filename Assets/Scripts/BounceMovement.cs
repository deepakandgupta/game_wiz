using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceMovement : MonoBehaviour
{
    [SerializeField]
    private float bounceForce = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D colObj = collision.gameObject.GetComponent<Rigidbody2D>();
        if (colObj != null && colObj.tag == "Player" && collision.relativeVelocity.y <= 0) {
            colObj.velocity = new Vector2(colObj.velocity.x, bounceForce);
        }
    }
}
