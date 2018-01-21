(function (window, $) {

    var arenaHelperLib = function () {
        var self = this;
        var targetedSpaceID = 0;

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
            $('.board-space').on('click', targetSpace);
            $('.btn-ability').on('click', performAction);
        }

        function targetSpace() {
            $('.board-space').removeClass("targeted-space");
            $(this).addClass("targeted-space");
            targetedSpaceID = $(this).attr("id");
        }

        function performAction() {
            if (!$(this).prop("disabled")) {
                var abilityID = $(this).data("abilityid");
                if (abilityID) {
                    $.post(self.performActionURL,
                        {
                            friendlyTeamID: self.friendlyTeamID,
                            enemyTeamID: self.enemyTeamID,
                            abilityID: abilityID,
                            targetedSpaceID: targetedSpaceID
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