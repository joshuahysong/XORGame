using System.Collections.Generic;
using System.Web.Mvc;
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
        public ActionResult PerformAction(string selectedCharacterID, string targetCharacterID, string AbilityID, List<string> combatLog)
        {
            return null;
            //CharacterBattleData selectedCharacter;
            //CharacterBattleData targetedCharacter;
            //if (combatLog == null)
            //{
            //    combatLog = new List<string>();
            //}

            //if (int.TryParse(selectedCharacterID, out int selectedID) && int.TryParse(targetCharacterID, out int targetID))
            //{
            //    selectedCharacter = Manager.GetCharacter(selectedID);
            //    targetedCharacter = Manager.GetCharacter(targetID);

            //    // TODO This calculation should be somewhere else. A Combat Rules class maybe?
            //    targetedCharacter.CurrentHealth = targetedCharacter.CurrentHealth - selectedCharacter.Attack < 0 ? 0 : targetedCharacter.CurrentHealth - selectedCharacter.Attack;
            //    combatLog.Insert(0, string.Format("{0} hits {1} doing {2} points of damage.\n\r", selectedCharacter.Name, targetedCharacter.Name, selectedCharacter.Attack));
            //}

            //List<CharacterBattleData> characters = Manager.GetCharacters();
            //BattleEngine.AdvanceTurnMeters(characters);
            //BattleData arena = new BattleData
            //{
            //    Characters = characters,
            //    CombatLog = combatLog
            //};

            //return View("_Board", arena);
        }
    }
}