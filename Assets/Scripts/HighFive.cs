using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighFive : MonoBehaviour
{
    private BoxCollider[] playerPalm;

    void Awake()
    {
        playerPalm = gameObject.GetComponentsInChildren<BoxCollider>();

        //playerPalm = arrangeColliders(playerPalm, "LeftHand", "RightHand");

        gameObject.GetComponent<PlayerMovement>().SetColliders(playerPalm);
    }

   private BoxCollider tempCollider;
    //commented on 3/11/2019
    //private BoxCollider[] arrangeColliders(BoxCollider[] Colliders, string firstName, string secondName)
    //{
    //    if (Colliders[0].name == firstName)
    //        return Colliders;

    //    if (Colliders[0].name == secondName)
    //    {
    //        tempCollider = Colliders[0];
    //        Colliders[0] = Colliders[1];
    //        Colliders[1] = tempCollider;            
    //    }
    //    return Colliders;
    //}
}
