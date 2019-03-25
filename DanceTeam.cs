using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DanceTeam : MonoBehaviour
{
    const float DancerSpaceing = 2;
    
    public Color teamColor = Color.white;
    [SerializeField]
    protected string danceTeamName;
    public Transform lineUpStart;
    public Text troupeNameText;
    public List<Character> allDancers;
    public List<Character> activeDancers;
    public GameObject fightWinContainer;

    public void AddNewDancer(Character dancer)
    {

      
      //dancers added to boths lists
        Debug.LogWarning("AddNewDancer called, it needs to put dancer in both lists and set the dancers team.");
        allDancers.Add(dancer);
        activeDancers.Add(dancer);
        dancer.myTeam = this;
    }

    public void RemoveFromActive(Character dancer)
    {
      
        // dancer is our input,
        // removes from active dancers
        dancer.mojoRemaining = 0;
        allDancers.Remove(dancer);
        activeDancers.Remove(dancer);

        Debug.LogWarning("RemoveFromActive called, it needs to take the dancer out of the active list and possibly update selectedness, mojo etc.");
        activeDancers.Remove(dancer);
    }


    #region Pre-Existing
    //init prefabs in order and call addnewdancer
    public void InitaliseTeamFromNames(GameObject dancerPrefab, float direction, CharacterName[] names)
    {
        for (int i = 0; i < names.Length; i++)
        {
            //make one
            var newDancer = Instantiate(dancerPrefab, lineUpStart.position + lineUpStart.right * i * DancerSpaceing * direction, dancerPrefab.transform.rotation);
            //fix its rotation, animations are often a pain
            newDancer.transform.forward = -lineUpStart.right;

            //give it a name and add it to the team
            var aChar = newDancer.GetComponent<Character>();
            aChar.AssignName(names[i]);
            AddNewDancer(aChar);
        }
    }

    //called by other scripts, also updates are text element
    public void SetTroupeName(string name)
    {
        danceTeamName = name;
        if (troupeNameText != null)
        {
            troupeNameText.text = name;
        }
    }

    //toggle on the win effect if one exists
    public void EnableWinEffects()
    {
        if (fightWinContainer != null)
        {
            fightWinContainer.SetActive(true);
            var l = fightWinContainer.GetComponentInChildren<Light>();
            if (l != null)
            {
                l.color = teamColor;
            }
        }
    }

    //toggle off win effects is one exists
    public void DisableWinEffects()
    {
        if (fightWinContainer != null)
        {
            fightWinContainer.SetActive(false);
        }
    }
    #endregion
}
