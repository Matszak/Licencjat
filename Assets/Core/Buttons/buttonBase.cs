using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class buttonBase : MonoBehaviour
{

    public UnityEvent pressButton;

    public UnityEvent releaseButton;

    private void OnTriggerEnter2D(Collider2D other)
    {
        pressButton?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        releaseButton?.Invoke();
    }
}
