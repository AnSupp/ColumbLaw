using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectSphere : MonoBehaviour
{
    EventSystem SelectEventSystem; //������� �������
    [HideInInspector] public Teleport Teleport;

    [HideInInspector] public GameObject CurrentSelectedSphere; //������� �����
    [HideInInspector] public GameObject PrevSelectedGameObject; //���������� �����

    //�������� �����
    public GameObject Sphere1;
    public GameObject Sphere4;
    public GameObject Sphere;
    public GameObject Sphere3;

    //��������� ���������� ����
    Vector3 defA1;
    Vector3 defB1;
    Vector3 defC1;
    Vector3 defD1;

    public bool SphereSelectedFlag = false; //���� ��������� ����������� ����

    //���������� ��������� �������� ��������� � �������� ����
    void OnEnable()
    {
        defA1 = Sphere1.transform.position;
        defB1 = Sphere4.transform.position;
        defC1 = Sphere.transform.position;
        defD1 = Sphere3.transform.position;
        SelectEventSystem = EventSystem.current;
    }

    /// �������, ������� ���������� ����� �� �������� ���������
    void PrevReturn()
    {
        Vector3 defA = defA1;
        Vector3 defB = defB1;
        Vector3 defC = defC1;
        Vector3 defD = defD1;

        PrevSelectedGameObject = CurrentSelectedSphere; //������� ����� ���������� �������
        PrevSelectedGameObject.GetComponent<Outline>().enabled = false; //��������� ���������

        //���������� ����� �� �������� ���������
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
        SphereSelectedFlag = false; //��������� �����������
    }

    /// ������� �������� �� ����� � ������ ������ ����
    void Update()
    {
        if (Teleport.PhysicsOnFlag == false) //���� ����� �� ������ ��������������
        {
            if (Input.GetMouseButtonDown(0)) //�� ������� ���
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //���, ������� ���� �� ������ ����� �����

                if (UnityEngine.Physics.Raycast(ray, out hit)) //���� ��������� ��������� �� �������
                {
                    if (hit.collider != null) //���� ��� ����� � ������ � �����������
                    {
                        GameObject SelectedGameObject = hit.collider.gameObject; //�������� ������
                        if (!SelectedGameObject.GetComponent<Outline>()) //���� ������ �� ����� ���������� ��������� (�.�. �� �������� �����)
                        {
                            PrevReturn(); //���������� �����
                            return;       //�������
                        }

                        if (SelectEventSystem.currentSelectedGameObject != CurrentSelectedSphere) //��� ��������� ������ �� ������� �����
                        {
                            PrevReturn(); //���������� �����
                        }

                        SelectEventSystem.SetSelectedGameObject(SelectedGameObject); //������ ���������� ��������� ��� ������� �������
                        CurrentSelectedSphere = SelectEventSystem.currentSelectedGameObject; //������ ������ �������
                        CurrentSelectedSphere.GetComponent<Outline>().enabled = true;   //�������� ��������� ��������� �����

                        SphereSelectedFlag = true; //��������� �����������
                    }
                }
                else //����� ���������� �����
                {
                    PrevReturn();
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape)) //�� ������� Escape
            {
                PrevReturn();   //���������� �����
            }
        }
    }
}