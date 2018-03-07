var _jogoJaEstaIncluso = function () {
    var incluso = false;
    $('#lstJogos li').each(function () {
        var li = $(this).text();
        console.log(li);
        if (li == $("#Jogos option:selected").text()) {
            alert('O Jogo selecionado já está incluso para este empréstimo.');
            return incluso = true;
        }
    });
    return incluso;
};

$("#btnIncluirJogo").click(function () {
    if (!_jogoJaEstaIncluso()) {
        $("#lstJogos").append(
            '<li class="list-group-item">' + $("#Jogos option:selected").text() +
            '<input name="jogos" id="categorias" type="checkbox" value="' +
            $("#Jogos option:selected").val() +
            '" checked="checked" style="display:none;"/>' +
            '<span class="badge"><i class="glyphicon glyphicon-remove"></i></span></li >');
    }
});

$('#lstJogos').on('click', 'li > span', function () {
    $(this).parent('li').remove();
});

