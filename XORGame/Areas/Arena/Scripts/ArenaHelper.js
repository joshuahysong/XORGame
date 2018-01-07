(function (window, $) {

    var arenaHelperLib = function () {
        var self = this;

        self.init = init;
        self.PerformAction = null;

        function init(settings) {
            self.PerformAction = settings.PerformAction;
            bindEvents();
        }

        function bindEvents() {
            $('.character-box').on('click', selection);
        }

        function selection() {
            var selectedCharacter = $(".selected-character").data("characterid")
            var targetCharacter = $(this).data("characterid")
            if (selectedCharacter != targetCharacter) {
                attack(selectedCharacter, targetCharacter);
            }
        }

        function attack(selectedCharacter, targetCharacter) {
            // Get recent 2 combat log entries
            var logs = $('.combat-log-entry').slice(0,2).map(function () {
                return $.trim($(this).text());
            }).get();
            $.post(self.attackURL,
                {
                    selectedCharacterID: selectedCharacter,
                    targetCharacterID: targetCharacter,
                    combatLog: logs
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