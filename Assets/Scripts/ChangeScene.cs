using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{

    public Object scene;

    public void Start() {
        if (scene == null) {
            Debug.LogError("ChangeScene : " + transform.name + " n'a pas de scène de transition !");
        }
    }

    public void ChangeOnClick() {
        SceneManager.LoadScene(scene.name);
    }


}
