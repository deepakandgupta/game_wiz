using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RemovePlatform : MonoBehaviour
{
    //// Start is called before the first frame update
    [SerializeField]
    GameObject platformNormal;
    [SerializeField]
    GameObject platformSpring;
    [SerializeField]
    GameObject platform1Time;
    [SerializeField]
    GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float score = PlayerPrefs.GetFloat("lastScore", 0);

        float probFor1Time = score < 5000 ? 3 : 6;

        GameObject colObj = collision.gameObject;
        float randX = Random.Range(-6.85f, -0.75f);
        float yOffset = Random.Range(0f, 4f);

        // -----------------------------------------------

        var platforms = GameObject.FindGameObjectsWithTag(platformNormal.tag);
        var platf1Time = GameObject.FindGameObjectsWithTag(platform1Time.tag);
        var platSpring = GameObject.FindGameObjectsWithTag(platformSpring.tag);

        float YPosHigh = 0f;
        foreach (var platform in platforms) {
            if (platform.transform.position.y > YPosHigh) {
            // Reference Object is the top platform
                YPosHigh = platform.transform.position.y;
            }
        }

        foreach (var platform in platf1Time)
        {
            if (platform.transform.position.y > YPosHigh)
            {
                // Reference Object is the top platform
                YPosHigh = platform.transform.position.y;
            }
        }

        foreach (var platform in platSpring)
        {
            if (platform.transform.position.y > YPosHigh)
            {
                // Reference Object is the top platform
                YPosHigh = platform.transform.position.y;
            }
        }


        // -----------------------------------------------
        Vector2 newPos = new Vector2(randX, YPosHigh + yOffset);
        if (colObj.tag == platformNormal.tag) {
            if (Random.Range(1, 10) == 6)
            {
                Destroy(colObj);
                Instantiate(platformSpring, newPos, Quaternion.identity);
            }
            else if (Random.Range(1, 10) < probFor1Time) {
                Destroy(colObj);
                Instantiate(platform1Time, newPos, Quaternion.identity);
            }
            else {
                colObj.transform.position = newPos;
            }
        }
        else if (colObj.tag == platformSpring.tag)
        {
            if (Random.Range(1, 10) == 6)
            {
                colObj.transform.position = newPos;
            }
            else if (Random.Range(1, 10) < probFor1Time)
            {
                Destroy(colObj);
                Instantiate(platform1Time, newPos, Quaternion.identity);
            }
            else
            {
                Destroy(colObj);
                Instantiate(platformNormal, newPos, Quaternion.identity);
            }
        } else if (colObj.tag == platform1Time.tag) {
            if (Random.Range(1, 10) == 6)
            {
                Destroy(colObj);
                Instantiate(platformSpring, newPos, Quaternion.identity);
            }
            else if (Random.Range(1, 10) < probFor1Time)
            {
                colObj.transform.position = newPos;
            }
            else
            {
                Destroy(colObj);
                Instantiate(platformNormal, newPos, Quaternion.identity);
            }
        }
        else if (colObj.tag == player.tag) {
            SceneManager.LoadScene("GameOver");
            Destroy(colObj);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
