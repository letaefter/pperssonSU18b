using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 12f;
    public float jumpSpeed = 30f;
    public float edgeJumpSpeed = 5f;
    float saveWorldY;
    bool oldGCbool; //GC = groundCheck
    bool oldEHbool; //EH = edgeHeld
    public GroundChecker groundCheck;
    public EdgeHold edge;
    private Rigidbody2D rbody;
    float timer;
    float enableTimer;
    float runsTheJump;
    float runsTheEdge;
    float longJump;
    float jumpMaxHeight;
    float lockoutLongJump;
    float jumpAgain;
    float letGoOfSpace;
    float justDJumped;
    float eJumpSpeed;
    float empowered;
    Vector3 eScale;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        jumpSpeed = 8.6f;
        edgeJumpSpeed = 4f;
        jumpMaxHeight = 18f;
        timer = 0f;
        enableTimer = 0f;
        runsTheJump = 0f;
        runsTheEdge = 0f;
        longJump = 0f;
        saveWorldY = transform.position.y;
        lockoutLongJump = 0f;
        jumpAgain = 0f;
        eJumpSpeed = jumpSpeed * 1.5f;
        empowered = 0f;
        eScale = transform.localScale;
    }
    void IsEmpowered()
    {
        if (empowered >= 1)
        {
            empowered = empowered + Time.deltaTime;
        }
        if (empowered >= 1 && 40 > empowered)
        {
            jumpSpeed = eJumpSpeed;
            transform.localScale = eScale;
        }
        else if (empowered >= 30)
        {
            jumpSpeed = jumpSpeed * (2 / 3);
            empowered = 0;
        }
    }
    void Update()
    {
        IsEmpowered();
        if (rbody.velocity.y < 0f)
        {
            if (groundCheck.isGrounded == false && justDJumped == 0f)
            {
                if (Input.GetButtonDown("Jump") || Input.GetButton("Jump"))
                {
                    justDJumped = 1f;
                    jumpAgain = 1f;
                    runsTheJump = 1f;
                    enableTimer = 1f;
                    timer = 0f;
                    longJump = 1f;
                }
            }
        }
        if (Input.GetButton("Jump") == false)
        {
            letGoOfSpace = 1f;
        }
        if (Input.GetButtonDown("Jump") || Input.GetButton("Jump"))
        {
            if (groundCheck.isGrounded == true)
            {
                saveWorldY = transform.position.y;
                //kan inte hoppa om runsTheJump inte är på 1...
                runsTheJump = 1f;
                //timer which tells your character how high to jump -will start if enableTimer is at 1
                enableTimer = 1f;
                runsTheEdge = 0f;
                longJump = 1f;
            }
            if (edge.edgeHeld == true)
            {
                saveWorldY = transform.position.y;
                runsTheJump = 0f;
                runsTheEdge = 1f;
                enableTimer = 1f;
            }
        }
        if (Input.GetButton("Jump") && lockoutLongJump != 1f)
        {
            longJump = 1f;
        }
        else if (Input.GetButton("Jump") == false && transform.position.y <= saveWorldY + 2.875f)
        {
            longJump = 0f;
            lockoutLongJump = 1f;
        }
        //*
        //what occurs in the first frame in which your feet no longer touch the ground
        if (groundCheck.isGrounded != oldGCbool && groundCheck.isGrounded == false)
        {
        }
        //what occurs in the first frame in which your feet touch ground
        if (groundCheck.isGrounded != oldGCbool && groundCheck.isGrounded == true)
        {
            saveWorldY = transform.position.y;
            enableTimer = 0f;
            timer = 0f;
            runsTheJump = 0f;
            runsTheEdge = 0f;
            lockoutLongJump = 0f;
            jumpMaxHeight = 18f;
            jumpAgain = 0f;
            justDJumped = 0f;
        }
        //what occurs in the first frame in which youre no longer holding onto a ledge
        if (edge.edgeHeld != oldEHbool && edge.edgeHeld == false)
        {
        }
        //what occurs in the first frame in which youre holding onto a ledge
        if (edge.edgeHeld != oldEHbool && edge.edgeHeld == true)
        {
            runsTheJump = 0f;
            enableTimer = 0f;
            runsTheEdge = 0f;
            timer = 0f;
            jumpMaxHeight = 18f;
            justDJumped = 0f;
        }
        oldGCbool = groundCheck.isGrounded;
        oldEHbool = edge.edgeHeld;
        //*
        //BUG OM MAN HÅLLER INNE SPACE OCH SEDAN TRIGGAR BÅDE GROUNDCHECK OCH EDGECHECK SÅ HOPPAS MAN MED jumpSpeed I EN FRAME VARJE GÅNG MAN NUDDAR MARKEN
    }
    void FixedUpdate()
    {
        rbody.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rbody.velocity.y);
        //du använder:
        //enableTimer
        //timer
        //jumpSpeed
        //canJump                        //ta inte bort den igen
        //groundCheck.isGrounded
        //oldGCbool
        //
        if (enableTimer == 1f)
        {
            timer = timer + 1f;
        }
        else if (enableTimer == 0f)
        {
            timer = 0f;
        }
        if (longJump == 1f && timer >= 6f && jumpMaxHeight >= timer && runsTheJump == 1f)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, jumpSpeed);
            if (letGoOfSpace == 1f)
            {
                jumpAgain = 0f;
            }
        }
        else if (timer >= 1f && 7f >= timer && runsTheJump == 1f)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, jumpSpeed);
        }
        else if (timer >= 1f && 6f >= timer && runsTheEdge == 1f)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, edgeJumpSpeed);
        }
    }
}
