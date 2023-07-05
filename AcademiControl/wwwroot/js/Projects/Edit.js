function Edit(projectId) {
    var btnSubmit = $("#btnSubmit");
    btnSubmit.on("click", function () {
        var command = {
            ProjectName: $('#Name').val(),
            ProjectDescription: $('#Description').val(),
            ProjectOwner: $('#OwnerId').val(),
            Id: projectId
        };
        console.log(command);
        console.log(JSON.stringify(command));
        $.ajax({
            url: '/Projects/Edit',
            method: "POST",
            contentType: "application/json",
            data: JSON.stringify(command),
            success: function () {
                alert('Sucesso ao criar o Projeto');
            },
            error: function (error) {
                console.log(error);
                alert("não foi possível salvar o registro");
            }
        });
    });
};

function selectPO(poId) {

    $("#OwnerId option").each(function () {
        console.log($(this).val());
        if ($(this).val() === poId) {
           
            $(this).attr("selected", "selected");
            return false; // Sai do loop quando a opção correta for encontrada
        }
    });
};