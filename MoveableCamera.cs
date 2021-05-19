using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableCamera : MonoBehaviour
{

    private float _personRotationY = 0;
    private Vector3 _persionVeciloty;
    

    [Range(1, 10)]
    public float walkingSpeed = 2;
    [Range(1, 10)]
    public float mouseSensitivity = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this._persionVeciloty = new Vector3(0, this.transform.parent.GetComponent<Rigidbody>().velocity.y, 0);

        if (Input.GetKey(KeyCode.W))
        {
            this._persionVeciloty += this.transform.parent.forward * walkingSpeed;
        }
       
        if (Input.GetKey(KeyCode.S))
        {
            this._persionVeciloty -= this.transform.parent.forward * walkingSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            this._persionVeciloty += this.transform.parent.right * walkingSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            this._persionVeciloty -= this.transform.parent.right * walkingSpeed;
        }

        this.transform.parent.GetComponent<Rigidbody>().velocity = this._persionVeciloty;

        this._personRotationY += Input.GetAxis("Mouse X") * mouseSensitivity ;
        this.transform.localEulerAngles = new Vector3(Mathf.Clamp(Input.mousePosition.y / Screen.height * -180f + 90f, -90f, 90f),0, 0);
        this.transform.parent.localEulerAngles = new Vector3(0, this._personRotationY, 0);
    }

}
