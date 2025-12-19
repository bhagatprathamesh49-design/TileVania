using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    void OnTriggerEnter2D(Collider2D other)
    {

        StartCoroutine(LoadNextLevel());

        
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSeceneIndex = currentSceneIndex + 1;

        if(nextSeceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSeceneIndex = 0;
        }

        FindFirstObjectByType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSeceneIndex);
    }
}
