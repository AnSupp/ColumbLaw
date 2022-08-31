using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    //пусковые сферы
    public GameObject Sphere1;
    public GameObject Sphere4;
    public GameObject Sphere;
    public GameObject Sphere3;

    /// Функция восстанавливает течение времени,
    /// разрешает выбор и перемещение сфер
    public void RulesMenuDisable()
    {
        Time.timeScale = 1f;    //запускаем течение времени

        //разрешаем выбирать сферы
        Sphere.GetComponent<SelectSphere>().enabled = true;
        Sphere1.GetComponent<SelectSphere>().enabled = true;
        Sphere3.GetComponent<SelectSphere>().enabled = true;
        Sphere4.GetComponent<SelectSphere>().enabled = true;

        //разрешаем перемещать сферы
        Sphere.GetComponent<Teleport>().enabled = true;
        Sphere1.GetComponent<Teleport>().enabled = true;
        Sphere3.GetComponent<Teleport>().enabled = true;
        Sphere4.GetComponent<Teleport>().enabled = true;
    }

    /// Функция ставит паузу,
    /// запрещает выбор и перемещение сфер
    public void RulesMenuEnable()
    {
        Time.timeScale = 0f;    //останавливаем время (пауза)

        //запрещаем выбирать сферы
        Sphere.GetComponent<SelectSphere>().enabled = false;
        Sphere1.GetComponent<SelectSphere>().enabled = false;
        Sphere3.GetComponent<SelectSphere>().enabled = false;
        Sphere4.GetComponent<SelectSphere>().enabled = false;

        //запрещаем перемещать сферы
        Sphere.GetComponent<Teleport>().enabled = false;
        Sphere1.GetComponent<Teleport>().enabled = false;
        Sphere3.GetComponent<Teleport>().enabled = false;
        Sphere4.GetComponent<Teleport>().enabled = false;
    }
}
