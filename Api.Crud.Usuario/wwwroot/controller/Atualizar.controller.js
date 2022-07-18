sap.ui.define([
    "sap/ui/core/mvc/Controller",

], function (Controller, JSONModel) {
    "use strict";

    return Controller.extend("sap.ui.demo.walkthrough.controller.Atualizar", {
 
        telaInicial: function (oEvent) {
            var oRouter = this.getOwnerComponent().getRouter(); 
            oRouter.navTo("overview");
        },

        buscarUsuarioId: function (id) {
            var usuarioId = fetch(`https://localhost:7137/Api/Controller/${id}`)
                .then((resposta) => resposta.json())
            return usuarioId;
        },

        carregarUsuarioDoBanco: function () {
            var resultado = this.BuscarUsuarioDoBanco();
            resultado.then(lista => {
                var oModel = new JSONModel(lista);
                this.getView().setModel(oModel, "listaDeUsuarios")
            })
        },

    });
});