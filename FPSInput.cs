using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSInput : MonoBehaviour {

    public CharacterController controller;
    public GameObject Player;
    public GameObject spawn;
    public GameObject teleDestination;
    public GameObject teleDestination2;
    public GameObject HUD;
    public GameObject Menu;
    public GameObject loseText;
    public GameObject winText;
    public float speed = 5f;
    public float sprintSpeed = 7f;
    public float gravity = -10f;
    public float jumpHeight = 4f;
    public float standingHeight;
    public float crouchingHeight = 1.5f;
    public int health = 100;
    public int maxHealth = 100;
    public int objectiveScore = 0;
    public int finalScore = 0;
    private int increment = 0;
    public bool grounded;
    public bool walking;
    public bool sprinting;
    public bool crouching;
    public bool jumping;
    public bool onRotatingPlatform;
    public bool onNegRotatingPlatform;
    public bool lockedCursor = true;
    public bool canThrow = false;
    public AudioSource jumpSound;
    public AudioSource fireSound;
    public AudioSource damageSound;
    public AudioSource healthSound;
    public AudioSource JumpBoost;
    public AudioSource SpeedBoost;
    public StatHandler Stats;
    public ThrowScript throwing;
    public Animator animator;
    public Camera cam;
    Vector3 velocity;

    void Start()
    {
        loseText.SetActive(false);
        winText.SetActive(false);
        standingHeight = controller.height;
        Stats.setMaxHealth(maxHealth);
        Cursor.visible = false;
        Menu.SetActive(false);
        HUD.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;

    }

    // |Lose Controller|===================================================|
    IEnumerator youLose()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // |Win Controller|===================================================|
    IEnumerator youWin()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Start_Menu");
    }

    void Update() {

        // |Health Regulation|===================================================|
        if (health > 100)
        {
            health = 100;
        }

        else if ( health <= 0)
        {
            health = 0;
            loseText.SetActive(true);
            StartCoroutine(youLose());
        }

        // |Animations|===================================================|
        animator.SetFloat("Speed", speed);
        animator.SetBool("walking", walking);
        animator.SetBool("jumping", jumping);

        // |Pause Menu|===================================================|
        if (Input.GetKeyDown(KeyCode.Escape) && increment % 2 == 0)
        {
            cam.GetComponent<MouseLook_New>().enabled = false;
            cam.GetComponent<ThrowScript>().enabled = false;
            increment += 1;
            HUD.SetActive(false);
            Menu.SetActive(true);
            Cursor.visible = true;

        }

        else if (Input.GetKeyDown(KeyCode.Escape) && increment % 2 != 0)
        {
            cam.GetComponent<MouseLook_New>().enabled = true;
            cam.GetComponent<ThrowScript>().enabled = true;
            increment += 1;
            HUD.SetActive(true);
            Menu.SetActive(false);
            Cursor.visible = false;
        }

        if(Cursor.visible == true)
        {
            Cursor.lockState = CursorLockMode.None;
            lockedCursor = false;
        }

        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            lockedCursor = true;
        }

        // |WASD Controls|===================================================|
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        Vector3 moveAir = transform.forward * z;
        controller.Move(moveAir * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        grounded = controller.isGrounded;
        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
            controller.Move(move * speed * Time.deltaTime);
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !sprinting)
        {
            walking = true;
        }
        else
        {
            walking = false;
        }

        // |Jumping|=========================================================|
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravity);
            jumpSound.Play();
        }

        if (!grounded && Input.GetKeyDown(KeyCode.S)) {
            speed = 1.5f;
        }
        else if (grounded && sprinting)
        {
            speed = sprintSpeed;
            jumping = false;
        }

        else if(grounded && !sprinting)
        {
            speed = 5f;
            jumping = false;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
        }

        // |Sprinting|=======================================================|
        if (Input.GetKey(KeyCode.LeftShift) && !crouching)
        {
            sprinting = true;
        }

        else
        {
            sprinting = false;
        }

        if (sprinting)
        {
            cam.fieldOfView = 63f;
        }       

        else if (!sprinting)
        {
            cam.fieldOfView = 60f;
        }

        // |Crouching|======================================================|
        if (Input.GetKey(KeyCode.LeftControl))
        {
            crouching = true;
        }

        else
        {
            crouching = false;
        }

        if (crouching)
        {
            speed = 1.5f;
            controller.height = crouchingHeight;
        }

        else if (!crouching && sprinting)
        {
            speed = sprintSpeed;
            controller.height = standingHeight;
        }

        else if (!crouching && !sprinting)
        {
            speed = 5f;
            controller.height = standingHeight;
        }

        // |Rotating Platform Player Rotation|============================|
        if (onRotatingPlatform)
        {
            transform.Rotate(0, -.5f, 0);
        }

        if (onNegRotatingPlatform)
        {
            transform.Rotate(0, .5f, 0);
        }
    }

    // |Damage|=========================================================|
    public void damage(int damage)
    {
        health -= damage;
        Stats.setHealth(health);
        damageSound.Play();
    }

    public void heal(int heal)
    {
        health += heal;
        Stats.setHealth(health);
        healthSound.Play();
    }

    // |Jump and Speed Boosts|=========================================================|
    public void jumpUp(float jump)
    {
        JumpBoost.Play();
        jumpHeight = jump;
    }

    public void jumpBackToNormal()
    {
        jumpHeight = 4f;
    }

    public void speedUp()
    {
        Debug.Log("FPSSetSpeed");
        SpeedBoost.Play();
        sprintSpeed = 20;
    }

    public void speedBackToNormal()
    {
        Debug.Log("FPSBackToNormal");
        sprintSpeed = 7;
    }

    // |Moving Platform Collisions|=========================================================|
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Transporter")
        {
            transform.position = spawn.transform.position;
        }

        if (other.gameObject.tag == "Transporter2")
        {
            transform.position = teleDestination.transform.position;
        }

        if (other.gameObject.tag == "Transporter3")
        {
            transform.position = teleDestination2.transform.position;
        }

        if (other.gameObject.tag == "Win" && objectiveScore >= finalScore)
        {
            winText.SetActive(true);
            StartCoroutine(youWin());
            Destroy(other.gameObject);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "RotatingPlatform")
        {
            onRotatingPlatform = true;
            transform.parent = other.transform;
        }

        if (other.gameObject.tag == "NegRotatingPlatform")
        {
            onNegRotatingPlatform = true;
            transform.parent = other.transform;
        }

        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "RotatingPlatform" || other.gameObject.tag == "NegRotatingPlatform")
        {
            onRotatingPlatform = false;
            onNegRotatingPlatform = false;
            transform.parent = null;
        }

        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}
