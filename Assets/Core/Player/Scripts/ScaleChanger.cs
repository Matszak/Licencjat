using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleChanger : MonoBehaviour
{

    [Header("Scale Controller")]
    
    [SerializeField] private float scaleAmount = 1f;
    [SerializeField] private Vector3 minScale = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField] private Vector3 maxScale = new Vector3(2f,2f,2f);
    [SerializeField] private KeyCode scaleUp = KeyCode.E; 
    [SerializeField] private KeyCode scaleDown = KeyCode.Q;
    [SerializeField] private KeyCode resetKey = KeyCode.R;

    private Vector3 originalScale;

    
    [Header("Mass Scale Controller")]
    
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private NewBehaviourScript
    [SerializeField] private float baseMass = 10f;


    public Transform characterTransform;


    private void Start()
    {
        originalScale = transform.localScale;
        _rb = GetComponent<Rigidbody2D>();

        if (_rb != null)
        {
            baseMass = _rb.mass;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(scaleUp))
        {
            characterTransform.DOScale(maxScale, scaleAmount);
            baseMass = 200f;
        }

        if (Input.GetKeyDown(scaleDown))
        {
            characterTransform.DOScale(minScale, scaleAmount);
            baseMass = 50f;
        }

        if (Input.GetKeyDown(resetKey))
        {
            characterTransform.DOScale(originalScale, scaleAmount);
        }
    }
}
