using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public TMP_Text timeTxt;
    public float timeForGame;

    public GameObject timeTxtObject;
    public GameObject LostMenu;
    public GameObject WinMenu;

    public float speed;
    public bool SlowDown;
    public bool Dead;

    public GameObject bullet;
    public GameObject fireHole;

    public Touch touch;

    public int EnemyCount;
    public TMP_Text EnemyTXT;
    public GameObject[] Enemies;
    public bool Won;

    Rigidbody RB;
    public bool moveLeft;
    public bool moveRight;
    public float horizontalMoving;

    void Start()
    {
        RB = GetComponent<Rigidbody>();

        Time.timeScale = 1f;
        Won = false;
        Dead = false;

        WinMenu.SetActive(false);
        LostMenu.SetActive(false);

        SlowDown = false;

        InvokeRepeating("FireBullet", 1, 0.3f);
    }

    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        EnemyCount = Enemies.Length;
        EnemyTXT.text = "Enemies: " + EnemyCount.ToString();

        timeForGame -= 1 * Time.deltaTime;
        timeTxt.text = "TIME: " + timeForGame.ToString("f0");

        transform.position += new Vector3(horizontalMoving * Time.deltaTime, 0, speed * Time.deltaTime);

        if (timeForGame <= 0)
        {
            timeForGame -= 0;
            Dead = true;
        }

        if (SlowDown == true)
        {
            speed = 1f;
        }
        if (SlowDown == false)
        {
            speed += 3f * Time.deltaTime;
            if (speed > 3.65f)
            {
                speed = 3.65f;
            }
        }

        if(Won == true)
        {
            timeForGame -= 0f;
            Time.timeScale = 0f;
            WinMenu.SetActive(true);
        }
        if(Dead == true)
        {
            timeForGame -= 0f;
            Time.timeScale = 0f;
            LostMenu.SetActive(true);
        }
        if(EnemyCount == 0)
        {
            Won = true;
        }

        MouseInputFunction();
        ButtonMovementForPlayer();
    }

    void FixedUpdate()
    {
        
    }
    void FireBullet()
    {
        if (Dead == false || Won == false)
        {
            Instantiate(bullet, fireHole.transform.position, fireHole.transform.rotation);
        }
    }

    void MouseInputFunction()
    {
        
    }

    public void OnTriggerEnter(Collider triggerPlayer)
    {
        if (triggerPlayer.gameObject.tag == "Portal")
        {
            Won = true;
            Debug.Log("You have won the Game");
        }
    }
    public void OnCollisionEnter(Collision colliderPlayer)
    {
        if(colliderPlayer.gameObject.tag == "Enemy")
        {
            Dead = true;
            Debug.Log("Enemy has killed you");
        }
        //If player hits wall, then it slows down
        if(colliderPlayer.gameObject.tag == "Wall")
        {
            Debug.Log("You slow down");
            SlowDown = true;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Debug.Log("No more SLOW DOWN");
            SlowDown = false;
        }
    }

    //Buttons to move
    public void ButtonMovementForPlayer()
    {
        if(moveLeft)
        {
            horizontalMoving = -speed;
        }
        else if(moveRight)
        {
            horizontalMoving = speed;
        }
        else
        {
            horizontalMoving = 0;
        }
    }
    public void PointerDownLeft()
    {
        moveLeft = true;
    }
    public void PointerUpLeft()
    {
        moveLeft = false;
    }
    public void PointerDownRight()
    {
        moveRight = true;
    }
    public void PointerUpRight()
    {
        moveRight = false;
    }
}
