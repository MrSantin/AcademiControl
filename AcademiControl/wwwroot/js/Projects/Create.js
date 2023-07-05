﻿$(document).ready(function () {
    var btnSubmit = $("#btnSubmit");
    btnSubmit.on("click", function () {
        var command = {
            ProjectName: $('#Name').val(),
            ProjectDescription: $('#Description').val(),
            ProjectOwner: $('#OwnerId').val()
        };
        console.log(command);
        console.log(JSON.stringify(command));
        $.ajax({
            url: '/Projects/Create',
            method: "POST",
            contentType: "application/json",
            data: JSON.stringify(command),
            success: function () {
                alert('Sucesso ao criar o Projeto');
            },
            error: function (error) {
                console.log(error);
                alert("não foi possível salvar o registro");            }
        });
    });
});
