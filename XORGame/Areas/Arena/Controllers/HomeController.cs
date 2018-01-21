using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using XORGame.Data;
using XORGame.Data.DataTransferEntities;
using XORGame.Data.Entities;
using XORGame.Data.Entities.Contracts;
using XORGame.Engines;

namespace XORGame.Areas.Arena.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // TODO Matchmaking of some sort will be needed to pull enemy team.
            return View("Index", EngineCache.GetBattleData(User.Identity.GetUserId(), 1, 2));
        }

        [HttpPost]
        public ActionResult PerformAction(int friendlyTeamID, int enemyTeamID, int targetCharacterID, int abilityID)
        {
            BattleData battleData = EngineCache.GetBattleData(User.Identity.GetUserId(), friendlyTeamID, enemyTeamID);
            CharacterBattleData selectedCharacter = battleData.Characters.Where(c => c.IsSelected).FirstOrDefault();
            CharacterBattleData targetedCharacter = battleData.Characters.Where(c => c.ID == targetCharacterID).FirstOrDefault();
            IAbilityAction ability = selectedCharacter.Abilities.FirstOrDefault(a => a.ID == abilityID);

            if (selectedCharacter != null && targetedCharacter != null && ability != null)
            {
                // TODO Add validation that ability action being performed is allowed to prevent cheating.
                if (ability.IsValidTarget(battleData, targetedCharacter))
                {
                    ability.AdjustCharacterStats(battleData, targetedCharacter);
                    BattleEngine.AdvanceTurnMeters(battleData.Characters);
                    EngineCache.SetBattleData(User.Identity.GetUserId(), battleData);
                }
            }

            return PartialView("_Board", battleData);
        }

        // TEMP
        public ActionResult ResetBattle()
        {
            EngineCache.ClearBattleData(User.Identity.GetUserId());
            return RedirectToAction("Index");
        }
    }
}