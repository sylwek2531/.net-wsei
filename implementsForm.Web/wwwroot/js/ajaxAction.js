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

        if (responseJson.success) {
            // 3. un-hide the alertElement when the request has been successful
            // alertElement.style...
            alertElement.style.display = "block";
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