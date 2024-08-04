document.addEventListener("DOMContentLoaded", function () {
	const toggleButton = document.getElementById("toggle-button");
	const filterFormContainer = document.getElementById("filter-form-container");

	toggleButton.addEventListener("click", function () {
		if (filterFormContainer.classList.contains("collapsed")) {
			filterFormContainer.classList.remove("collapsed");
			filterFormContainer.classList.add("expanded");
			toggleButton.textContent = "Hide Filters";
		} else {
			filterFormContainer.classList.remove("expanded");
			filterFormContainer.classList.add("collapsed");
			toggleButton.textContent = "Show Filters";
		}
	});
});