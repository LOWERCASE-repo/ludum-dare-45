using UnityEngine;
using UnityEngine.UI;
using TMPro;

internal class Icon : MonoBehaviour {
  
  [SerializeField]
  internal Item item;
  [SerializeField]
  internal Crafter crafter;
  
  [Header("Components")]
  [SerializeField]
  protected Animator animator;
  [SerializeField]
  private Image image;
  [SerializeField]
  private TextMeshProUGUI text;
  
  internal virtual void SetItem(Item item) {
    this.item = item;
    image.sprite = item.sprite;
    text.text = item.name.ToUpper();
  }
}
