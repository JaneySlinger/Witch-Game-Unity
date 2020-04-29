using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : MonoBehaviour
{

    public GameObject shot;
    public Transform shotTransform;

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("q") && Time.time > nextFire){
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotTransform.position, shotTransform.rotation);
        }
    }
}
