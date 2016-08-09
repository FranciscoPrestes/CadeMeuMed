/* Função para consulta pública */
function consultaPublica() {
    $("#tblPublico tbody").empty()
    $.ajax({
        url: "/Home/PublicoPost",
        data: {
            cidade: $("#cidadeList").val(),
            especialidade: $("#especialidadeList").val(),
            nome: $("#nome").val()
        },
        dataType: "json",
        type: "GET",
        async: true,
        success: function (aux) {
            $.each(aux, function (index, value) {
                $.each(value, function (i, v) {
                    var AtendePorConvenio = (v.AtendePorConvenio) ? 'Sim' : 'Não',
                        TemClinica = (v.TemClinica) ? 'Sim' : 'Não';
                    var html = '<tr>';
                    html += '<td>' + v.CRM + '</td>';
                    html += '<td>' + v.Nome + '</td>';
                    html += '<td>' + v.Endereco + '</td>';
                    html += '<td>' + v.Bairro + '</td>';
                    html += '<td>' + v.Email + '</td>';
                    html += '<td>' + AtendePorConvenio + '</td>';
                    html += '<td>' + TemClinica + '</td>';
                    html += '<td>' + v.WebsiteBlog + '</td>';
                    html += '</tr>';
                    $("#tblPublico tbody").append(html);
                });
            });
        }
    });
}

/* Função para login */
function login() {
    $.ajax({
        url: "/Usuario/LoginUsuario",
        data: {
            Login: $("#txtLogin").val(),
            Senha: $("#txtSenha").val()
        },
        dataType: "json",
        type: "GET",
        async: true,
        success: function (aux) {
            if (aux.OK) {
                window.location.href = "/Home/Index";
            } else {
                alert(aux.Mensagem)
            }
        }
    });
}

/* Função para deletar registros */
function deleteRegister(id, controller) {
    if (confirm('Prosseguir Com Exclusão ?')) {
        $.ajax({
            type: 'POST',
            url: '/' + controller + '/Excluir',
            data: { id: id },
            success: function (res) {
                console.log(res);
                if (res == "True") {
                    alert('Registro Removido Com Sucesso !');
                    location.reload();
                } else {
                    alert('Falha Ao Processar Requisição !');
                }
            }
        });
    }

}