using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

internal class Crafter : MonoBehaviour {
  
  // TODO move to new table class
  private Item[] inputs; // cant hashset, dupes
  [SerializeField]
  private Image[] images;
  [SerializeField]
  private Animator[] animators;
  private List<Recipe> recipes;
  
  [SerializeField]
  private Chara chara;
  [SerializeField]
  private Transform inventory;
  
  private bool CompareContents<T>(IEnumerable<T> list1, IEnumerable<T> list2) {
    var dict = new Dictionary<T, int>();
    foreach (T item in list1) {
      if (item == null) continue;
      if (dict.ContainsKey(item)) {
        dict[item]++;
      } else {
        dict.Add(item, 1);
      }
    }
    foreach (T item in list2) {
      if (item == null) continue;
      if (dict.ContainsKey(item)) {
        dict[item]--;
      } else {
        return false;
      }
    }
    return dict.Values.All(count => count == 0);
  }
  
  private void UpdateTable(int index) {
    if (inputs[index] != null) {
      images[index].sprite = inputs[index].sprite;
      animators[index].SetBool("Active", true);
    } else {
      animators[index].SetBool("Active", false);
    }
  }
  
  internal Item Craft(IEnumerable<Item> inputs) {
    Item result = null;
    for (int i = 0; i < recipes.Count; i++) {
      if (CompareContents(inputs, recipes[i].inputs)) {
        result = recipes[i].result;
      }
    }
    for (int i = recipes.Count - 1; i >= 0; i--) {
      if (result == recipes[i].result) {
        recipes.RemoveAt(i);
      }
    }
    return result;
  }
  
  internal void AddInput(Item item) {
    for (int i = 0; i < 4; i++) {
      if (inputs[i] == null) {
        inputs[i] = item;
        UpdateTable(i);
        break;
      }
    }
    Item result = Craft(inputs);
    if (result != null) { // if not null and not exist
      Chara chara = Instantiate(this.chara, inventory);
      chara.item = result;
      chara.crafter = this;
      for (int i = 0; i < 4; i++) {
        RemoveInput(i);
      }
    }
  }
  
  internal void RemoveInput(int index) {
    inputs[index] = null;
    UpdateTable(index);
  }
  
  private void Start() {
    inputs = new Item[4];
    recipes = Resources.LoadAll("Recipes").Cast<Recipe>().ToList();
  }
}
