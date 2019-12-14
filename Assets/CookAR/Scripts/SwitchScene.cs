using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchScene : MonoBehaviour
{
    public void ChangeScene(string sceneNameToLoad)
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
