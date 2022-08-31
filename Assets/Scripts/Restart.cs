using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    //Функция загружает сцену
    public void RestartScene()
    {
        SceneManager.LoadScene("Physics");
    }
}
