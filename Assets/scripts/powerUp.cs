using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    [SerializeField]
    private int powerUPid;
    [SerializeField]
    public float _speed=5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        
        
    }
    /* private void OnTriggerEnter2d(Collider2D other)
     {
         Debug.Log("hii u got fuked"+other.name);
         Player player = other.GetComponent<Player>();
         player.canTripleShot = true;
         Destroy(this.gameObject);
     }*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            Debug.Log("collider object : " + other.name);
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (powerUPid == 0)
                {
                    player.Tripleshoton();
                }else if (powerUPid==1)
                {
                    //boost
                    player.SpeedBoostPoweron();

                }else if (powerUPid==2)
                {
                    ///shield
                    ///
                    player.Enable_shield();
                }
            }
           
            Destroy(this.gameObject);
        }
        
    }
    
}
