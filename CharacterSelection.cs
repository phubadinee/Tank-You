using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public CharacterBase[] charactersBase;

    public static CharacterBase returnCharacter;

    public int selectedCharacter = 0;

    public void Start() {
        Debug.Log("============== Start (Charactor Selection) ===============");
        SelectCharacter(selectedCharacter);
        ResourceBarTracker.Instance.UpdateBars(); 

        // returnCharacter = charactersBase[selectedCharacter];
    }   

    public void NextCharacter() 
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
        CharacterSelection.returnCharacter = charactersBase[selectedCharacter];
        Debug.Log("Return " + CharacterSelection.returnCharacter);
        ResourceBarTracker.Instance.UpdateBars(); 
    }

    public void PreviousCharacter() 
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0) {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
        CharacterSelection.returnCharacter = charactersBase[selectedCharacter];
        ResourceBarTracker.Instance.UpdateBars(); 
    }

    private void SelectCharacter(int index)
    {
        returnCharacter = charactersBase[index];
    }

    public CharacterBase GetSelectedCharacter()
    {
        return returnCharacter;
    }
}
