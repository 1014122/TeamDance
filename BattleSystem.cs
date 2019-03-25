using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BattleSystem : MonoBehaviour
{ 
    public Character teamAdancer;
    
    public Character teamBdancer;
   
    public DanceTeam TeamA,TeamB;

    public float battlePrepTime = 2;
    public float fightWinTime = 2;

    private void OnEnable()
    {
        GameEvents.OnRequestFighters += RoundRequested;
        GameEvents.OnFightComplete += FightOver;
    }

    private void OnDisable()
    {
        GameEvents.OnRequestFighters -= RoundRequested;
        GameEvents.OnFightComplete -= FightOver;
    }

    void RoundRequested()
    {
        //calling the coroutine so we can put waits in for anims to play
        StartCoroutine(DoRound());
    }
  
  
    IEnumerator DoRound()
    {
        yield return new WaitForSeconds(battlePrepTime);

        //checking for no dancers on either team

        if (TeamA.activeDancers.Count > 0 && TeamB.activeDancers.Count > 0)
        {
            //takes one random dance from each team and has them battle eachother
            int TeamARandom = Random.Range(0, TeamA.activeDancers.Count);
            teamAdancer = TeamA.activeDancers[TeamARandom];
            int TeamBRandom = Random.Range(0, TeamB.activeDancers.Count);
            teamBdancer = TeamB.activeDancers[TeamBRandom];
            GameEvents.RequestFight(new FightEventData(teamAdancer, teamBdancer));
        }
        else
        {
           //checks if which dancer wins
            if (TeamA.activeDancers.Count >= 0)
            {
                GameEvents.BattleFinished(TeamA);
                TeamA.EnableWinEffects();
            }
            if (TeamB.activeDancers.Count >= 0)
            {
                GameEvents.BattleFinished(TeamB);
                TeamA.EnableWinEffects();
            }
           
            Debug.Log("DoRound called, but we have a winner so Game Over");
        }
    }

    void FightOver(FightResultData data)
    {
        Debug.LogWarning("FightOver called, may need to check for winners and/or notify teams of zero mojo dancers");
      
        Debug.Log(data.outcome);

        //playing effect when win
        
        if (data.outcome == 1 || data.outcome == -1)
        {
            data.winner.myTeam.EnableWinEffects();
            data.defeated.myTeam.RemoveFromActive(data.defeated);
        }
        StartCoroutine(HandleFightOver());
    }

    IEnumerator HandleFightOver()
    {
        yield return new WaitForSeconds(fightWinTime);
        TeamA.DisableWinEffects();
        TeamB.DisableWinEffects();
        Debug.LogWarning("HandleFightOver called, may need to prepare or clean dancers or teams and checks before doing GameEvents.RequestFighters()");
        GameEvents.RequestFighters();
    }
}
