using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    public Transform groundCheck;
    [SerializeField]
    public float groundDistance = 0.4f;
    [SerializeField]
    public LayerMask groundSand;
    public LayerMask groundStone;
    public LayerMask groundWood;

    [SerializeField]
    bool debugLogActive;
    bool isSand;
    bool isStone;
    bool isWood;




    // Update is called once per frame
    void Update()
    {
        GGroundCheck();
        
    }

    public void GGroundCheck()
    {
        isSand = Physics.CheckSphere(groundCheck.position, groundDistance, groundSand);
        isStone = Physics.CheckSphere(groundCheck.position, groundDistance, groundStone);
        isWood = Physics.CheckSphere(groundCheck.position, groundDistance, groundWood);

        /*
        if (debugLogActive)
        {
            if (isSand && !isStone && !isWood)
            {
                Debug.Log("Sand");
            }
            if (!isSand && isStone && !isWood)
            {
                Debug.Log("Stone");
            }
            else
            {
                Debug.Log("Wood");
            }
        }
        */
        

        
    }

    public void CheckStone()
    {
        isSand = Physics.CheckSphere(groundCheck.position, groundDistance, groundStone);

        //Debug.Log("Stone");
    }

    public void CheckWood()
    {
        isSand = Physics.CheckSphere(groundCheck.position, groundDistance, groundWood);

        //Debug.Log("Wood");
    }
}
