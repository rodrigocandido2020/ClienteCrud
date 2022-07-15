sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel"
], function (Controller, JSONModel) {
	"use strict";

	return Controller.extend("sap.ui.demo.walkthrough.controller.App", {
		
		onInit: function () {
			this.getView().addStyleClass(this.getOwnerComponent().getContentDensityClass());
			this.carregarUsuarioDoBanco();''
		},

		BuscarUsuarioDoBanco : function (){
			var usarioObtidos = fetch('https://localhost:7137/Api/Controller')
			.then((resposta) => resposta.json())
			return (usarioObtidos)
		},

		carregarUsuarioDoBanco : function() {
			var resultado = this.BuscarUsuarioDoBanco();
			resultado.then(lista => {
				var oModel = new JSONModel(lista);
				this.getView().setModel(oModel, "listaDeUsuarios")
			})
		},
	});
});
 