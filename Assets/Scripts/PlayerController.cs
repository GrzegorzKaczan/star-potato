using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector3 targetPosition;

    int speed = 22;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        target = GameObject.Find("PlayerTarget");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaPosition = target.transform.position - transform.position;

        transform.position += deltaPosition / speed;
    }

    
}
