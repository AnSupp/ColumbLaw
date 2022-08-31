using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //�������� �����
    public GameObject Sphere1;
    public GameObject Sphere4;
    public GameObject Sphere;
    public GameObject Sphere3;
    //��������� ����� �����������
    public GameObject LightsPillars;

    //��������� ���������� ����
    Vector3 defA1;
    Vector3 defB1;
    Vector3 defC1;
    Vector3 defD1;

    public bool PhysicsOnFlag = false; //���� ����������� ������ ������
    [HideInInspector] public SelectSphere SelectSphere;
    [HideInInspector] public GameObject SelectedSphere;

    // Start is called before the first frame update
    void Start()
    {
        //��������� ��������� ���������� ����
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

        //�������� ��������� �����
        SelectedSphere = SelectSphere.CurrentSelectedSphere;
        //�������� �� ����������
        Vector3 pos = SelectedSphere.transform.position;

        if (SelectSphere.SphereSelectedFlag == true) //���� ��������� �����������
        {
            //���������� ����� � ������������ � ������� ��������
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

            //���� ������ SPACE - ������� ��������� ����
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //���� ��������� ����� �� �� ����� ��������� ��������� (�.�. ����������� �� �������)
                if (((SelectedSphere == Sphere1) && (SelectedSphere.transform.position != new Vector3(defA.x, defA.y, defA.z)))
                    || ((SelectedSphere == Sphere4) && (SelectedSphere.transform.position != new Vector3(defB.x, defB.y, defB.z)))
                    || ((SelectedSphere == Sphere) && (SelectedSphere.transform.position != new Vector3(defC.x, defC.y, defC.z)))
                    || ((SelectedSphere == Sphere3) && (SelectedSphere.transform.position != new Vector3(defD.x, defD.y, defD.z))))
                {
                    SelectedSphere.GetComponent<Outline>().enabled = false; //��������� ���������

                    if (gameObject != SelectedSphere)   //���� ����� �� ���������
                    {
                        Destroy(gameObject.GetComponent<Rigidbody>()); //������� ��������� Rigidbody, ����� �� ����������������� � ���
                    }

                    PhysicsOnFlag = true; //��������� ������ ������
                    SelectSphere.SphereSelectedFlag = false; //��������� ����� ����

                    Destroy(LightsPillars); //������� ��������� ����� �����������
                }
            }
        }
    }
}
