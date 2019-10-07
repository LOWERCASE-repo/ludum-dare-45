using UnityEngine;

internal class TutorialText : MonoBehaviour {
  
  [SerializeField]
  private Animator animator;
  
  internal void Fade() {
    animator.SetTrigger("Fade");
  }
}
