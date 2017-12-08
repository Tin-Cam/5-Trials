using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public float speed;
    public float maxLength;
    public float minLength;

    float length;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        length = length + speed;

        if (length >= maxLength || length <= minLength)
            speed = -speed;

        transform.localScale = new Vector3(length, transform.localScale.y, transform.localScale.z);
	}
}
