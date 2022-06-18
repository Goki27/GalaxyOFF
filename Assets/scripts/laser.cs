using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed*2 * Time.deltaTime);


        //destroy laser after gone

        if (transform.position.y> 5.56)
        {
            if(transform.parent!=null)
            {

            }
            Destroy(this.gameObject); 
        }
        
        
    }
    
}
