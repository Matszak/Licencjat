using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneButtonOpenDoors : MonoBehaviour
{

    private bool _doorsOpen;
    public void OpenDoors()
    { 
        transform.position += new Vector3(0, 10, 0);
    }

    public void CloseDoors()
    {
        transform.position -= new Vector3(0, 10, 0); 
    }
}
