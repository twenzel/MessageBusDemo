$('table.clickable').on('click', '.clickable-row', function (event) {
    $(this).addClass('info').siblings().removeClass('info');
});
