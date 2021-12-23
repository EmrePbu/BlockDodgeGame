using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // speed of the player 20f
    public float speed = 20f;
    // map width
    public float mapWidth = 2.5f;
    // last touch position x
    private float lastTouchPositionX;
    // x speed value 100
    private float xSpeed = 100f;
    // limit x value 4
    private float limitX = 4f;

    private void FixedUpdate()
    {
        // // // get horizontal input multiply by time.deltatime by speed
        // // float h = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        // // // vector2 of the player
        // // Vector2 newPosition = rb.position + Vector2.right * h;
        // // // clamp the position of the player between -mapWidth and mapWidth
        // // newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
        // // // set the position of the player to the new position
        // // rb.MovePosition(newPosition);

        float newX = 0;
        float touchXDelta = 0;

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                lastTouchPositionX = Input.GetTouch(0).position.x;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                touchXDelta = 3 * (Input.GetTouch(0).position.x - lastTouchPositionX) / Screen.width;
                lastTouchPositionX = Input.GetTouch(0).position.x;
            }

        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);

        Vector2 newPostion = new Vector2(newX, transform.position.y * Time.deltaTime);
        // clamp the position of the player between -mapWidth and mapWidth
        newPostion.x = Mathf.Clamp(newPostion.x, -mapWidth, mapWidth);
        transform.position = newPostion;



    }

    // on collision enter 2d with debug log collision game object name
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if collision game object tag is Block
        if (collision.gameObject.tag == "Block")
        {
            // find onject of type GameManager and call endGame
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
