using UnityEngine;

internal class Chara : Icon {
  
  public void OnClick() {
    crafter.AddInput(item);
  }
  
  private void Start() {
    SetItem(item);
  }
}
