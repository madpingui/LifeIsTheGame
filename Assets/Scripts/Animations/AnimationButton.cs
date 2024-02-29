using System;
using UnityEngine;
using UnityEngine.UI;

public class AnimationButton : MonoBehaviour
{
    [SerializeField] private AnimationNames animationName;

    private void Awake() => this.GetComponent<Button>()?.onClick.AddListener(() => AnimationManager.Instance.SetAnimation(animationName));
}
