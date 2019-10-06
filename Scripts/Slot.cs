using UnityEngine;
using System.Collections;

internal class Slot : Icon {
  
  public void OnClick() {
    item = null;
    animator.SetBool("Active", false);
    crafter.Craft();
  }
  
  internal override void SetItem(Item item) {
    base.SetItem(item);
    animator.SetBool("Active", true);
  }
}
