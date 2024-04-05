using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {
public float kecepatan;
public float tepikiri;
public float tepikanan;
public string axis;
// Use this for initialization
void Start () 
{
}
// Update is called once per frame
void Update () {
float gerak = Input.GetAxis(axis) * kecepatan * Time.deltaTime;
float nextPos = transform.position.x + gerak;
if (nextPos > tepikiri){
    gerak = 0;
}
if (nextPos < tepikanan){
    gerak = 0;
}
transform.Translate(gerak, 0, 0);
}
}