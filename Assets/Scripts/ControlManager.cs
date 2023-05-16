using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject character;
    public GameObject guide_cube;
    public GameObject camera;
    public GameObject wall;
    public GameObject target;

    Vector3 cam_pos;
    Vector3 offset;
    float cam_rotate_x;
    float cam_rotate_y;
    public Detection detection;
    public Timer timer;

    public Color target_col;

    public float movementSpeed = 1;
    public float mouseSensitivityX = 1;
    public float mouseSensitivityY = 1;
    int x =1;

 
    void Start()
    {
       offset = new Vector3(0, 0, 5);
       for (var i = 0; i < 100; i++)
       {
            GameObject wall_ = Instantiate(wall, new Vector3(Random.Range(-25.0f, 25.0f), Random.Range(-10.0f,10.0f), Random.Range(-25.0f, 25.0f)), Quaternion.identity);
            Color newColor = new Color(Random.value, Random.value, Random.value);
            float localScale = Random.Range(-3, 3);
            wall_.transform.localScale += new Vector3(localScale, localScale, localScale);
            // Create a new material with the random color
            Material newMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
            newMaterial.color = newColor;
           // if (i == 50)
            //{
                //wall_.GetComponent<Collider>().isTrigger= false;
                //wall_.GetComponent<Rigidbody>().isKinematic = true;
              //  wall_.GetComponent<Renderer>().material.color = Color.white;
              //  wall_.tag = "target";

            //}
            //else
            //{
                if(i == 75)
                {
                    target_col = newColor;
                }
                // Assign the new material to the cube
                wall_.GetComponent<Renderer>().material = newMaterial;
            //}
          
        }
        guide_cube.GetComponent<Renderer>().material.color = target_col;
    }

    // Update is called once per frame
    void Update()
    {


        cam_rotate_x = Input.GetAxis("Mouse X") * mouseSensitivityX;
        cam_rotate_y = Input.GetAxis("Mouse Y") * mouseSensitivityY;
        camera.transform.RotateAround(character.transform.position, Vector3.up, -cam_rotate_x);
        camera.transform.Rotate(new Vector3(-cam_rotate_y,0,0));
        cam_pos = character.transform.position - camera.transform.position - offset;


        //movement control
        if (Input.GetKey("w"))
        {
            Vector3 cameraDir = camera.transform.forward;
            cameraDir.y = 0f; 

            character.transform.LookAt(character.transform.position + cameraDir);
            character.transform.position += cameraDir* movementSpeed * Time.deltaTime;
            camera.transform.position += cameraDir* movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s"))
        {
            Vector3 cameraDir = -camera.transform.forward;
            cameraDir.y = 0f;

            character.transform.LookAt(character.transform.position + cameraDir);
            character.transform.position += cameraDir * movementSpeed * Time.deltaTime;
            camera.transform.position += cameraDir * movementSpeed * Time.deltaTime;

        }
    

        if (Input.GetKey("a"))
        {
            Vector3 cameraDir = -camera.transform.right;
            cameraDir.y = 0f;

            character.transform.LookAt(character.transform.position + cameraDir);
            character.transform.position += cameraDir * movementSpeed * Time.deltaTime;
            camera.transform.position += cameraDir * movementSpeed * Time.deltaTime;


        }

        if (Input.GetKey("d"))
        {
            Vector3 cameraDir = camera.transform.right;
            cameraDir.y = 0f;

            character.transform.LookAt(character.transform.position + cameraDir);
            character.transform.position += cameraDir * movementSpeed * Time.deltaTime;
            camera.transform.position += cameraDir * movementSpeed * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.Space))
        {
            character.transform.position += Vector3.up * movementSpeed * Time.deltaTime;
            camera.transform.position += (Vector3.up * movementSpeed * Time.deltaTime);
        }



        if (detection.ifEnd == false || detection.mat.color != target_col)
        {
            character.transform.position += (Vector3.down * movementSpeed / 3 * Time.deltaTime);
            camera.transform.position += (Vector3.down * movementSpeed / 3 * Time.deltaTime);

        }
        else
        {
            target.gameObject.GetComponent<Renderer>().material.color = detection.mat.color;
            timer.win = true;

        }





       
        // print(t);

    }




}
