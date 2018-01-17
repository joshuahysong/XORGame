(function (window, $) {

    var arenaHelperLib = function () {
        var self = this;
        var targetedCharactterID = 0;

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
            $('.btn-ability').on('click', performAction);
        }

        function selection() {
            $('.character-box').removeClass("targeted-character");
            $(this).addClass("targeted-character");
            targetedCharactterID = $(this).data("characterid");        }

        function performAction() {
            // Get recent 2 combat log entries
            //var logs = $('.combat-log-entry').slice(0,2).map(function () {
            //    return $.trim($(this).text());
            //}).get();
            if (!$(this).children(':first').prop("disabled")) {
                var abilityID = $(this).data("abilityid");
                if (abilityID) {
                    $.post(self.performActionURL,
                        {
                            friendlyTeamID: self.friendlyTeamID,
                            enemyTeamID: self.enemyTeamID,
                            targetCharacterID: targetedCharactterID,
                            abilityID: abilityID
                        },
                        function (result) {
                            $('#board').html(result);
                            bindEvents();
                        }
                    );
                }
            }
        }
    };

    window.arenaHelper = new arenaHelperLib();

})(window, jQuery);