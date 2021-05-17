using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTile : MonoBehaviour
{
    public GameObject vertRail;
    public GameObject horiRail;
    public GameObject drRail;
    public GameObject dlRail;
    public GameObject urRail;
    public GameObject ulRail;
    public GameObject randRail;
    public GameObject[] rails;


    // Start is called before the first frame update
    void Start()
    {
        rails = new GameObject[6];
        rails[0] = vertRail;
        rails[1] = horiRail;
        rails[2] = drRail;
        rails[3] = dlRail;
        rails[4] = urRail;
        rails[5] = ulRail;
    }

    public void OnMouseDown()
    {
        System.Random random = new System.Random();
        int i = random.Next(6);
        randRail = rails[i];
        if (randRail != null)
        {
            GameObject rail = Instantiate(randRail);
            rail.transform.position = transform.position;
        }
        Destroy(gameObject);
    }
}
