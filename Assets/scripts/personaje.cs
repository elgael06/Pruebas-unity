using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour
{
    float velocidad = 10;
    private float salto = 1500;
    // float rotacion = 40;
    bool canJump = true;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        matenerDePieAlPlayer();
        movimientos();
        if (Input.GetKeyDown(KeyCode.Space)&& canJump)
        {
            Debug.Log("saltar");
            canJump = false;
            _onSaltar();
        }        
    }
    private void matenerDePieAlPlayer(){
        var angles = transform.rotation.eulerAngles;
        
        if(angles.x!=0 && angles.y!=0 && angles.z!=0){
            angles.x    = 0;
            angles.y    = 0;
            angles.z    = 0;
            transform.rotation = Quaternion.Euler(angles);
        }
    }
    private void movimientos(){
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("izquierda..");
            // angles.y += Time.deltaTime * rotacion;
            // transform.rotation = Quaternion.Euler(angles);
            _desplazarEnY(-1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Derecha...");
            // angles.y += Time.deltaTime * -rotacion;
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
    }
    private void _desplazarEnX(int dir = 1)
    {
        float verticalInput = Input.GetAxis("Vertical");
        Debug.Log("verticalInput "+verticalInput);
        float nuevaPos = verticalInput * velocidad * 1.2f * Time.deltaTime;

        //update the position    
        transform.position = dir == -1
        ? transform.position - new Vector3(-nuevaPos, 0, 0)
        : transform.position + new Vector3(nuevaPos, 0, 0);
    }
    private void _desplazarEnY(int dir = 1)
    {
        // float verticalInput = Input.GetAxis("Horizontal");
        // float nuevaPos = dir * verticalInput * velocidad * Time.deltaTime;
        float nuevaPos = dir * velocidad * Time.deltaTime;
        Debug.Log(dir);
        
        //update the position    
        transform.position = dir == -1
        ? transform.position - new Vector3(0, 0,-nuevaPos)
        : transform.position + new Vector3( 0, 0,nuevaPos);
    }
    private void _onSaltar()
    {
        GetComponent<Rigidbody>().AddForce(0,salto*Time.deltaTime*10,0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "ground")
        {
            canJump = true;
        }
    }
}
