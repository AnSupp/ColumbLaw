using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform target; //цель на которую будет смотреть объект

    // Update is called once per frame
    void Update()
    {
        //поворачивает объект так, 
        //чтобы он всегда смотрел в сторону камеры
        transform.LookAt(transform.position + target.forward);
    }
}
