$(document).ready(function () {
});


function selecionarFilme(filmeSelecionado) {
    var array = [];
    var qtdFilmes = 0;

    $("input[type=checkbox]").each(function (i, row) {
        qtdFilmes++;
    });

    $("input[type=checkbox]:checked").each(function (i, row) {
        array.push(row.value);
    });

    if (array.length > 8) {
        alert("Não é possivel selecionar mais que 8 filmes");
        filmeSelecionado.checked = false;
    }
    else {
        $("#QtdFilmesSelecionado").html("Selecionados " + array.length + " de " + qtdFilmes +" filmes");
    }
}

function GerarCampeonato()
{
    var filmesSelecionado = [];

    $("input[type=checkbox]:checked").each(function (i, row) {       
        filmesSelecionado.push(row.value);
    });

    if (filmesSelecionado.length < 8) {
        alert("Selecione 8 filmes, foram selecionado " + filmesSelecionado.length + " filmes")
    }
    else
    {
        var Url = 'Filme/Index'
        $.ajax({
            url: Url,
            type: "POST",
            data: JSON.stringify(
                {
                    'idFilmes': filmesSelecionado
                }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                var posicoes = "";
                var j = 1;
                $.each(data.Resultado, function (i, row) {

                    posicoes += "<div class='row' style='margin-bottom: 15px;'>";
                    posicoes += "<div class='col-md-1' style='background-color:cornflowerblue; color: white; border: 1px solid white;'>";
                    posicoes += "<h3>" + j + "º </h3>";
                    posicoes += "</div>";
                    posicoes += "<div class='col-md-11' style='background-color:white; text-align:left; color:black;'>";
                    posicoes += "<h5>" + row.titulo + "</h5>";
                    posicoes += "</div>";
                    posicoes += "</div>";
                    j++;
                })
                $("#colocacao").html(posicoes); 
                $("#lnkResultado").click();
            },
        });
    }

    
}