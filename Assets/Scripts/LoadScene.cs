
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour {

    public void LoadLevel()
    {
        print("loadlevel has been called");
        SceneManager.LoadScene ("Level1");
    }


}
