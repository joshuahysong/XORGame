(function (window, $) {

    var arenaHelperLib = function () {
        var self = this;
        var selectedAbilityID = null;
        var validTargets = [];

        self.init = init;
        self.performActionURL = null;
        self.friendlyTeamID = null;
        self.enemyTeamID = null;
        self.boardX = 0;
        self.boardY = 0;

        function init(settings) {
            self.performActionURL = settings.performActionURL;
            self.friendlyTeamID = settings.friendlyTeamID;
            self.enemyTeamID = settings.enemyTeamID;
            self.boardX = settings.boardX;
            self.boardY = settings.boardY;
            bindEvents();
        }

        function bindEvents() {
            validTargets = [];
            selectedAbilityID = null;
            $('.board-space').on('click', performAction);
            $('.btn-ability').on('click', abilitySelection);
        }

        function abilitySelection() {
            if (!$(this).prop("disabled")) {
                $('.board-space').removeClass("targeted-space");
                validTargets = $(this).data("validtargets");
                if (validTargets.length > 0) {
                    selectedAbilityID = $(this).data("abilityid");
                    $('[id^=select-arrow-]').addClass('text-hide');
                    $('#select-arrow-' + selectedAbilityID).removeClass('text-hide');
                    for (var y = 0; y < self.boardY; y++) {
                        for (var x = 0; x < self.boardX; x++) {
                            var boardSpace = $('#space-' + x + '-' + y);
                            if (boardSpace && validTargets.indexOf(x + ', ' + y) > -1) {
                                boardSpace.addClass('targeted-space');
                            }
                        }
                    }
                }
            }
        }

        function performAction() {
            targetedSpaceID = $(this).attr("id");
            var targetCoords = targetedSpaceID.split('-');
            if (targetCoords.length === 3 && validTargets.indexOf(targetCoords[1] + ', ' + targetCoords[2]) > -1) {
                if (selectedAbilityID) {
                    $.post(self.performActionURL,
                        {
                            friendlyTeamID: self.friendlyTeamID,
                            enemyTeamID: self.enemyTeamID,
                            abilityID: selectedAbilityID,
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