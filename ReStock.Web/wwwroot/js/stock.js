"use strict";
import { backdrop, closeBackdrop, showBackdrop } from "./site.js";
// ********************************************************************************
// Script for the Stock View
// ********************************************************************************

// Variables
const addShoppingItemButton = document.getElementById("addShoppingItemBtn");
const addShoppingItemModal = document.getElementById("addModal");
const confirmShoppingItemButton = addShoppingItemModal.querySelector(".modalAction .btnYes");
const cancelShoppingItemButton = addShoppingItemModal.querySelector(".modalAction .btnNo");
const shoppingList = document.getElementById("shoppingList");
const userInput = addShoppingItemModal.querySelectorAll(".modalContent input");


// Function
const closeAddShoppingItemModal = () => addShoppingItemModal.classList.remove("visible");
/**
 * Add an item to the shopping list.
 * @param {string} itemname - name of the item to be added into the shopping list
 */
const addItemToShoppingList = (itemname) => {
    if (typeof itemname === "string" || itemname instanceof String) {
        // Add item in UI
        const newItemToBuy = document.createElement("label");
        newItemToBuy.className = "checkBoxText";
        newItemToBuy.innerHTML = `<input type="checkbox" /> ${itemname}`;
        shoppingList.appendChild(newItemToBuy);
        // Add item in DB
    }
};


// EventHandlers
const handleBackdropClick = () => {
    closeAddShoppingItemModal();
    closeBackdrop();
};
/**
 * Show UI for adding shopping item to shopping list.
 */
const handleAddShoppingItemButtonClick = () => {
    showBackdrop();
    addShoppingItemModal.classList.add("visible");
};
/**
 * Add user input to the shopping list.
 */
const handleConfirmShoppingItemButtonClick = () => {
    let itemname = userInput[0].value;
    addItemToShoppingList(itemname);
    closeAddShoppingItemModal();
    closeBackdrop();
};
const handleCancelShoppingItemButtonClick = () => {
    closeAddShoppingItemModal();
    closeBackdrop();
};

// Scripts
backdrop.addEventListener("click", handleBackdropClick);
addShoppingItemButton.addEventListener("click", handleAddShoppingItemButtonClick);
confirmShoppingItemButton.addEventListener("click",handleConfirmShoppingItemButtonClick);
cancelShoppingItemButton.addEventListener("click",handleCancelShoppingItemButtonClick);
/**
* Add click event handler for all element with class "stockTableAddToShoppingListButton".
* Add stock item name direct to the shopping list.
*/
$(".stockTableAddToShoppingListButton").click(function () {
    let ingredientName = this.parentNode.firstChild.nodeValue;
    addItemToShoppingList(ingredientName);
});
