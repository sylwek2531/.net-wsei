(function () {
    const alertElement = document.getElementById("success-alert");
    const formElement = document.forms[0];
    const addNewItem = async () => {
       
        // 1. read data from the form
        const requestData = new FormData(formElement);

        const data = {};
        requestData.forEach((value, key) => {
            console.log(key, value, value == 'true')
            key == 'IsVisible' ? data[key] = value == 'true' ? true : false : data[key] = value
        });

        const formDataJsonString = JSON.stringify(data);
        /*const formDataJsonString = JSON.stringify(requestData);*/
        // 2. call the application server using fetch method
        const response = await fetch('api/Ajax',
            {
                method: "POST",
                body: formDataJsonString,
                headers: {
                    'Accept': 'application/json; charset=utf-8',
                    'Content-Type': 'application/json;charset=UTF-8'
                }
            });
        const responseJson = await response.json();

        if (responseJson.length > 0) {
            const listItemsWrapper = document.getElementById("list-items");

            let list = "";
            responseJson.forEach(function (el) {
                list += `<li>`
                Object.keys(el).forEach(function (key) {
                    list += `${key} : ${el[key]} <br><br>`;
                })
                list += `</li>`

            })
            listItemsWrapper.innerHTML = list;
            // 3. un-hide the alertElement when the request has been successful
            // alertElement.style...
            alertElement.style.display = "block";
            setTimeout(function () {
                alertElement.style.display = "none";
            }, 2000)
        } else {
            console.error("something wrong...");
        }
    };
    window.addEventListener("load", () => {
        formElement.addEventListener("submit", event => {
            event.preventDefault();
            addNewItem().then(() => console.log("added successfully"));
        });
    });
})();