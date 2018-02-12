using Microsoft.AspNet.Identity;
using System.Drawing;
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
        public ActionResult PerformAction(int friendlyTeamID, int enemyTeamID, int abilityID, string targetedSpaceID)
        {
            BattleData battleData = EngineCache.GetBattleData(User.Identity.GetUserId(), friendlyTeamID, enemyTeamID);
            string[] targetCoordinates = targetedSpaceID.Split('-');
            if (targetCoordinates.Length == 3 &&
                int.TryParse(targetCoordinates[1], out int targetX) && 
                int.TryParse(targetCoordinates[2], out int targetY))
            {
                CharacterBattleData selectedCharacter = battleData.Characters.Where(c => c.IsSelected).FirstOrDefault();
                Boardspace targetedSpace = battleData.Boardspaces.FirstOrDefault(bs => bs.IsEqualCoordinates(new Point(targetX, targetY)));
                IAbilityAction ability = selectedCharacter.Abilities.FirstOrDefault(a => a.ID == abilityID);

                if (selectedCharacter != null && targetedSpace != null && ability != null)
                {
                    if (ability.IsValidTarget(battleData, targetedSpace))
                    {
                        // TODO Add validation that ability action being performed is allowed to prevent cheating.
                        ability.AdjustCharacterStats(battleData, targetedSpace);
                        BattleEngine.AdvanceTurnMeters(battleData);
                        EngineCache.SetBattleData(User.Identity.GetUserId(), battleData);
                    }
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