using UnityEngine;

public class CharactorSelect : MonoBehaviour
{
    public static CharactorSelect instance;
    public CharacterScriptableObjects characterData;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("EXTRA" + this + "DELETED");
            Destroy(gameObject);
        }
    }
    
    public static CharacterScriptableObjects GetData()
    { return instance.characterData; }

    public void SelectCharacter(CharacterScriptableObjects character)
    {
        characterData = character;
    }
    public void DestroySingleton()
    {
        instance = null;
        Destroy(gameObject);
    }
}
