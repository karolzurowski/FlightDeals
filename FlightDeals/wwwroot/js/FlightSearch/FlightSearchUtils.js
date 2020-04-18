var FlightSeachUtils = {

    setupAutoComplete: function () {
        var customRenderMenu = function (ul, items) {
            var self = this;
            let cities = [];

            function contain(item, array) {
                let contains = false;
                $.each(array, function (index, value) {
                    if (value == item) {
                        contains = true;
                        return false;
                    }
                })
                return contains;
            };

            $.each(items, function (index, item) {
                if (!contain(item.City, cities)) {
                    cities.push(item.City);
                }
            });

            $.each(items, function (index, item) {
                item.label = item.Name + " (" + item.IataCode + ")";
                item.value = item.IataCode;
            });


            $.each(cities, function (index, city) {
                let cityAirportsCount = (items.filter(itemTemp => itemTemp.City == city)).length;
                if (cityAirportsCount > 1) {
                    let cityLi = $("<li class='ui-autocomplete-city'>" + city + "</li>");
                   
                    cityLi.label = "Label"
                    let submenu = $("<div class='submenu " + city + "'><ul></ul></div>");
                    cityLi.append(submenu);
                    ul.append(cityLi);
                    let submenuUl = ul.find("." + city + " ul")
                    $.each(items, function (index, item) {
                        if (item.City == city) {
                            self._renderItemData(submenuUl, item);
                          
                        }
                    });
                }
                else {
                    $.each(items, function (index, item) {
                        if (item.City == city) {
                            self._renderItemData(ul, item);                          
                        }
                    });
                }
              
            });
        };

        $("#departureTextBox").autocomplete({
            source: "FlightSearch/Search",
            create: function () {
                $(this).data('uiAutocomplete')._renderMenu = customRenderMenu;
            },
            select: function (event, ui) {
                event.preventDefault();
                $("#departureTextBox").val(ui.item.label);

            },
            focus: function (event, ui) {
                event.preventDefault();
                $("#departureTextBox").val(ui.item.label);
            }
        });

        $("#arrivalTextBox").autocomplete({
            source: "FlightSearch/Search",
            create: function () {
                //access to jQuery Autocomplete widget differs depending
                //on jQuery UI version - you can also try .data('autocomplete')
                $(this).data('uiAutocomplete')._renderMenu = customRenderMenu;
            },
            select: function (event, ui) {
                event.preventDefault();
                $("#arrivalTextBox").val(ui.item.label);

            },
            focus: function (event, ui) {
                event.preventDefault();
                $("#arrivalTextBox").val(ui.item.label);
            }
        });
    },

    setIataCode: function (source, destination) {
        $("#flightSearchForm").submit(function () {
            let cityAndCode = source.val();
            let code = cityAndCode.substr(cityAndCode.indexOf("(") + 1, 3);
            destination.val(code);
        })
    }
}



