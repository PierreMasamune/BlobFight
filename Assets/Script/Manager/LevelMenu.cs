using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelMenu : MonoBehaviour
{
    public void OpenLevel(int levelID)
    {
        // Load the scene corresponding to the levelID
        string sceneName = "Level " + levelID; // Assuming your scenes are named "Level1", "Level2", etc.
        SceneManager.LoadScene(sceneName);
    }



}
