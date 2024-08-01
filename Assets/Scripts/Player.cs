using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    private float initialSpeed;
    private float xInput, yInput; 
    
    private Vector2 movement;
    private Rigidbody2D rig;

    private bool _isRunning;
    private bool _isRolling;
    private Vector2 _direction;

    public bool isRolling {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool isRunning {
        get { return _isRunning; }
        set { _isRunning = value; }
    }
    
    public Vector2 direction {
        get { return _direction; }
        set { _direction = value; }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    void Update() {
        OnInput();
        OnRun();  
        OnRolling();      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OnMove();
    }    

    #region Movement

    private void OnInput() {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        _direction = new Vector2(xInput, yInput);
    }

    private void OnRun() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            isRunning = !isRunning;
            speed = runSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            isRunning = !isRunning;
            speed = initialSpeed;
        }
    }

    private void OnMove() {
        movement = rig.position + speed * Time.fixedDeltaTime * _direction; 

        rig.MovePosition(movement);
    }

    private void OnRolling() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            _isRolling = true;
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            _isRolling = false;
        }
    }

    #endregion
}
