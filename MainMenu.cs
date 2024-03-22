using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void goToScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
        Debug.Log(sceneName);
    }

    public void play(){Debug.Log("Play");}
    public void store(){Debug.Log("Store");}
    public void setting(){Debug.Log("Setting");}
}
