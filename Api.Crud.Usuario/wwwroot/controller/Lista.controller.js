sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/m/MessageToast",
	"sap/ui/model/json/JSONModel",
	"sap/ui/demo/walkthrough/model/formatter"
], function (Controller, MessageToast, JSONModel, Formatter) {
	"use strict";

	return Controller.extend("sap.ui.demo.walkthrough.controller.Lista", {

		onInit: function () { 
			this
				.getOwnerComponent()
				.getRouter()
				.getRoute("lista")
				.attachPatternMatched(this.aoCoincidirComRota, this); 
		},

		aoCoincidirComRota: function(evento){
			this.carregarUsuariosDoBanco();
		},

		onShowHello: function () {
			// read msg from i18n model
			var oBundle = this.getView().getModel("i18n").getResourceBundle();
			var sRecipient = this.getView().getModel().getProperty("/recipient/name");
		},

		telaCriarUsuario: function (oEvent) {
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("cadastro");
		},

		atualizarUsuario: function (oEvent) { 
			var id = oEvent
				.getParameter("listItem")
				.getBindingContext("listaDeUsuarios") 
				.getProperty("id")
				var oRouter = this.getOwnerComponent().getRouter();
			
			oRouter.navTo("atualizar", { id: id });
	},

		testeFuncao: function () {
			MessageToast.show("Hello World");
		},

		BuscarUsuariosDoBanco: function () {
			var usarioObtidos = fetch('https://localhost:7137/Api/Usuarios')
				.then((resposta) => resposta.json())
			return (usarioObtidos)
		},

		modelo: function(nome, modelo){
			var view = this.getView();
			if(!!modelo){	
				view.setModel(modelo, nome);
			}
			return view.getModel(nome); 
		},

		modeloDeListaDeUsuarios: function(modelo){
			const nome = "listaDeUsuarios";
			return this.modelo(nome, modelo);
		},
 
		carregarUsuariosDoBanco: function () {
			var resultado = this.BuscarUsuariosDoBanco();
			resultado.then(lista => {
				var oModel = new JSONModel(lista);
				this.modeloDeListaDeUsuarios(oModel);
			})
		},
	});
});