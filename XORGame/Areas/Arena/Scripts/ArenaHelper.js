(function (window, $) {

    var arenaHelperLib = function () {
        var self = this;

        self.init = init;
        self.performActionURL = null;
        self.friendlyTeamID = null;
        self.enemyTeamID = null;

        function init(settings) {
            self.performActionURL = settings.performActionURL;
            self.friendlyTeamID = settings.friendlyTeamID;
            self.enemyTeamID = settings.enemyTeamID;
            bindEvents();
        }

        function bindEvents() {
            $('.character-box').on('click', selection);
        }

        function selection() {
            performAction($(this).data("characterid"));
        }

        function performAction(targetCharacter) {
            // Get recent 2 combat log entries
            var logs = $('.combat-log-entry').slice(0,2).map(function () {
                return $.trim($(this).text());
            }).get();
            $.post(self.performActionURL,
                {
                    friendlyTeamID: self.friendlyTeamID,
                    enemyTeamID: self.enemyTeamID,
                    targetCharacterID: targetCharacter,
                    abilityID: 1
                },
                function (result) {
                    $('#board').html(result);
                    bindEvents();
                }
            );
        }
    };

    window.arenaHelper = new arenaHelperLib();

})(window, jQuery);