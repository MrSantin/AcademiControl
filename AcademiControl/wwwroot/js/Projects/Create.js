$(document).ready(function () {

    var btnCriar = $("#criar");
    btnCriar.on("click", function () {
        var command = new Object();

        command.ProjectName = $('#Name').val();
        command.ProjectDescription = $('#Description').val();
        command.ProjectOwnerId = $('#OwnerId').val();
        console.log(command);

        $.ajax({
            url: '/Projects/Create',
            method: "POST",
            contentType: "application/json",
            data: JSON.stringify(command),
            success: function () {
                alert('Sucesso ao criar o Projeto');
            },
            error: function (error) {
                alert(error);
            }

        });
    });

})