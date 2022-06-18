using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject Plyaer_explosion;
    [SerializeField]
    //private GameObject Tripshot;
    public bool canTripleShot = false;
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private float fireRate = 0.0025f;
    public float canFire = 0.0f;
    public float speed = 5.0f;
    public bool isSpeedboostActive = true;
    public bool shieldActive = false;
    public int lives = 3;
    [SerializeField]
    private GameObject _shieldGameObject; 
    // Start is called before the first frame update
    void Start()
    {
        
        transform.position = new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0))
        {
            _shoot();
        }
        
        movement();
    }
     private void _shoot()
    {
        if (Time.time > canFire)
        {
            if (canTripleShot==true)
            {
                //left
                   Instantiate(laser, transform.position + new Vector3(-0.59f, 0.88f, 0),Quaternion.identity);
                //centeer
                  Instantiate(laser, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
                //left
                  Instantiate(laser, transform.position + new Vector3(0.553f, 0.88f, 0), Quaternion.identity);
               // Instantiate(Tripshot, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(laser, transform.position + new Vector3(0, .88f, 0), Quaternion.identity);
                canFire = Time.time + fireRate;
            }
           
        }
    }
    private void movement()
    {


        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

       
        if (isSpeedboostActive == true)
        {

            transform.Translate(Vector3.right * Time.deltaTime * speed *1.5f* horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * speed*1.5f * verticalInput);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
        }
        //making player walk in a limited area
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }



        //if player in x>=8
        //playerposition=8
        /* if (transform.position.x>8.0f)
         {
             transform.position = new Vector3(8, transform.position.y, 0);
         }
         else if (transform.position.x<-8f)
         {
             transform.position = new Vector3(-8, transform.position.y, 0);

         }*/


        //to swap player from left to right
        if (transform.position.x > 9.05f)
        {
            transform.position = new Vector3(-9.05f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.05)
        {
            transform.position = new Vector3(9.05f, transform.position.y, 0);
        }
    }

    public void damage()
    {
        if (shieldActive == true)
        {
            shieldActive = false;
            _shieldGameObject.SetActive(false);
            return;
        }
        lives--;
        if (lives<1)
        {
            Instantiate(Plyaer_explosion, transform.position, Quaternion.identity); 
            Destroy(this.gameObject);
        }
    }
    public void Tripleshoton()
    {
        canTripleShot = true;
        StartCoroutine(tripleShotpowerDownRoutine());
    }

    public void Enable_shield()
    {
        shieldActive = true;
        _shieldGameObject.SetActive(true);
    }
    public void SpeedBoostPoweron()
    {
        isSpeedboostActive = true;
        StartCoroutine(SpeedBoostDown());
    }
        
        public IEnumerator tripleShotpowerDownRoutine()
        {
            yield return new WaitForSeconds(5.00f);
            canTripleShot = false;
        }
    public IEnumerator SpeedBoostDown()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedboostActive = false;

    }
    
}
