using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour
{
    float velocidad = 20;
    float salto = 1500;
    float rotacion = 40;
    bool canJump = true;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var angles = transform.rotation.eulerAngles;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("izquierda..");
            angles.y += Time.deltaTime * rotacion;
            // transform.rotation = Quaternion.Euler(angles);
            _desplazarEnY(-1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Derecha...");
            angles.y += Time.deltaTime * -rotacion;
            // transform.rotation = Quaternion.Euler(angles);
            _desplazarEnY();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("abanzar...");
            _desplazarEnX();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("abanzar...");
            _desplazarEnX(-1);
        }
        if (Input.GetKeyDown(KeyCode.Space)&& canJump)
        {
            Debug.Log("saltar");
            canJump = false;
            _onSaltar();
        }        
    }

    void _desplazarEnX(int dir = 1)
    {
        float verticalInput = Input.GetAxis("Vertical");
        float nuevaPos = verticalInput * velocidad * Time.deltaTime;

        //update the position    
        transform.position = dir == -1
        ? transform.position - new Vector3(-nuevaPos, 0, 0)
        : transform.position + new Vector3(nuevaPos, 0, 0);
    }
    void _desplazarEnY(int dir = 1)
    {
        float nuevaPos = dir * velocidad * Time.deltaTime;
        Debug.Log(dir);
        
        //update the position    
        transform.position = dir == -1
        ? transform.position - new Vector3(0, 0,-nuevaPos)
        : transform.position + new Vector3( 0, 0,nuevaPos);
    }
    private void _onSaltar()
    {
        GetComponent<Rigidbody>().AddForce(0,salto*Time.deltaTime*100,0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "ground")
        {
            canJump = true;
        }
    }
}
