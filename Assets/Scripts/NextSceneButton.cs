using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextSceneButton : MonoBehaviour
{
    private void Awake()
    {
        var button = GetComponent<Button>();
        button.interactable = false;
        button.onClick.AddListener(OnSpecialButtonClick);

        AnimationManager.AnimationChosenEvent += () => button.interactable = true; //If we already choose an animation then make it interactable.
    }

    public void OnSpecialButtonClick() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next scene in the build settings
}
