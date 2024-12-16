using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class oneButtonOpenDoors : MonoBehaviour
{
    public Transform objectTransform;

    private bool _doorsOpen;
    public void OpenDoors()
    {
        objectTransform.DOMoveY(2f, 3);
    }

    public void CloseDoors()
    {
        objectTransform.DOMoveY(-2, 3);
    }
}
