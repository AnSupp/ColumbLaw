using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Physics : MonoBehaviour
{
    //массив притягивающихся сфер
    [SerializeField] private Rigidbody[] affectedBodies_plus;
    //массив отталкивающихся сфер
    [SerializeField] private Rigidbody[] affectedBodies_minus;

    [HideInInspector] public Teleport Teleport;

    public GameObject VictoryMenuUI; //панель с сообщением об удачном проведении опыта
    public GameObject FailMenuUI;   //панель с сообщением о неудачном проведении опыта
    public Button InfoButton;       //кнопка справки
    public Button RestartButton;    //кнопка перезапуска

    float strength_p = 0;   //значение притягивающей силы
    float strength_n = 0;   //значение отталкивающей силы

    /// Функция отвечает за физическое взаимодействие - притяжение 
    /// и отталкивание сфер.
    /// В случае равенства притягивающей и отталкивабщей силы, воздействующих
    /// на пусковую сферы, выводит окно с сообщением об удачном проведении опыта
    private void FixedUpdate()
    {
        if (Teleport.PhysicsOnFlag == true) //если разрешено физическое взаимодействие
        {
            if (GetComponent<Rigidbody>() != null) //только для пусковой сферы
            {
                foreach (Rigidbody body in affectedBodies_plus) //для всех притягивающих сфер
                {
                    if (body == null)   //не пытаемся взаимодействовать со сферами, не вовлеченными в опыт
                    {
                        continue;
                    }

                    Vector3 dir_p = (transform.position - body.transform.position); //расчитываем вектор направления силы

                    float distance_p = dir_p.sqrMagnitude;
                    var direction_p = dir_p.normalized; //нормированный вектор

                    strength_p = (body.mass * GetComponent<Rigidbody>().mass) / distance_p; //расчет модуля силы по формуле закона

                    body.AddForce(direction_p * strength_p); //прикладываем силу
                }
                foreach (Rigidbody body in affectedBodies_minus) //для всех отталкивающих сфер
                {
                    if (body == null)   //не пытаемся взаимодействовать со сферами, не вовлеченными в опыт
                    {
                        continue;
                    }

                    Vector3 dir_n = (body.transform.position - transform.position); //расчитываем вектор направления силы

                    float distance_n = dir_n.sqrMagnitude;
                    var direction_n = dir_n.normalized; //нормированный вектор

                    strength_n = (body.mass * GetComponent<Rigidbody>().mass) / distance_n; //расчет модуля силы по формуле закона
                    
                    body.AddForce(direction_n * strength_n); //прикладываем силу
                }


                if (strength_p == strength_n) //если притягивающая и отталкивающая силы равны
                {
                    if (GetComponent<SelectSphere>()) //для пусковой сферы
                    {
                        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ; //закрепляем сферу
                        Invoke("VictoryMenu", 2.5f); //вызываем панель с сообщением об удачном проведении опыта
                    }
                   
                }
                else
                {
                    if (GetComponent<SelectSphere>()) //для пусковой сферы
                    {
                        Invoke("FailMenu", 2.5f); //вызываем панель с сообщением об удачном проведении опыта
                    }
                }
            }
        }
    }

    /// Функция выводит на экран панель с сообщением об удачном проведении опыта,
    /// запрещает взаимодействие с кнопками справки и перезапуска
    void VictoryMenu()
    {
        VictoryMenuUI.SetActive(true);
        InfoButton.interactable = false;
        RestartButton.interactable = false;
    }

    /// Функция выводит на экран панель с сообщением о неудачном проведении опыта,
    /// запрещает взаимодействие с кнопками справки и перезапуска
    void FailMenu()
    {
        FailMenuUI.SetActive(true);
        InfoButton.interactable = false;
        RestartButton.interactable = false;
    }

    /// Функция срабатывает при столкновении пусковой сферы с объектами
    //private void OnTriggerEnter(Collider other) 
    //{
    //    Invoke("FailMenu", 1f);
    //}
}
