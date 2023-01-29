using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField]
    public int _number;
    Vector3 _position;
    Quaternion _quaternion;
    Color _color;
    public Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        _position = transform.localPosition;
        _quaternion =  transform.localRotation;
        Color temoColor = GetComponentInChildren<Renderer>().material.color;
        _color = new Color(temoColor.r, temoColor.g, temoColor.b);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void grayOut()
    {
        float H, S, V;
        Color.RGBToHSV(_color, out H, out S, out V);
        S = 0.2f;
        GetComponentInChildren<Renderer>().material.color = Color.HSVToRGB(H,S,V);
    }

    public void resetPosition()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.localPosition = _position;
        transform.localRotation = _quaternion;
        float H, S, V;
        Color.RGBToHSV(_color, out H, out S, out V);
        S = 1.0f;
        GetComponentInChildren<Renderer>().material.color = Color.HSVToRGB(H, S, V);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Ring otherRing = collision.gameObject.GetComponent<Ring>();
        if (otherRing)
        {
            //Groﬂer Ring auf kleinem Ring (Objekt selbst ist der Groﬂe Ring)
            if (_number > otherRing._number)
            {
                //Objekt y position ist hˆher => Groﬂer Ring liegt oben
                if (GetComponent<Rigidbody>().worldCenterOfMass.y > collision.gameObject.GetComponent<Rigidbody>().worldCenterOfMass.y)
                {
                    Debug.Log("Lost game");
                    manager.GameOver();
                }
            }
        }
    }*/

}
