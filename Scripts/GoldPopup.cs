using UnityEngine;

internal class GoldPopup : MonoBehaviour {
  
  [SerializeField]
  private Animator animator;
  
  internal void Activate() {
    animator.SetTrigger("Activate");
  }
  
  public void Fade() {
    animator.SetTrigger("Fade");
  }
}
