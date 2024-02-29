using System;
using UnityEngine;

public enum AnimationNames
{
    None,
    House,
    Macarena,
    HipHop
}

public class AnimationManager : MonoBehaviour
{
    // Singleton instance
    private static AnimationManager _instance;

    // Enum data
    private AnimationNames currentAnimation = AnimationNames.None;

    public static event Action AnimationChosenEvent;

    // Public accessor for the singleton instance
    public static AnimationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Check if an instance already exists in the scene
                _instance = FindObjectOfType<AnimationManager>();

                // If no instance exists, create a new one
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("AnimationManager");
                    _instance = singletonObject.AddComponent<AnimationManager>();
                }

                // Make the instance persistent across scenes
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    // Example method to set the current animation
    public void SetAnimation(AnimationNames newAnimation)
    {
        currentAnimation = newAnimation;
        AnimationChosenEvent?.Invoke();
    }

    // Example method to get the current animation
    public string GetCurrentAnimationName() => currentAnimation.ToString();
}
