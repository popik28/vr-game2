using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitch : MonoBehaviour
{

    public void playGame()
    {
       SceneManager.LoadScene(1);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    SceneManager.LoadScene(0);
    //}
}
