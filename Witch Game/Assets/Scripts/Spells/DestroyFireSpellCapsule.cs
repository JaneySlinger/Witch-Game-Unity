﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireSpellCapsule : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        DestroyObject(gameObject);
    }
} 