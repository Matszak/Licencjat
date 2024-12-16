using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class oneButtonOpenDoors : MonoBehaviour
{
   

    private bool _doorsOpen;
    private float _startPositionY;

    private void Start()
    {
        _startPositionY = transform.position.y;
    }

    public void OpenDoors()
    {
        transform.DOMoveY(_startPositionY + 2f, 1);
    }

    public void CloseDoors()
    {
        transform.DOMoveY(_startPositionY, 1);
        
    }
}
