using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField] float ysens = 5.0f;
    public float minY = -30f;
    public float maxY = 30f;
    float rotateY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateY += Input.GetAxis("Mouse Y") * ysens;
        rotateY = Mathf.Clamp(rotateY, minY, maxY);
        transform.localEulerAngles = new Vector3(-rotateY, transform.localEulerAngles.y, 0);
    }
}
