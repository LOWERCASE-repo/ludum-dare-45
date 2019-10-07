using UnityEngine;
using System.Collections;

internal class GoldPopup : MonoBehaviour {
  
  [SerializeField]
  private Animator animator;
  
  internal void Activate() {
    animator.SetTrigger("Activate");
  }
  
  public void Fade() {
    animator.SetTrigger("Fade");
    StartCoroutine(Existnt());
  }
  
  private IEnumerator Existnt() {
    yield return new WaitForSecondsRealtime(1f);
    gameObject.SetActive(false);
  }
}
