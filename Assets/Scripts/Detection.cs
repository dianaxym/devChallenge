using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    // Start is called before the first frame update
    public Material mat;
    public bool ifEnd = false;

    public AudioSource touch;
    void Start()
    {
        mat = GetComponent<Renderer>().material;


    }

    // Update is called once per frame
    void Update()
    {
        print(ifEnd);
    }

    void OnTriggerEnter(Collider other)
        
    {
        touch.Play();
        if (other.gameObject.tag == "Wall")
        {

            mat.color = other.gameObject.GetComponent<Renderer>().material.color;
            
        }

        if (other.gameObject.tag == "target")
        {
            ifEnd = true;


        }


    }



    void OnTriggerExit(Collider other)
    {
        

        if (other.gameObject.tag == "target")
        {

           
            ifEnd = false;

        }
        print(ifEnd);

    }
}
