using UnityEngine;

internal class TutorialText : MonoBehaviour {
  
  [SerializeField]
  private Color color;
  
  public void OnClick() {
    crafter.AddInput(item);
  }
  
  internal void Complete() {
    button.enabled = false;
    border.color = color;
  }
  
  private void Start() {
    SetItem(item);
  }
}
