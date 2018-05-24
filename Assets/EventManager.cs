using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour {

    public string level;
    private void Update()
    {
        if (Time.timeSinceLevelLoad > 4f)
        {
            SceneManager.LoadScene( level );
        }
    }


}
