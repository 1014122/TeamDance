using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week6Demo : MonoBehaviour
{
    // Start is called before the first frame update
    public Character Char1;
    public List<Character> allCharacters;
    public class Character
    {
        public int Level;
        public string Name;
    }
    public class InventoryItem
    {
        public int price;
        public float weight;
        public string name;
    }

    public List<InventoryItem> allItems;
    void Start()
    {

        //instatiate a list of items

        allItems = new List<InventoryItem>();
        allItems.Add(new InventoryItem());
        allItems.Add(new InventoryItem());
        allItems.Add(new InventoryItem());
        allItems.Add(new InventoryItem());

        for (int index = 0; index < allItems.Count; ++index)
        {
            allItems[index].price = 10 + (index + 10);
        }


        //instantiate a list of characters
        allCharacters = new List<Character>();
        allCharacters.Add(new Character());
        allCharacters.Add(new Character());
        allCharacters.Add(new Character());
        allCharacters.Add(new Character());
        allCharacters.Add(new Character());
        /*
        //set the name of each character
        allCharacters[0].name = "Character 0";
        allCharacters[1].name = "Character 1";
        allCharacters[2].name = "Character 2";
        allCharacters[3].name = "Character 3";
        allCharacters[4].name = "Character 4";
        
        */
        //sets all character level in the list to level 10
        int charIndex = 1;
        foreach(Character currentChar in allCharacters)
        {
           
            currentChar.Name = "character" + charIndex;
            currentChar.Level = 10;
            //increases charIndex by 1 every time it runs
            ++charIndex;

        }
        for(int index = 0; index < allCharacters.Count; ++index)
        {
            allCharacters[index].Level = 10;
            allCharacters[index].Name = "Character" + (index + 1);
        }
    } 
       

      
        
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
