// Variables
export const backdrop = document.getElementById("backdrop");

// Functions
export const closeBackdrop = () => backdrop.classList.remove("visible");
export const showBackdrop = () => backdrop.classList.add("visible");