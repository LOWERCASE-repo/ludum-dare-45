using UnityEngine;
using System.Collections.Generic;
using System.Linq;

internal class Crafter : MonoBehaviour {
  
  private List<Item> inputs; // cant hashset, dupes
  private Recipe[] recipes;
  
  private bool CompareContents<T>(IEnumerable<T> list1, IEnumerable<T> list2) {
    var dict = new Dictionary<T, int>();
    foreach (T item in list1) {
      if (dict.ContainsKey(item)) {
        dict[item]++;
      } else {
        dict.Add(item, 1);
      }
    }
    foreach (T item in list2) {
      if (dict.ContainsKey(item)) {
        dict[item]--;
      } else {
        return false;
      }
    }
    return dict.Values.All(count => count == 0);
  }
  
  internal Item Craft(IEnumerable<Item> inputs) {
    foreach (Recipe recipe in recipes) {
      if (CompareContents(inputs, recipe.inputs)) {
        return recipe.result;
      }
    }
    return null;
  }
  
  internal void AddInput(Item item) {
    if (inputs.Count < 4) {
      inputs.Add(item);
    }
    Item result = Craft(inputs);
    if (result != null) Debug.Log(result);
  }
  
  internal void RemoveInput(Item item) {
    inputs.Remove(item);
  }
  
  private void Start() {
    inputs = new List<Item>();
    recipes = Resources.LoadAll("Recipes").Cast<Recipe>().ToArray();
    Debug.Log(Craft(inputs));
  }
}
