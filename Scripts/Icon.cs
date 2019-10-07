using UnityEngine;
using UnityEngine.UI;
using TMPro;

internal class Icon : MonoBehaviour {
  
  // TODO change border colour when completed
  
  [SerializeField]
  internal Item item;
  [SerializeField]
  internal Crafter crafter;
  
  [Header("Components")]
  [SerializeField]
  protected Animator animator;
  [SerializeField]
  protected Image image;
  [SerializeField]
  protected Button button;
  [SerializeField]
  protected RawImage border;
  [SerializeField]
  private TextMeshProUGUI text;
  
  internal virtual void SetItem(Item item) {
    this.item = item;
    image.sprite = item.sprite;
    text.text = item.name;
    // text.text = item.name.ToUpper();
  }
}
