using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CollisionDetect : MonoBehaviour
{
    public bool permission;

    private void OnTriggerStay(Collider other)
    {



        if (other.gameObject.tag != "SurfaceReserved")
        {
            permission = true;
        }
        else
        {
            permission = false;
            Debug.Log("permission :" + permission);
            return;
        }
          
    }
    
}
