using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void LateUpdate()
    {
        if (target!=null && target.position.y > this.transform.position.y) {
            Vector3 myPos = this.transform.position;
            Vector3 newPos = new Vector3(myPos.x, target.position.y,myPos.z);
            this.transform.position = newPos;
        }
    }
}
