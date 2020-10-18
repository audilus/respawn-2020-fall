using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{

    public string nextLevel;
    private Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
        }
    }

    public void changeLevel(string lvl)
    {
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
    }
}
