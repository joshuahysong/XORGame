﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using XORGame.Data.DataTransferEntities;
using XORGame.Engines;

namespace XORGame.Areas.Arena.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // TODO Matchmaking of some sort will be needed to pull enemy team.
            return View("Index", EngineCache.GetBattleData(1, 2));
        }

        [HttpPost]
        public ActionResult PerformAction(string friendlyTeamID, string enemyTeamID, string targetCharacterID, string abilityID)
        {
            if (int.TryParse(friendlyTeamID, out int intFriendlyTeamID) && 
                int.TryParse(enemyTeamID, out int intEnemyTeamID) &&
                int.TryParse(targetCharacterID, out int intTargetCharacterID) &&
                int.TryParse(abilityID, out int intAbilityID))
            {
                BattleData battleData = EngineCache.GetBattleData(intFriendlyTeamID, intEnemyTeamID);
                CharacterBattleData selectedCharacter = battleData.Characters.Where(c => c.IsSelected).FirstOrDefault();
                CharacterBattleData targetedCharacter = battleData.Characters.Where(c => c.ID == intTargetCharacterID).FirstOrDefault();
                // TODO Add Ability stuff and things
                if (selectedCharacter != null && targetedCharacter != null)
                {
                    // TODO Add validation that the action being performed is allowed.



                    BattleEngine.AdvanceTurnMeters(battleData.Characters);
                    EngineCache.SetBattleData(battleData);

                    return PartialView("_Board", battleData);
                }
            }

            return null;
        }
    }
}