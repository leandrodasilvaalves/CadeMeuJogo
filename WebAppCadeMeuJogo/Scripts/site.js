$(document).ready(function () {



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
                '<input name="chkJogos" id="chkJogos" type="checkbox" value="' +
                $("#Jogos option:selected").val() +
                '" checked="checked" style="display:none;"/>' +
                '<span class="badge"><i class="glyphicon glyphicon-remove"></i></span></li >');
        }
    });


    $('#lstJogos').on('click', 'li > span', function () {
        $(this).parent('li').remove();
    });

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true
    });

    var jogosDevolverCount= 0;
    $(this).on('click', '.btn-devolver-unit', function () {
        var row = $(this).closest('tr');        
        var id = row.find('td').first().text();
        var nomeJogo =row.find('td:nth-child(2)').text();
        row.remove();
        atualizarTabelaDevolucao(id, nomeJogo);
    });

    function atualizarTabelaDevolucao(id, nomeJogo) {
        $('#tblJogosDevolver')
            .append('<tr><td  class="hidden">' + id +
            '</td><td>' + nomeJogo + '<input name="chkJogosDevolucao" ' +
                            'id="chkJogosDevolucao" type="checkbox" value="' +
                             id +'" checked="checked" style="display:none;"/>' +
                '</td><td><span class="right btn btn-sm btn-default btn-remover-unit">' +
            '<i class="glyphicon glyphicon-remove"></i> Remover</span></td></tr>');
        jogosDevolverCount++;
        bloquearBtnSalvar(jogosDevolverCount);
    }

    $(this).on('click', '.btn-remover-unit', function () {
        var row = $(this).closest('tr');
        var id = row.find('td').first().text();
        var nomeJogo = row.find('td:nth-child(2)').text();
        row.remove();
        atutalizarTabelaJogosEmprestimo(id, nomeJogo)
    });

    function atutalizarTabelaJogosEmprestimo(id, nomeJogo) {
        $('#tblJogosEmprestimo').append(
            '<tr>' +
                '<td class="hidden">' + id + '</td>' +
                '<td>' + nomeJogo + '</td >' +
                `<td>
                    <span class="right btn btn-sm btn-default btn-devolver-unit">
                        <i class="glyphicon glyphicon-refresh"></i> Devolver
                                </span>
                </td>
            </tr >`);
        jogosDevolverCount--;
        bloquearBtnSalvar(jogosDevolverCount);
    }

    $('#btnDevolverTodos').click(function () {
        $('#tblJogosEmprestimo tbody tr').each(function (i) {            
            var row = $('#tblJogosEmprestimo tr:nth-child(' + (i + 1) + ')');
            var id = row.find('td:nth-child(1)').text();
            var nomeJogo = row.find('td:nth-child(2)').text();
            atualizarTabelaDevolucao(id, nomeJogo);
        });
        $('#tblJogosEmprestimo tbody').empty();
    });

    function bloquearBtnSalvar(count) {
        if (count == 0) {
            $('#btnSalvar').prop('disabled', true);
        }
        else {
            $('#btnSalvar').prop('disabled', false);
        }
    }

});