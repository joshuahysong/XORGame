using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XORGame.Areas.Arena.Models;
using XORGame.Data.Entities;
using XORGame.Data;
using Newtonsoft.Json;
using XORGame.Data.DataTransferEntities;
using XORGame.Engines;
using XORGame.Data.Data;

namespace XORGame.Areas.Arena.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Character test;
            using (var db = new XORGameContext())
            {
                test = db.Characters.FirstOrDefault();
            }

            // TODO Get this data from a log table in case user refreshes.
            List<CharacterBattleInfo> characters = Manager.GetCharacters();
            BattleEngine.GetNextTurnCharacter(characters);
            ArenaViewModel arena = new ArenaViewModel
            {
                Characters = characters,
                CombatLog = new List<string>()
            };

            return View("Index", arena);
        }

        [HttpGet]
        public string GetCharacter(string characterID)
        {
            if (!string.IsNullOrWhiteSpace(characterID) && int.TryParse(characterID, out int intCharacterID))
            {
                return JsonConvert.SerializeObject(Manager.GetCharacter(intCharacterID));
            }

            return string.Empty;
        }

        [HttpPost]
        public ActionResult PerformAction(string selectedCharacterID, string targetCharacterID, string AbilityID, List<string> combatLog)
        {
            CharacterBattleInfo selectedCharacter;
            CharacterBattleInfo targetedCharacter;
            if (combatLog == null)
            {
                combatLog = new List<string>();
            }

            if (int.TryParse(selectedCharacterID, out int selectedID) && int.TryParse(targetCharacterID, out int targetID))
            {
                selectedCharacter = Manager.GetCharacter(selectedID);
                targetedCharacter = Manager.GetCharacter(targetID);

                // TODO This calculation should be somewhere else. A Combat Rules class maybe?
                targetedCharacter.CurrentHealth = targetedCharacter.CurrentHealth - selectedCharacter.Attack < 0 ? 0 : targetedCharacter.CurrentHealth - selectedCharacter.Attack;
                combatLog.Insert(0, string.Format("{0} hits {1} doing {2} points of damage.\n\r", selectedCharacter.Name, targetedCharacter.Name, selectedCharacter.Attack));
            }

            List<CharacterBattleInfo> characters = Manager.GetCharacters();
            BattleEngine.GetNextTurnCharacter(characters);
            ArenaViewModel arena = new ArenaViewModel
            {
                Characters = characters,
                CombatLog = combatLog
            };

            return View("_Board", arena);
        }
    }
}