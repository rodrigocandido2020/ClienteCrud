sap.ui.define([
    "sap/ui/core/mvc/Controller",

], function (Controller, JSONModel) {
    "use strict";

    return Controller.extend("sap.ui.demo.walkthrough.controller.Atualizar", {


        onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("atualizar").attachPatternMatched(this._onObjectMatched, this);
		},

		_onObjectMatched: function (oEvent) {
			this.getView().bindElement({
				path: "/" + window.decodeURIComponent(oEvent.getParameter("arguments").invoicePath)
			});
		}

    });
});