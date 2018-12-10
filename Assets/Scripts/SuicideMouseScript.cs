using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideMouseScript : MonoBehaviour
{
    public float baseSpeedDoNotEdit = 2f;
    public float uniqueSpeed = 2f;
    public bool left = true;
    float kinny;
    float onsh;
    bool nubool;

    //
    //

    public GroundChecker check;

    private Rigidbody2D rbody;
    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        left = true;
        onsh = 0f;
        kinny = 0f;
    }
    private void FixedUpdate()
    {
        if (left == true)
        {
            if (onsh == 1f)
            {
                //här ändrar jag SuicideMouse från att gå i x axeln, till att gå i y axeln. det händer ifall groundcheck scriptets bool: isGrounded har markerat att denn är false i en frame. ( förklarar längre ner)
                //rbody, syftar på RigidBody2D komponenten i detta gameObjectet.
                //MovePosition flyttar på detta objectet varje frame. jag tar Vector2D'n som är rbody's position, och adderar till den, en ny vektor2 som då innehåller min uniqueSpeed variabel
                //sedan multiplicerar jag den andra termens Vector2 med Time.deltaTime för att den ska röra sig smidigt (dock så behöver jag inte det, för den körs ju i FixedUpdate som alltid ska ha samma framerate).
                //fast jag gör det ändå.
                rbody.MovePosition(rbody.position + (-(new Vector2(0f, uniqueSpeed) * Time.deltaTime)));
                if (kinny == 1f)
                {
                    //den här linjen: "check.poly.enabled = false;" gör följande.
                    //"check" länkar till scriptet GroundChecker.
                    //"poly" länkar sedan till en komponent inuti GroundCheck scriptet, som representerar Collidern som är själva GroundChecker.isGrounded boolen som säger om man nuddar marken eller ej
                    //"enabled" länkar till dess status som på eller av i unity
                    // sedan säger jag att den ska vara = false; och då stängs själva objectet av, därmed har objectet inget sätt att ändra riktning på längre, eftersom boolen som baseras på "poly"
                    //i GroundChecker inte längre har en Collider trigger att basera sin status på, då ändras den inte längre, och då kan min SuicideMouse inte längre ändra sin riktning.
                    check.poly.enabled = false;
                    //detta gameObject'ets egna transform, sedan går jag in i dess rotate, vilken kontrollerar hur den är roterad
                    //sedan sätter jag rotationen till en ny vektor, som sagt kommer detta bara att ske i en frame eftersom check.isGrounded som jag sagt, bara har en chans att bli triggad, och sedan slutar existera
                    //denna vektoren roterar då SuicideMouse i 90 grader i Z-axeln, så den pekar nosen nedåt.
                    transform.Rotate(new Vector3(0, 0, 90));
                    //här ändrar jag gameObjectets position, i dess egna transform.
                    //eftersom marken är satt i en tilemap vars x längd och y längd är 1 per ruta, så tar jag musens position i x-axeln, och sedan med Mathf.CeilToInt gör den till närmsta större heltal (Integer)
                    //detgör jag för musen ska se ut som han går ner för väggen, om jag inte tog Mathf.CeilToInt, så skulle musens position vara opålitlig och därmed skulle den inte se bra ut/gå i luften.
                    //jag sätter dess Z position som den redan är eftersom z inte direkt borde ändras någongång. sedan sätter jag att den ska börja på sin Y position minus 0.5f. detta gör jag för att det ska se
                    //smooth ut när den går över kanten, och det tycker jag att det gör.
                    transform.position = new Vector3(Mathf.CeilToInt(transform.position.x) - 0.5f, transform.position.y-0.5f, transform.position.z);
                    //variabeln "kinny"'s värde startar som 0, och blir 1 om groundcheck blir förändrad.
                    //om den är på 1 så startas detta här if-kommandot och därmed händer allt som kommer hända detta gameObjectet, därefter self terminatar den sig själv genom att sätta "kinny" på 0 igen.
                    //det finns inte något sätt för denn
                    kinny = 0f;
                }
            }
            else
            {
                //om grouncheck variabeln inte har markerat att SuicideMouse ska gå negativt i Y-axeln så kommer den gå negativt i X-axeln. den gör det av default och kommer alltid göra det om
                //check.isGrounded alltid är samma värde som den är i början.
                rbody.MovePosition(rbody.position + (-(new Vector2(uniqueSpeed, 0) * Time.deltaTime)));
            }
        }
        //om check.isGrounded != det värde den hade i förra framen, så kommer dessa två variabler att sättas till 1.
        //när de sätts till 1 så är planen att jag ska ha satt ut ett game object i unity som kommer sedan orsaka att detta objectet kommer Destroy'a sig självt.
        //dessutom så kommer "kinny" variabeln att disable'a Collidern som boolen i GroundCheck scriptet baseras på, och därmed kommer ingen mer funktion i detta scriptet
        //förändra något igen.
        if (check.isGrounded == false && nubool != check.isGrounded)
        {
            onsh = 1f;
            kinny = 1f;
        }
        //att nubool = isGrounded gör jag för att jag ska kunna få musen att göra en sak i EN frame ifall Groundcheck boolen markerar att den inte nuddar marken längre
        //eftersom det här körs efter det if kommandot där något ska hända om "nubool != check.isGrounded" alltså mellan början på Update och slutet, så ska musen 
        //rotera och ändra riktning, ifall check.isGrounded har förändrats.
        nubool = check.isGrounded;
    }
    void Update()
    {
        //casta om en Vector3 till en vektor2
        //"casting"
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //om PolygonCollidern, som är en trigger, som är på SuicideMouse Prefaben, nuddar någonting så kommer den kolla vilken tag gameObjectet som nuddade den har, om tagen
        //på det gameObjectet är "InvisibleWall" så kommer musen att förstöra sig själv i sitt egna script, som ett selfdestruct message, detta betyder dock att scriptet också kommer
        //försvinna. det är okej för SuicideMouse's uppdrag är att gå från sin spawn in i ett object med tag-en "InvisibleWall" och därefter inte har ett annat uppdrag.
        if (collision.tag == "InvisibleWall" || collision.tag == "Weapon")
        {
            Destroy(gameObject);
        }
    }
}
