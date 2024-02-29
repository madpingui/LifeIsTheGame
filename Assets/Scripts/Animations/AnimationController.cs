using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator characterAnimator;

    void Awake()
    {
        characterAnimator = GetComponent<Animator>();
        AnimationManager.AnimationChosenEvent += AnimateCharacter;
        AnimateCharacter();
    }
    void AnimateCharacter() => characterAnimator.SetTrigger(AnimationManager.Instance.GetCurrentAnimationName());
}

