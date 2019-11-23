using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMover : MonoBehaviour
{

    public float HeightOffset;
    public float TimeMultiplier;
    private float Timer =0.0f;
    private Vector3 initialLocation; 
    // Start is called before the first frame update
    void Start()
    {
        initialLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        transform.position = new Vector3(0, Mathf.Sin(Timer * TimeMultiplier) * HeightOffset, 0) + initialLocation;
    }
}
