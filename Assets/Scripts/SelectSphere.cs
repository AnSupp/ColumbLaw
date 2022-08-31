using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectSphere : MonoBehaviour
{
    EventSystem SelectEventSystem; //система событий
    [HideInInspector] public Teleport Teleport;

    [HideInInspector] public GameObject CurrentSelectedSphere; //текущая сфера
    [HideInInspector] public GameObject PrevSelectedGameObject; //предыдущая сфера

    //пусковые сферы
    public GameObject Sphere1;
    public GameObject Sphere4;
    public GameObject Sphere;
    public GameObject Sphere3;

    //начальные координаты сфер
    Vector3 defA1;
    Vector3 defB1;
    Vector3 defC1;
    Vector3 defD1;

    public bool SphereSelectedFlag = false; //флаг разрешает перемещение сфер

    //запоминаем начальные значения координат у пусковых сфер
    void OnEnable()
    {
        defA1 = Sphere1.transform.position;
        defB1 = Sphere4.transform.position;
        defC1 = Sphere.transform.position;
        defD1 = Sphere3.transform.position;
        SelectEventSystem = EventSystem.current;
    }

    /// Функция, которая возвращает сферу на исходное положение
    void PrevReturn()
    {
        Vector3 defA = defA1;
        Vector3 defB = defB1;
        Vector3 defC = defC1;
        Vector3 defD = defD1;

        PrevSelectedGameObject = CurrentSelectedSphere; //текущая сфера становится прошлой
        PrevSelectedGameObject.GetComponent<Outline>().enabled = false; //отключаем подсветку

        //возвращаем сферу на исходное положение
        if (PrevSelectedGameObject == Sphere1)
        {
            PrevSelectedGameObject.transform.position = new Vector3(defA.x, defA.y, defA.z);
        }
        if (PrevSelectedGameObject == Sphere4)
        {
            PrevSelectedGameObject.transform.position = new Vector3(defB.x, defB.y, defB.z);
        }
        if (PrevSelectedGameObject == Sphere)
        {
            PrevSelectedGameObject.transform.position = new Vector3(defC.x, defC.y, defC.z);
        }
        if (PrevSelectedGameObject == Sphere3)
        {
            PrevSelectedGameObject.transform.position = new Vector3(defD.x, defD.y, defD.z);
        }
        SphereSelectedFlag = false; //запрещаем перемещение
    }

    /// Функция отвечает за выбор и отмену выбора сфер
    void Update()
    {
        if (Teleport.PhysicsOnFlag == false) //если сферы не начали взаимодействие
        {
            if (Input.GetMouseButtonDown(0)) //по нажатию ЛКМ
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //луч, который идет от камеры через экран

                if (UnityEngine.Physics.Raycast(ray, out hit)) //если совершено попадание по объекту
                {
                    if (hit.collider != null) //если луч попал в объект с коллайдером
                    {
                        GameObject SelectedGameObject = hit.collider.gameObject; //выбираем объект
                        if (!SelectedGameObject.GetComponent<Outline>()) //если объект не имеет компонента подсветки (т.е. не пусковая сфера)
                        {
                            PrevReturn(); //возвращаем сферу
                            return;       //выходим
                        }

                        if (SelectEventSystem.currentSelectedGameObject != CurrentSelectedSphere) //ели выбранный объект не текущая сфера
                        {
                            PrevReturn(); //возвращаем сферу
                        }

                        SelectEventSystem.SetSelectedGameObject(SelectedGameObject); //объект становится выбранным для системы событий
                        CurrentSelectedSphere = SelectEventSystem.currentSelectedGameObject; //делаем обхект текущим
                        CurrentSelectedSphere.GetComponent<Outline>().enabled = true;   //включаем подсветку выбранной сферы

                        SphereSelectedFlag = true; //разрешаем перемещение
                    }
                }
                else //иначе возвращаем сферу
                {
                    PrevReturn();
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape)) //по нажатию Escape
            {
                PrevReturn();   //возвращаем сферу
            }
        }
    }
}