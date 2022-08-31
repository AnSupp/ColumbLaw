using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Physics : MonoBehaviour
{
    //������ ��������������� ����
    [SerializeField] private Rigidbody[] affectedBodies_plus;
    //������ ��������������� ����
    [SerializeField] private Rigidbody[] affectedBodies_minus;

    [HideInInspector] public Teleport Teleport;

    public GameObject VictoryMenuUI; //������ � ���������� �� ������� ���������� �����
    public GameObject FailMenuUI;   //������ � ���������� � ��������� ���������� �����
    public Button InfoButton;       //������ �������
    public Button RestartButton;    //������ �����������

    float strength_p = 0;   //�������� ������������� ����
    float strength_n = 0;   //�������� ������������� ����

    /// ������� �������� �� ���������� �������������� - ���������� 
    /// � ������������ ����.
    /// � ������ ��������� ������������� � ������������� ����, ��������������
    /// �� �������� �����, ������� ���� � ���������� �� ������� ���������� �����
    private void FixedUpdate()
    {
        if (Teleport.PhysicsOnFlag == true) //���� ��������� ���������� ��������������
        {
            if (GetComponent<Rigidbody>() != null) //������ ��� �������� �����
            {
                foreach (Rigidbody body in affectedBodies_plus) //��� ���� ������������� ����
                {
                    if (body == null)   //�� �������� ����������������� �� �������, �� ������������ � ����
                    {
                        continue;
                    }

                    Vector3 dir_p = (transform.position - body.transform.position); //����������� ������ ����������� ����

                    float distance_p = dir_p.sqrMagnitude;
                    var direction_p = dir_p.normalized; //������������� ������

                    strength_p = (body.mass * GetComponent<Rigidbody>().mass) / distance_p; //������ ������ ���� �� ������� ������

                    body.AddForce(direction_p * strength_p); //������������ ����
                }
                foreach (Rigidbody body in affectedBodies_minus) //��� ���� ������������� ����
                {
                    if (body == null)   //�� �������� ����������������� �� �������, �� ������������ � ����
                    {
                        continue;
                    }

                    Vector3 dir_n = (body.transform.position - transform.position); //����������� ������ ����������� ����

                    float distance_n = dir_n.sqrMagnitude;
                    var direction_n = dir_n.normalized; //������������� ������

                    strength_n = (body.mass * GetComponent<Rigidbody>().mass) / distance_n; //������ ������ ���� �� ������� ������
                    
                    body.AddForce(direction_n * strength_n); //������������ ����
                }


                if (strength_p == strength_n) //���� ������������� � ������������� ���� �����
                {
                    if (GetComponent<SelectSphere>()) //��� �������� �����
                    {
                        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ; //���������� �����
                        Invoke("VictoryMenu", 2.5f); //�������� ������ � ���������� �� ������� ���������� �����
                    }
                   
                }
                else
                {
                    if (GetComponent<SelectSphere>()) //��� �������� �����
                    {
                        Invoke("FailMenu", 2.5f); //�������� ������ � ���������� �� ������� ���������� �����
                    }
                }
            }
        }
    }

    /// ������� ������� �� ����� ������ � ���������� �� ������� ���������� �����,
    /// ��������� �������������� � �������� ������� � �����������
    void VictoryMenu()
    {
        VictoryMenuUI.SetActive(true);
        InfoButton.interactable = false;
        RestartButton.interactable = false;
    }

    /// ������� ������� �� ����� ������ � ���������� � ��������� ���������� �����,
    /// ��������� �������������� � �������� ������� � �����������
    void FailMenu()
    {
        FailMenuUI.SetActive(true);
        InfoButton.interactable = false;
        RestartButton.interactable = false;
    }

    /// ������� ����������� ��� ������������ �������� ����� � ���������
    //private void OnTriggerEnter(Collider other) 
    //{
    //    Invoke("FailMenu", 1f);
    //}
}
