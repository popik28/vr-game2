using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadPlayerButton : MonoBehaviour
{
    private float health;
    private GameObject player;
    public static bool clickedLoad;

    public void Start()
    {
        clickedLoad = false;
    }
    public void LoadPlayer()
    {
        //SceneManager.LoadSceneAsync(1);
        StartCoroutine(LoadLevel());
        clickedLoad = true;

        //PlayerData data = SaveSystem.LoadPlayer();
        //player = GameObject.FindGameObjectWithTag("Player");
        //player.GetComponent<PlayerHealth>().setHealth(data.health);

        //float x = data.position[0];
        //float y = data.position[1];
        //float z = data.position[2];

        //player.transform.position = new Vector3(x, y ,z);
    }

    IEnumerator LoadLevel()
    {
        var asyncLoadLevel = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);

        while (!asyncLoadLevel.isDone)
        {
            Debug.Log("LOADING LEVEL");
            yield return null;
        }

        Debug.Log("LEVEL LOADED");
        yield return new WaitForSeconds(1);
    }

}
