using UnityEngine;

internal class Chara : Icon {
  
  public void OnClick() {
    crafter.AddInput(item);
  }
  
  internal void Complete() {
    button.interactable = false;
    border.color = new Color(255, 215, 0);
  }
  
  private void Start() {
    SetItem(item);
  }
}
