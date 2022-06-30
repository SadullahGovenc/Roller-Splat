using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public Rigidbody Rb;
    public GameManager gm;
    private Vector2 firstPos;
    private Vector2 secondPos;
    private Vector2 currentPos;
    public float currentGroundNumber;
    private Color ballColor;

    public float speed =20;
    void Start()
    {

        ballColor = Random.ColorHSV();
        gameObject.GetComponent<MeshRenderer>().material.color = ballColor;
    }


    void Update()
    {
        Swipe();

       if( currentGroundNumber / gm.groundsCount ==1){
            gm.NextLevel();
        }
    }

    private void Swipe()
    {
        if (Input.GetMouseButtonDown(0)) // sol click e basinca 
        {
            firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0)) // sol click çekilince
        {
            secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            currentPos = new Vector2(
                secondPos.x - firstPos.x,
                secondPos.y - firstPos.y
                );
        }
        currentPos.Normalize();

        if (currentPos.y < 0 && currentPos.x > -.5f && currentPos.x < .5f) // asagi
        {
            Rb.velocity = Vector3.back * speed;
        }
        else if (currentPos.y > 0 && currentPos.x > -.5f && currentPos.x < .5f) // yukari
        {
            Rb.velocity = Vector3.forward * speed;
        }
        else if (currentPos.x < 0 && currentPos.y > -.5f && currentPos.y < .5f) // sola
        {
            Rb.velocity = Vector3.left * speed;
        }
        else if (currentPos.x > 0 && currentPos.y > -.5f && currentPos.y < .5f) // saga
        {
            Rb.velocity = Vector3.right * speed;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<MeshRenderer>().material.color != ballColor)
        {
            if (other.collider.gameObject.CompareTag("Ground"))
            {
                other.gameObject.GetComponent<MeshRenderer>().material.color = ballColor;
                currentGroundNumber++;

               
            }
            //if (currentGroundNumber == gm.groundsCount)
            //{
            //    speed = 0;
            //}
        }
        
    }
}
