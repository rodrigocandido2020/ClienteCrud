sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageBox",

], function (Controller, JSONModel, MessageBox) {
	"use strict";

	return Controller.extend("sap.ui.demo.walkthrough.controller.Detalhes", {

		onInit: function (evento) {
			this
				.getOwnerComponent()
				.getRouter()
				.getRoute("detalhes")
				.attachPatternMatched(this.aoCoincidirComRota, this);

		},

		aoCoincidirComRota: function (evento) {
			var IdUsuario = evento
				.getParameter("arguments")
				.id;

			this.carregarUsuariosDoBanco(IdUsuario);
		},

		carregarUsuariosDoBanco: function (id) {
			this.BuscarUsuariosDoBancoPorId(id)
				.then(dados => {
					dados.dataNascimento = new Date(dados.dataNascimento)
					dados.dataCriacao = new Date(dados.dataCriacao)
					var oModel = new JSONModel(dados);
					this.getView().setModel(oModel, "usuario")
				})
		},

		BuscarUsuariosDoBancoPorId: function (id) {
			return fetch(`https://localhost:7137/Api/Usuarios/${id}`)
				.then((resposta) => resposta.json());
		},

		confirmaDeletarUsuario: function () {
			MessageBox.warning(
				"Certeza Que Deseja Apagar Usuario ?", {
					icon: MessageBox.Icon.WARNING,
					title: "Atenção",
					actions: [MessageBox.Action.OK, MessageBox.Action.CANCEL],
				}
			)
		},

		deletarUsuario: function () {
			this.confirmaDeletarUsuario();
			//var id = this.getView().getModel("usuario").getData().id;
			//fetch(`https://localhost:7137/Api/Usuarios/${id}`, {
					//method: 'DELETE',
					//headers: {
						//'Content-type': 'application/json'
					//},
				//})
				//.then(response => response.json())
		},


	});
});