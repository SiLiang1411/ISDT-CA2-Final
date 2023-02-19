using UnityEngine;

public class AppQuit : MonoBehaviour
{
    public void Exit() {

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
