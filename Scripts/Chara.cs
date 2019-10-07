using UnityEngine;

internal class Chara : Icon {
  
  public void OnClick() {
    crafter.AddInput(item);
  }
  
  internal void Complete() {
    button.interactable = false;
    image.color = new Color(0, 0, 0);
  }
  
  private void Start() {
    SetItem(item);
  }
}
