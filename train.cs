using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class train : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public Rigidbody2D choo;
    public GameObject explosion;
    public GameObject currTile;
    public GameObject nextTile;
    public changeTile tile;
    public bool isAlongX = true;
    public bool isPosX = true;
    public bool isPosY = true;

    // Start is called before the first frame update

    void Start()
    {
        // gameOver.gameObject.SetActive(false);

        choo = this.GetComponent<Rigidbody2D>();
        currTile = tile.horiRail;

    }

    // Update is called once per frame
    void Update()
    {
        MoveTrainPosX();
        nextTile = tile.randRail;

        //Directional Conditions
        if (currTile == tile.drRail)
        {
            if (isAlongX == true & isPosX == false)
            {
                MoveTrainNegY();
                isAlongX = false;
                isPosY = false;
            }
            else if (isAlongX == false & isPosY == true)
            {
                MoveTrainPosX();
                isAlongX = true;
                isPosX = true;
            }
        }
        else if (currTile == tile.dlRail)
        {
            if (isAlongX == true & isPosX == true)
            {
                MoveTrainNegY();
                isAlongX = false;
                isPosY = false;
            }
            else if (isAlongX == false & isPosY == true)
            {
                MoveTrainNegX();
                isAlongX = true;
                isPosX = false;
            }
        }
        else if (currTile == tile.urRail)
        {
            if (isAlongX == true & isPosX == false)
            {
                MoveTrainNegY();
                isAlongX = false;
                isPosY = true;
            }
            else if (isAlongX == false & isPosY == false)
            {
                MoveTrainPosX();
                isAlongX = true;
                isPosX = true;
            }
        }
        else if (currTile == tile.ulRail)
        {
            if (isAlongX == true & isPosX == true)
            {
                MoveTrainPosY();
                isAlongX = false;
                isPosY = true;
            }
            else if (isAlongX == false & isPosY == false)
            {
                MoveTrainNegX();
                isAlongX = true;
                isPosX = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "gravel_tile" || other.gameObject.name == "boulder")
        {
            //Debug.Log("hit detected");
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            this.gameObject.SetActive(false);
        }
        else
        {
            //Update current tile and next tile on collision
            currTile = nextTile;
            nextTile = tile.randRail;
        }


        //Debug Log
        if (currTile == tile.vertRail)
        {
            Debug.Log("vertRail");
        }
        else if (currTile == tile.horiRail)
        {
            Debug.Log("horiRail");
        }
        else if (currTile == tile.urRail)
        {
            Debug.Log("urRail");
        }
        else if (currTile == tile.ulRail)
        {
            Debug.Log("ulRail");
        }
        else if (currTile == tile.drRail)
        {
            Debug.Log("drRail");
        }
        else if (currTile == tile.dlRail)
        {
            Debug.Log("dlRail");
        }
    }


    //Velocity
    public void MoveTrainPosX()
    {
        choo.velocity = new Vector2(moveSpeed, 0);
    }
    public void MoveTrainNegX()
    {
        choo.velocity = new Vector2(-moveSpeed, 0);
    }
    public void MoveTrainPosY()
    {
        choo.velocity = new Vector2(0, moveSpeed);
    }
    public void MoveTrainNegY()
    {
        choo.velocity = new Vector2(0, -moveSpeed);
    }
}
