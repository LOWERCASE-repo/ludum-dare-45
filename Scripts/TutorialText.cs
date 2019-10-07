using UnityEngine;
using System.Collections;

internal class TutorialText : MonoBehaviour {
  
  [SerializeField]
  private Animator animator;
  
  internal void Fade() {
    if (animator != null) {
      animator.SetTrigger("Fade");
      StartCoroutine(death());
    }
  }
  
  private IEnumerator death() {
    yield return new WaitForSecondsRealtime(1f);
    gameObject.SetActive(false);
  }
}
