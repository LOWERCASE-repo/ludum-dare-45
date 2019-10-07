using UnityEngine;
using System.Collections;
using UnityEngine.UI;

internal class Letter : MonoBehaviour {
  
  [SerializeField]
  private Animator animator;
  [SerializeField]
  private Button button;
  
  public void Fade() {
    animator.SetTrigger("Fade");
  }
  
  public void Perish() {
    Destroy(gameObject);
  }
  
  private IEnumerator Start() {
    yield return new WaitForSecondsRealtime(2f);
    button.enabled = true;
  }
}
