using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    [SerializeField] private float scaleAmount = 0.5f;
    [SerializeField] private Vector3 minScale = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField] private Vector3 maxScale = new Vector3(2f,2f,2f);
    [SerializeField] private KeyCode growKey = KeyCode.E; 
    [SerializeField] private KeyCode minimalizeKey = KeyCode.Q;
    [SerializeField] private KeyCode resetKey = KeyCode.R;

    private Vector3 originalScale;


    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        if (Input.GetKeyDown(growKey))
        {
            Vector3 newScale = transform.localScale + Vector3.one * scaleAmount;
            transform.localScale = Vector3.Min(newScale, maxScale);
        }

        if (Input.GetKeyDown(minimalizeKey))
        {
            Vector3 newScale = transform.localScale - Vector3.one * scaleAmount;
            transform.localScale = Vector3.Max(newScale, minScale);
        }

        if (Input.GetKeyDown(resetKey))
        {
            transform.localScale = Vector3.Max(Vector3.Min(originalScale, maxScale), minScale);
        }
    }
}
