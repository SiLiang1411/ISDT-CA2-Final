using UnityEngine;
using UnityEngine.SceneManagement;
using DentedPixel;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    #region Variables
    //============================
    //Public Variables
    //============================
    public string gameScene; //Scene to Load
  
 




    #endregion

    //====================================================


    #region Own Method
    public void LoadNextScene()
    {
        
        Debug.Log("Loading...: " + gameScene);
        SceneManager.LoadScene(gameScene);
    }


    #endregion
}
