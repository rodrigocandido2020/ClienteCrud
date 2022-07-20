sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/model/json/JSONModel"

], function (Controller, History, JSONModel) {
	"use strict";

	return Controller.extend("sap.ui.demo.walkthrough.controller.Cadastro", {
		
		onInit: function () {
			this.getView().setModel(new JSONModel({

                nome: "",
                senha: "",
                email: "",
				dataNascimento: "",
            }), "usuario")
		},

        adicionarUsuario: function () {
			var usuarioTela = this.getView().getModel("usuario")
			fetch("https://localhost:7137/Api/Usuarios", {
				method: 'POST',
				headers: {
					'Content-type': 'application/json'
				},
				body: JSON.stringify(usuarioTela.getData())
			})
			.then(response => response.json())
			alert("Usuario cadastrado com sucesso!!")			
		},

		onNavBack: function () {
			var oHistory = History.getInstance();
			var sPreviousHash = oHistory.getPreviousHash();

			if (sPreviousHash !== undefined) {
				window.history.go(-1);
			} else {
				var oRouter = this.getOwnerComponent().getRouter();
				oRouter.navTo("Lista", {}, true);
			}
		}
	});
});
 