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

    private bool isPressed = false;

    private int pressCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        pressCount++;
        if (pressCount == 1)
        {
            pressButton?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        pressCount = Mathf.Max(pressCount - 1, 0);
        if (pressCount == 0)
        {
            releaseButton?.Invoke();
        }
    }
}
