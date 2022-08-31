using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //пусковые сферы
    public GameObject Sphere1;
    public GameObject Sphere4;
    public GameObject Sphere;
    public GameObject Sphere3;
    //подсветка точек перемещения
    public GameObject LightsPillars;

    //начальные координаты сфер
    Vector3 defA1;
    Vector3 defB1;
    Vector3 defC1;
    Vector3 defD1;

    public bool PhysicsOnFlag = false; //флаг разрешающий работу физики
    [HideInInspector] public SelectSphere SelectSphere;
    [HideInInspector] public GameObject SelectedSphere;

    // Start is called before the first frame update
    void Start()
    {
        //сохраняем начальные координаты сфер
        defA1 = Sphere1.transform.position;
        defB1 = Sphere4.transform.position;
        defC1 = Sphere.transform.position;
        defD1 = Sphere3.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 defA = defA1;
        Vector3 defB = defB1;
        Vector3 defC = defC1;
        Vector3 defD = defD1;

        //получаем выбранную сферу
        SelectedSphere = SelectSphere.CurrentSelectedSphere;
        //получаем ее координаты
        Vector3 pos = SelectedSphere.transform.position;

        if (SelectSphere.SphereSelectedFlag == true) //если разрешено перемещение
        {
            //перемещаем сферы в соответствии с нажатой клавишей
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectedSphere.transform.position = new Vector3(0, pos.y, 1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectedSphere.transform.position = new Vector3(0, pos.y, 3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectedSphere.transform.position = new Vector3(0, pos.y, 5);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SelectedSphere.transform.position = new Vector3(0, pos.y, 6);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                SelectedSphere.transform.position = new Vector3(0, pos.y, 7);
            }

            //если нажали SPACE - пробуем запустить опыт
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //если выбранная сфера не на своем начальном положении (т.е. установлена на линейку)
                if (((SelectedSphere == Sphere1) && (SelectedSphere.transform.position != new Vector3(defA.x, defA.y, defA.z)))
                    || ((SelectedSphere == Sphere4) && (SelectedSphere.transform.position != new Vector3(defB.x, defB.y, defB.z)))
                    || ((SelectedSphere == Sphere) && (SelectedSphere.transform.position != new Vector3(defC.x, defC.y, defC.z)))
                    || ((SelectedSphere == Sphere3) && (SelectedSphere.transform.position != new Vector3(defD.x, defD.y, defD.z))))
                {
                    SelectedSphere.GetComponent<Outline>().enabled = false; //выключаем подсветку

                    if (gameObject != SelectedSphere)   //если сфера не выбранная
                    {
                        Destroy(gameObject.GetComponent<Rigidbody>()); //удаляем компонент Rigidbody, чтобы не взаимодействовать с ней
                    }

                    PhysicsOnFlag = true; //разрешаем работу физики
                    SelectSphere.SphereSelectedFlag = false; //запрещаем выбор сфер

                    Destroy(LightsPillars); //удаляем подсветку точек перемещения
                }
            }
        }
    }
}
