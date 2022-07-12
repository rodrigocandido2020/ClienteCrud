sap.ui.define([
	"sap/ui/core/mvc/Controller",
], function (Controller, MessageToast) {
	"use strict";

	return Controller.extend("sap.ui.demo.walkthrough.controller.App", {
		
		onInit: function () {
			this.getView().addStyleClass(this.getOwnerComponent().getContentDensityClass());
		}
	});
});
 