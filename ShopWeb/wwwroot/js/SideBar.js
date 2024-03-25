
    $(document).ready(function () {
            // Function to fetch sorted products using AJAX
            function fetchSortedProducts(sortType) {
                $.ajax({
                    url: '@Url.Action("SortProducts", "Home")',
                    type: 'GET',
                    data: { sortType: sortType },
                    success: function (result) {
                        $('#productList').html(result);
                    },
                    error: function (xhr, status, error) {
                        console.error(xhr.responseText);
                    }
                });
            }
            var isClicked = ""; // Variable to track which button is clicked

            $("#sortByPriceHigh").click(function () {
                // Sort products by price (high to low)
                fetchSortedProducts("PriceHighToLow");
                if (isClicked === "sortByPriceHigh") {
                    resetButtonStyles(); // Reset button styles if already clicked
                    isClicked = ""; // Unset the clicked button
                    fetchSortedProducts("")
                } else {
                    resetButtonStyles(); // Reset button styles
                    document.getElementById("sortByPriceHigh").style.backgroundColor = "black";
                    isClicked = "sortByPriceHigh"; // Update the clicked button
                    fetchSortedProducts("")
                }
            });

            $("#sortByPriceLow").click(function () {
                // Sort products by price (low to high)
                fetchSortedProducts("PriceLowToHigh");
                if (isClicked === "sortByPriceLow") {
                    resetButtonStyles(); // Reset button styles if already clicked
                    isClicked = ""; // Unset the clicked button
                    fetchSortedProducts("")
                } else {
                    resetButtonStyles(); // Reset button styles
                    document.getElementById("sortByPriceLow").style.backgroundColor = "black";
                    isClicked = "sortByPriceLow"; // Update the clicked button
                   
                }
            });

        $("#sortByPopularity").click(function () {
            // Sort products by Popularity
            fetchSortedProducts("Popularity");
            if (isClicked === "sortByPopularity") {
                    resetButtonStyles(); // Reset button styles if already clicked
                    isClicked = ""; // Unset the clicked button
                    fetchSortedProducts("")
                } else {
                    resetButtonStyles(); // Reset button styles
                document.getElementById("sortByPopularity").style.backgroundColor = "black";
                isClicked = "sortByPopularity"; // Update the clicked button
                }
            });

            function resetButtonStyles() {
                // Reset button styles for all buttons
                document.getElementById("sortByPriceHigh").style.backgroundColor = "";
                document.getElementById("sortByPriceLow").style.backgroundColor = "";
                document.getElementById("sortByPopularity").style.backgroundColor = "";
            }

            // Function to filter products based on search text, selected categories, and price range
            function filterProducts() {
                // Get search text
                var searchText = $("#searchInput").val().toLowerCase();
                // Collect selected categories
                var selectedCategories = $(".categoryCheckbox:checked").map(function () {
                    return $(this).val().toLowerCase();
                }).get();
                // Parse price range inputs
                var minPrice = parseFloat($("#minPrice").val()) || 0;
                var maxPrice = parseFloat($("#maxPrice").val()) || Number.MAX_VALUE;

                // Iterate over each product and show/hide based on matching criteria
                $(".product").each(function () {
                    var product = $(this);
                    var title = product.find(".card-title").text().toLowerCase();
                    var category = product.data('category-name').toLowerCase();
                    var price = parseFloat(product.data('price'));

                    var isCategoryMatch = selectedCategories.length === 0 || selectedCategories.includes(category);
                    var isTitleMatch = title.includes(searchText);
                    var isPriceMatch = (price >= minPrice && price <= maxPrice);

                    // Show product if it matches all criteria
                    if (isCategoryMatch && isTitleMatch && isPriceMatch) {
                        product.show();
                    } else {
                        product.hide();
                    }
                });
            }

            // Bind keyup event to search input for live search filtering
            $("#searchInput").on("keyup", filterProducts);
            // Bind change event to category checkboxes to filter products on selection
            $(".categoryCheckbox").on("change", filterProducts);
            // Bind input event to price range inputs for live price filtering
            $("#minPrice, #maxPrice").on("input", filterProducts);
            // Optional: bind click event to an apply filter button if you want to apply filters only on button click
            //$("#applyFilter").click(filterProducts);
});
