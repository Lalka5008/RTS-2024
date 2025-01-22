using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float VelocityMove; 
    public Transform Left;     
    public Transform Right;   
    public Transform Up;       
    public Transform Down;     

    void Update()
    {
        // Движение влево. получается низ
        if (Input.mousePosition.x < Left.position.x || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-VelocityMove * Time.deltaTime, 0, VelocityMove * Time.deltaTime);
        }
        // Движение вправо
        if (Input.mousePosition.x > Right.position.x || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(VelocityMove * Time.deltaTime, 0, -VelocityMove * Time.deltaTime);
        }
        // Движение вверх
        if (Input.mousePosition.y > Up.position.y || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(VelocityMove * Time.deltaTime, 0, VelocityMove * Time.deltaTime);
        }
        // Движение вниз
        if (Input.mousePosition.y < Down.position.y || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(-VelocityMove * Time.deltaTime, 0, -VelocityMove * Time.deltaTime);
        }
    }
}
