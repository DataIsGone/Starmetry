using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class LevelTransition : MonoBehaviour
{

    public Animator animator;
    private int levelToLoad;

    public void FadeToLevel (int levelIndex) {
        levelToLoad = levelIndex;
        animator.SetTrigger("fadeOut");
    }

    [YarnCommand("fade_out")]
    public void OnFadeComplete() {
        SceneManager.LoadScene(levelToLoad);
        levelToLoad = 0; // temporary, for demo
    }
}
