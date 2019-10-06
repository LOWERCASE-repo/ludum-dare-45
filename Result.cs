using UnityEngine;

internal class Result : Icon {
  
  internal override void SetItem(Item item) {
    base.SetItem(item);
    animator.SetTrigger("Discover");
  }
}
