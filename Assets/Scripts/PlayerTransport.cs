using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransport : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D colObj = collision.gameObject.GetComponent<Rigidbody2D>();
        if (colObj != null && colObj.tag == "Player")
        {
            if (this.tag == "LeftBoundary")
            {
                Vector2 newPostion = new Vector2(-0.4f, colObj.position.y);
                colObj.position = newPostion;
            } else if (this.tag == "RightBoundary") {
                Vector2 newPostion = new Vector2(-7.2f, colObj.position.y);
                colObj.position = newPostion;
            }
        }
    }
}
