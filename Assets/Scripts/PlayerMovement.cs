using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //varje frame som man håller inne space så flyger man uppåt med konstant hastighet och sedan släpps man efter det.
    //kan hoppa högt om man håller inne space
    //kan dubbelhoppa
    //finns en powerup som gör att man för ett högre hopp och en större sprite på spelaren.

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
    bool runsTheJump;
    float runsTheEdge;
    float longJump;
    float jumpMaxHeight;
    bool lockoutLongJump;
    bool justDJumped;
    float eJumpSpeed;
    public float empowered;
    Vector2 eScale;
    Vector2 oriScale;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        jumpSpeed = 8.6f;
        edgeJumpSpeed = 4f;
        jumpMaxHeight = 18f;
        timer = 0f;
        enableTimer = 0f;
        runsTheJump = false;
        runsTheEdge = 0f;
        longJump = 0f;
        saveWorldY = transform.position.y;
        lockoutLongJump = false;
        eJumpSpeed = jumpSpeed * 1.5f;
        justDJumped = false;
        empowered = 0f;
        eScale = transform.localScale * 1.5f;
        oriScale = transform.localScale;
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
        if (empowered >= 39)
        {
            jumpSpeed = eJumpSpeed * (2 / 3);
            empowered = 0;
            transform.localScale = oriScale;
        }
    }
    void Update()
    {
        IsEmpowered();
        //FAQ    ->     man kan bara göra ett hopp i luften och om man håller in knappen så hoppar man högre

        //man kan bara hoppa I luften om man faller nedåt, alltså om ens velocity.y < 0
        if (rbody.velocity.y < 0f)
        {
            //man kan bara hoppa i luften om variabeln "justDJumped" är false, eftersom den blir true när man har hoppat i luften
            if (groundCheck.isGrounded != true && justDJumped == false)
            {
                if (Input.GetButtonDown("Jump") || Input.GetButton("Jump"))
                {
                    //man kan inte dubbelhoppa om "justDJumped" == true
                    justDJumped = true;

                    runsTheJump = true;
                    enableTimer = 1f;
                    timer = 0f;
                    longJump = 1f;
                }
            }
        }
        if (Input.GetButtonDown("Jump") || Input.GetButton("Jump"))
        {
            if (groundCheck.isGrounded == true)
            {
                //sparar spelarens höjd när man hoppar för att jag ska kunna veta om man släpper space tidigt eller håller inne den etc.
                saveWorldY = transform.position.y;
                //kan inte hoppa om runsTheJump inte är på 1...
                runsTheJump = true;
                //timer which tells your character how high to jump will start if enableTimer is at 1
                enableTimer = 1f;
                //runsTheEdge gör ett litet hopp och kan bara göras om man hänger på en kant.
                //man kan inte trigga groundcheck och edgecheck samtidigt så man kan inte edgehoppa om groundcheck är true
                runsTheEdge = 0f;
                //longjump är effektivt en bool som säger till datorn om man vill hoppa högt eller inte.
                longJump = 1f;
            }
            if (edge.edgeHeld == true)
            {
                saveWorldY = transform.position.y;
                //man kan inte göra ett vanligt hopp om runsTheJump inte är true... Man kan hoppa ett edgejump om runsTheEdge är 1
                runsTheJump = false;
                runsTheEdge = 1f;
                //samma variabel för edgejump och normalt hopp, bara olika hastiget som man kan se i FixedUpdate där edgehoppet tar plats.
                enableTimer = 1f;
            }
        }
        if (Input.GetButton("Jump") && lockoutLongJump != true)
        {
            //longJumpLockout kommer vara true om man har släppt space  och då kan man inte hoppa högt längre.
            longJump = 1f;
        }
        else if (!Input.GetButton("Jump") && transform.position.y <= saveWorldY + 2.875f)
        {
            //om man släpper space medans man är under en viss höjd på y axeln så kommer man inte kunna hoppa högt
            longJump = 0f;
            lockoutLongJump = true;
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
            runsTheJump = false;
            runsTheEdge = 0f;
            lockoutLongJump = false;
            justDJumped = false;
            jumpMaxHeight = 18f;
        }
        //what occurs in the first frame in which youre no longer holding onto a ledge
        if (edge.edgeHeld != oldEHbool && edge.edgeHeld == false)
        {
        }
        //what occurs in the first frame in which youre holding onto a ledge
        if (edge.edgeHeld != oldEHbool && edge.edgeHeld == true)
        {
            runsTheJump = false;
            enableTimer = 0f;
            runsTheEdge = 0f;
            timer = 0f;
            //timer kan inte gå högre änjumpMaxHeight.
            jumpMaxHeight = 18f;
        }
        oldGCbool = groundCheck.isGrounded;
        oldEHbool = edge.edgeHeld;
        //*
    }
    void FixedUpdate()
    {
        //betyder att x axeln i den nya Vector2'n är beroende av om man klickar på A eller D.
        //det betyder att x är lika med något från -1 till och med 1 vilket multipliceras med min variabel moveSpeed för att göra en "smooth" rörelse som ökar sakta ifrån 0 till -1 eller 1.
        //sedan sätts y axelns velocity som den redan är.
        rbody.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rbody.velocity.y);
        if (enableTimer == 1f)
        {
            //om man har klickar på space blir enableTimer == 1 och då kommer timer att börja räknas uppåt.
            //varje frame som timer räknar kommer man att flyga uppåt med en set velocity tills timer är för hög, då man börjar negativt accelerera 
            timer = timer + 1f;
        }
        else if (enableTimer == 0f)
        {
            //enableTimer är vad som i grunden gör så att man kan hoppa eller ej eftersom timer inte startar om enableTimer inte har aktiverats genom att klicka på hoppa knappen.
            timer = 0f;
        }
        if (longJump == 1f && 6f <= timer && jumpMaxHeight >= timer && runsTheJump == true)
        {
            //om man inte har släppt space för tidigt så kommer man kunna hoppa högt.
            //jumpMaxHeight ska vara större än timer för att kunna hoppa, alltså man hoppar tills timer når värdet som gör att man inte kan hoppa längre.
            rbody.velocity = new Vector2(rbody.velocity.x, jumpSpeed);
            //man flyger uppåt med konstant hastighet tills man slutar...
        }
        else if (timer >= 1f && 7f >= timer && runsTheJump == true)
        {
            //det lägsta hoppet man kan göra. det är gjort så att man inte kan hoppa i en frame om man är super snabb, utan man hoppar alltid minst i 5 frames
            //för att spelet ska vara lite mer pålitligt.
            rbody.velocity = new Vector2(rbody.velocity.x, jumpSpeed);
        }
        else if (timer >= 1f && 6f >= timer && runsTheEdge == 1f)
        {
            //detta är hoppet man gör om man hänger sin sprite på en kant (man kan det för jag lade till en box collider)
            //det är svagare för det är mer som en failsafe än ett riktigt hopp.
            rbody.velocity = new Vector2(rbody.velocity.x, edgeJumpSpeed);
        }
    }
}
