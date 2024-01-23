function toggleAccessories() {
    var accessoriesList = document.querySelector('.list-information-car-accessories');
    var toggleButton = document.querySelector('.toggle-accessories-button');
    var pageSize = document.querySelector('.hostel-home-card');

    if (accessoriesList.style.display === 'flex') {
        accessoriesList.style.opacity = 0;
        accessoriesList.style.display = 'none';
        pageSize.style.height = '1950px';
        toggleButton.textContent = 'Show More';
    } else {
        accessoriesList.style.opacity = 1;
        accessoriesList.style.display = 'flex';
        pageSize.style.height= '2650px';
        toggleButton.textContent = 'Show Less';
    }
}