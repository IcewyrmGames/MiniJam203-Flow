using UnityEngine;

public class detect_ingredients_completed : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        detect_objects.OnIngredientAdd += ShowWin;
    }

    void OnDisable()
    {
        
    }

    private void ShowWin(detect_objects detection)
    {
        transform.position = Vector2.zero;
    }

}
