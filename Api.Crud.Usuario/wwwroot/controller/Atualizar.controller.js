sap.ui.define([
    "sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",

], function (Controller, JSONModel) {
    "use strict";

    return Controller.extend("sap.ui.demo.walkthrough.controller.Atualizar", {

		onInit: function (evento) { 
			this
				.getOwnerComponent()
				.getRouter()
				.getRoute("atualizar")
				.attachPatternMatched(this.aoCoincidirComRota, this); 
		},

		aoCoincidirComRota: function(evento){
			var IdUsuario = evento
				.getParameter("arguments")
				.id;

			this.carregarUsuariosDoBanco(IdUsuario);
		},

		carregarUsuariosDoBanco: function (id) {
			this.BuscarUsuariosDoBancoPorId(id)
			.then(dados => {
				var oModel = new JSONModel(dados);
				this.getView().setModel(oModel , "usuario")
			})
		},

		BuscarUsuariosDoBancoPorId: function (id) {
				return fetch(`https://localhost:7137/Api/Usuarios/${id}`)
				.then((resposta) => resposta.json());
		},

    });
});