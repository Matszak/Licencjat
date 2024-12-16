using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleChanger : MonoBehaviour
{

    [Header("Scale Controller")]
    
    [SerializeField] private PlayerMovement player1Movement;
    [SerializeField] private PlayerMovement player2Movement;
    
    [SerializeField] private Transform player1Transform;
    [SerializeField] private Transform player2Transform;

    [SerializeField] private float scaleAmount = 1f;
    [SerializeField] private Vector3 minScale = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField] private Vector3 maxScale = new Vector3(2f,2f,2f);
    [SerializeField] private KeyCode scaleUp = KeyCode.E; 
    [SerializeField] private KeyCode scaleDown = KeyCode.Q;
    [SerializeField] private KeyCode resetKey = KeyCode.R;

    private Vector3 originalScale;

    
    [Header("Mass Scale Controller")]
    
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private float baseMass;

    [Header("Player Movement Controller")] 
    
    [SerializeField] private PlayerMovement playerMovement;


    private void Start()
    {
        _characterTransform = transform;
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
            player1Transform.DOScale(maxScale, scaleAmount);
            baseMass = 200f;
            player1Movement.maxSpeed = 5f;        
        }

        if (Input.GetKeyDown(scaleDown))
        {
            player2Transform.DOScale(minScale, scaleAmount);
            baseMass = 50f;
            player2Movement.maxSpeed = 15f;
            
        }

        if (Input.GetKeyDown(resetKey))
        {
            player1Transform.DOScale(originalScale, scaleAmount);
            player2Transform.DOScale(originalScale, scaleAmount);

            player1Movement.maxSpeed = 10f;        
            player2Movement.maxSpeed = 10f;        
        }
    }
}
