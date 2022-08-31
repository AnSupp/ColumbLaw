using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    //�������� �����
    public GameObject Sphere1;
    public GameObject Sphere4;
    public GameObject Sphere;
    public GameObject Sphere3;

    /// ������� ��������������� ������� �������,
    /// ��������� ����� � ����������� ����
    public void RulesMenuDisable()
    {
        Time.timeScale = 1f;    //��������� ������� �������

        //��������� �������� �����
        Sphere.GetComponent<SelectSphere>().enabled = true;
        Sphere1.GetComponent<SelectSphere>().enabled = true;
        Sphere3.GetComponent<SelectSphere>().enabled = true;
        Sphere4.GetComponent<SelectSphere>().enabled = true;

        //��������� ���������� �����
        Sphere.GetComponent<Teleport>().enabled = true;
        Sphere1.GetComponent<Teleport>().enabled = true;
        Sphere3.GetComponent<Teleport>().enabled = true;
        Sphere4.GetComponent<Teleport>().enabled = true;
    }

    /// ������� ������ �����,
    /// ��������� ����� � ����������� ����
    public void RulesMenuEnable()
    {
        Time.timeScale = 0f;    //������������� ����� (�����)

        //��������� �������� �����
        Sphere.GetComponent<SelectSphere>().enabled = false;
        Sphere1.GetComponent<SelectSphere>().enabled = false;
        Sphere3.GetComponent<SelectSphere>().enabled = false;
        Sphere4.GetComponent<SelectSphere>().enabled = false;

        //��������� ���������� �����
        Sphere.GetComponent<Teleport>().enabled = false;
        Sphere1.GetComponent<Teleport>().enabled = false;
        Sphere3.GetComponent<Teleport>().enabled = false;
        Sphere4.GetComponent<Teleport>().enabled = false;
    }
}
